using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using GarageManagement.BUS;
using GarageManagement.DTO;

namespace GarageManagement.GUI
{
    public partial class FormGarage : Form
    {
        private GarageBUS garageBUS = new GarageBUS();
        private List<ChiTietSuaChuaDTO> currentDetails = new List<ChiTietSuaChuaDTO>();
        private DataTable dtParts;

        public FormGarage()
        {
            InitializeComponent();
            LoadPartsComboBox();
            RefreshDetailsGrid();
        }

        private void LoadPartsComboBox()
        {
            dtParts = garageBUS.GetParts();
            cboPhuTung.DisplayMember = "tenphutung";
            cboPhuTung.ValueMember = "maphutung";
            cboPhuTung.DataSource = dtParts;
        }

        private void BtnLookup_Click(object sender, EventArgs e)
        {
            string bienSo = txtBienSoSearch.Text.Trim();
            if (string.IsNullOrEmpty(bienSo))
            {
                MessageBox.Show("Vui lòng nhập biển số xe để tra cứu!");
                return;
            }

            DataRow carRow = garageBUS.LookupCar(bienSo);
            if (carRow != null)
            {
                lblCarInfoDisplay.Text = $"Chủ xe: {carRow["tenkh"]} | SĐT: {carRow["dienthoai"]} | Địa chỉ: {carRow["diachi"]}\n" +
                                         $"Biển số: {carRow["bienso"]} | Hiệu xe: {carRow["hieuxe"]} | Năm SX: {carRow["namsanxuat"]}";
                grpNewCar.Enabled = false;
                txtTicketCar.Text = carRow["bienso"].ToString();
            }
            else
            {
                lblCarInfoDisplay.Text = "Không tìm thấy xe trong hệ thống! Vui lòng nhập thông tin bên dưới để đăng ký mới.";
                grpNewCar.Enabled = true;
                txtTicketCar.Text = bienSo;
            }
        }

        private void BtnRegisterCar_Click(object sender, EventArgs e)
        {
            try
            {
                KhachHangDTO kh = new KhachHangDTO
                {
                    TenKH = txtTenKH.Text.Trim(),
                    DienThoai = txtDienThoai.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim()
                };

                XeDTO xe = new XeDTO
                {
                    BienSo = txtBienSoSearch.Text.Trim(),
                    HieuXe = txtHieuXe.Text.Trim(),
                    NamSanXuat = int.TryParse(txtNamSX.Text, out int n) ? n : 2026
                };

                if (garageBUS.RegisterCarAndOwner(kh, xe))
                {
                    MessageBox.Show("Đăng ký thành công chủ xe và xe mới!");
                    BtnLookup_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng ký: " + ex.Message);
            }
        }

        private void BtnAddDetail_Click(object sender, EventArgs e)
        {
            if (cboPhuTung.SelectedValue != null && int.TryParse(cboPhuTung.SelectedValue.ToString(), out int maPT))
            {
                DataRow[] rows = dtParts.Select($"maphutung = {maPT}");
                if (rows.Length > 0)
                {
                    DataRow ptRow = rows[0];
                    string tenPT = ptRow["tenphutung"].ToString();
                    decimal donGia = Convert.ToDecimal(ptRow["dongia"]);
                    int soLuong = int.TryParse(txtSoLuong.Text, out int s) ? s : 1;
                    decimal tienCong = decimal.TryParse(txtTienCong.Text, out decimal t) ? t : 0;

                    currentDetails.Add(new ChiTietSuaChuaDTO
                    {
                        MaPhuTung = maPT,
                        TenPhuTung = tenPT,
                        SoLuong = soLuong,
                        DonGia = donGia,
                        TienCong = tienCong
                    });

                    RefreshDetailsGrid();
                }
            }
        }

        private void RefreshDetailsGrid()
        {
            dgvDetails.DataSource = null;
            dgvDetails.DataSource = currentDetails;

            decimal total = 0;
            foreach (var d in currentDetails)
            {
                total += d.ThanhTien;
            }
            lblTotalTicket.Text = $"Tổng tiền: {total:N0} VNĐ";
        }

        private void BtnSaveTicket_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTicketCar.Text))
            {
                MessageBox.Show("Vui lòng nhập biển số xe lập phiếu!");
                return;
            }

            if (currentDetails.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một phụ tùng / dịch vụ!");
                return;
            }

            try
            {
                PhieuSuaChuaDTO ticket = new PhieuSuaChuaDTO
                {
                    BienSo = txtTicketCar.Text.Trim(),
                    NoiDungSua = txtNoiDung.Text.Trim()
                };

                if (garageBUS.SaveRepairTicket(ticket, currentDetails))
                {
                    MessageBox.Show("Lập phiếu sửa chữa và trừ tồn kho thành công (Transaction Committed)!");
                    currentDetails.Clear();
                    RefreshDetailsGrid();
                    LoadPartsComboBox();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Transaction Rollback: " + ex.Message, "Cảnh Báo Tồn Kho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLoadUnpaid_Click(object sender, EventArgs e)
        {
            dgvUnpaidTickets.DataSource = garageBUS.GetPendingPaymentTickets();
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {
            if (dgvUnpaidTickets.CurrentRow != null && dgvUnpaidTickets.CurrentRow.Cells["maphieu"].Value != null)
            {
                int maPhieu = Convert.ToInt32(dgvUnpaidTickets.CurrentRow.Cells["maphieu"].Value);
                if (garageBUS.PayTicket(maPhieu))
                {
                    MessageBox.Show($"Đã hoàn tất thanh toán cho Phiếu sửa chữa #{maPhieu}!");
                    BtnLoadUnpaid_Click(sender, e);
                }
            }
        }
    }
}