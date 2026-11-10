using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using KaraokeManagement.BUS;

namespace KaraokeManagement.GUI;

public partial class FormKaraoke : Form
{
    private readonly KaraokeBUS _karaokeBUS = new();
    private DataRow? _selectedRoomRow;
    private DataRow? _selectedActiveInvoiceRow;
    private decimal _currentTotalServices;

    public FormKaraoke()
    {
        InitializeComponent();
        LoadServicesComboBox();
        BuildVisualRoomGrid();
    }

    private void LoadServicesComboBox()
    {
        DataTable dt = _karaokeBUS.GetServices();
        cboDichVu.DisplayMember = "tendv";
        cboDichVu.ValueMember = "madv";
        cboDichVu.DataSource = dt;
    }

    private void BuildVisualRoomGrid()
    {
        pnlRoomGrid.Controls.Clear();
        DataTable dtRooms = _karaokeBUS.GetRooms();

        foreach (DataRow row in dtRooms.Rows)
        {
            int maPhong = Convert.ToInt32(row["maphong"]);
            string roomName = row["tenphong"]?.ToString() ?? "";
            string roomType = row["loaiphong"]?.ToString() ?? "";
            string status = row["trangthai"]?.ToString() ?? "";
            decimal price = Convert.ToDecimal(row["giatheogio"]);

            Button btnRoom = new()
            {
                Width = 120,
                Height = 100,
                Tag = maPhong,
                Text = $"{roomName}\n({roomType})\n{price:N0}/h\n[{status}]",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                BackColor = status.Equals("trống", StringComparison.OrdinalIgnoreCase) ? Color.LightGreen : Color.Salmon
            };

            btnRoom.Click += BtnRoom_Click;
            pnlRoomGrid.Controls.Add(btnRoom);
        }
    }

    private void BtnRoom_Click(object? sender, EventArgs e)
    {
        if (sender is not Button btn || btn.Tag is not int maPhong) return;

        DataTable dtRooms = _karaokeBUS.GetRooms();
        DataRow[] found = dtRooms.Select($"maphong = {maPhong}");
        if (found.Length == 0) return;

        DataRow roomRow = found[0];
        string status = roomRow["trangthai"]?.ToString() ?? "";
        string roomName = roomRow["tenphong"]?.ToString() ?? "";
        string roomType = roomRow["loaiphong"]?.ToString() ?? "";

        lblRoomTitle.Text = $"{roomName} ({roomType})";

        if (status.Equals("trống", StringComparison.OrdinalIgnoreCase))
        {
            _selectedRoomRow = roomRow;
            _selectedActiveInvoiceRow = null;
            dgvServices.DataSource = null;
            lblGioVao.Text = "Giờ Vào: --:--";
            lblTienPhong.Text = "Tạm Tính Tiền Phòng: 0 VNĐ";
            lblTienDichVu.Text = "Tổng Tiền Dịch Vụ: 0 VNĐ";
            lblTongTien.Text = "Tổng Thanh Toán: 0 VNĐ";

            if (MessageBox.Show($"Bạn có muốn mở {roomName}?", "Xác Nhận Mở Phòng", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (_karaokeBUS.OpenRoom(maPhong))
                    {
                        MessageBox.Show($"Đã mở {roomName} thành công!");
                        BuildVisualRoomGrid();
                        SelectActiveRoom(maPhong);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi mở phòng: " + ex.Message, "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        else
        {
            SelectActiveRoom(maPhong);
        }
    }

    private void SelectActiveRoom(int maPhong)
    {
        DataTable dtRooms = _karaokeBUS.GetRooms();
        DataRow[] found = dtRooms.Select($"maphong = {maPhong}");
        if (found.Length > 0) _selectedRoomRow = found[0];

        _selectedActiveInvoiceRow = _karaokeBUS.GetActiveInvoice(maPhong);
        if (_selectedActiveInvoiceRow != null)
        {
            int maHD = Convert.ToInt32(_selectedActiveInvoiceRow["mahd"]);
            DateTime giovao = Convert.ToDateTime(_selectedActiveInvoiceRow["giovao"]);
            lblGioVao.Text = $"Giờ Vào: {giovao:dd/MM/yyyy HH:mm:ss}";

            LoadOrderedServicesDisconnected(maHD);
        }
        else
        {
            dgvServices.DataSource = null;
            lblGioVao.Text = "Giờ Vào: Chưa xác định";
            lblTienPhong.Text = "Tạm Tính Tiền Phòng: 0 VNĐ";
            lblTienDichVu.Text = "Tổng Tiền Dịch Vụ: 0 VNĐ";
            lblTongTien.Text = "Tổng Thanh Toán: 0 VNĐ";
            MessageBox.Show("Không tìm thấy hóa đơn đang mở cho phòng này!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void LoadOrderedServicesDisconnected(int maHD)
    {
        DataTable dtServices = _karaokeBUS.GetInvoiceServicesDisconnected(maHD);
        dgvServices.DataSource = dtServices;

        _currentTotalServices = 0;
        if (dtServices != null && dtServices.Rows.Count > 0)
        {
            foreach (DataRow r in dtServices.Rows)
            {
                if (r["thanhtien"] != DBNull.Value)
                {
                    _currentTotalServices += Convert.ToDecimal(r["thanhtien"]);
                }
            }
        }

        lblTienDichVu.Text = $"Tổng Tiền Dịch Vụ: {_currentTotalServices:N0} VNĐ";

        if (_selectedRoomRow != null && _selectedActiveInvoiceRow != null)
        {
            DateTime giovao = Convert.ToDateTime(_selectedActiveInvoiceRow["giovao"]);
            decimal giaTheoGio = Convert.ToDecimal(_selectedRoomRow["giatheogio"]);

            TimeSpan duration = DateTime.Now - giovao;
            double hours = Math.Ceiling(duration.TotalMinutes / 60.0);
            if (hours < 1) hours = 1;
            decimal estRoomCost = (decimal)hours * giaTheoGio;

            lblTienPhong.Text = $"Tạm Tính Tiền Phòng ({hours} giờ): {estRoomCost:N0} VNĐ";
            lblTongTien.Text = $"Tổng Thanh Toán: {(estRoomCost + _currentTotalServices):N0} VNĐ";
        }
    }

    private void BtnAddService_Click(object? sender, EventArgs e)
    {
        if (_selectedActiveInvoiceRow == null)
        {
            MessageBox.Show("Vui lòng chọn một phòng đang hát để gọi dịch vụ!");
            return;
        }

        if (cboDichVu.SelectedValue != null && int.TryParse(cboDichVu.SelectedValue.ToString(), out int maDV))
        {
            int maHD = Convert.ToInt32(_selectedActiveInvoiceRow["mahd"]);
            int soLuong = Convert.ToInt32(numSoLuong.Value);

            DataTable dtServices = _karaokeBUS.GetServices();
            DataRow[] r = dtServices.Select($"madv = {maDV}");
            if (r.Length > 0)
            {
                decimal donGia = Convert.ToDecimal(r[0]["dongia"]);
                if (_karaokeBUS.AddService(maHD, maDV, soLuong, donGia))
                {
                    LoadOrderedServicesDisconnected(maHD);
                }
            }
        }
    }

    private void BtnCheckout_Click(object? sender, EventArgs e)
    {
        if (_selectedActiveInvoiceRow == null || _selectedRoomRow == null)
        {
            MessageBox.Show("Vui lòng chọn một phòng đang hát để thanh toán!");
            return;
        }

        int maHD = Convert.ToInt32(_selectedActiveInvoiceRow["mahd"]);
        int maPhong = Convert.ToInt32(_selectedRoomRow["maphong"]);
        DateTime gioVao = Convert.ToDateTime(_selectedActiveInvoiceRow["giovao"]);
        decimal giaTheoGio = Convert.ToDecimal(_selectedRoomRow["giatheogio"]);

        try
        {
            if (_karaokeBUS.PayBill(maHD, maPhong, gioVao, giaTheoGio, _currentTotalServices, out decimal tongTienPhong, out double soGio))
            {
                decimal tongCong = tongTienPhong + _currentTotalServices;
                MessageBox.Show($"Thanh toán thành công (SqlTransaction Committed)!\n\n" +
                                $"Thời gian hát: {soGio} giờ\n" +
                                $"Tiền phòng: {tongTienPhong:N0} VNĐ\n" +
                                $"Tiền dịch vụ: {_currentTotalServices:N0} VNĐ\n" +
                                $"Tổng tiền hóa đơn: {tongCong:N0} VNĐ",
                                "Hóa Đơn Thanh Toán", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _selectedActiveInvoiceRow = null;
                _selectedRoomRow = null;
                lblRoomTitle.Text = "Chưa Chọn Phòng Hát";
                lblGioVao.Text = "Giờ Vào: --:--";
                dgvServices.DataSource = null;
                lblTienPhong.Text = "Tạm Tính Tiền Phòng: 0 VNĐ";
                lblTienDichVu.Text = "Tổng Tiền Dịch Vụ: 0 VNĐ";
                lblTongTien.Text = "Tổng Thanh Toán: 0 VNĐ";

                BuildVisualRoomGrid();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi Transaction Rollback khi thanh toán: " + ex.Message, "Cảnh Báo Tồn Kho Dịch Vụ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}