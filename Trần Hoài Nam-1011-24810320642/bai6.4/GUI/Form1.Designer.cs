namespace GarageManagement.GUI
{
    partial class FormGarage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabReception = new System.Windows.Forms.TabPage();
            this.lblBienSoSearch = new System.Windows.Forms.Label();
            this.txtBienSoSearch = new System.Windows.Forms.TextBox();
            this.btnLookup = new System.Windows.Forms.Button();
            this.grpCarInfo = new System.Windows.Forms.GroupBox();
            this.lblCarInfoDisplay = new System.Windows.Forms.Label();
            this.grpNewCar = new System.Windows.Forms.GroupBox();
            this.lblTenKH = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.lblDienThoai = new System.Windows.Forms.Label();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblHieuXe = new System.Windows.Forms.Label();
            this.txtHieuXe = new System.Windows.Forms.TextBox();
            this.lblNamSX = new System.Windows.Forms.Label();
            this.txtNamSX = new System.Windows.Forms.TextBox();
            this.btnRegisterCar = new System.Windows.Forms.Button();
            this.tabRepairTicket = new System.Windows.Forms.TabPage();
            this.lblTicketCar = new System.Windows.Forms.Label();
            this.txtTicketCar = new System.Windows.Forms.TextBox();
            this.lblNoiDung = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.cboPhuTung = new System.Windows.Forms.ComboBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.lblTienCong = new System.Windows.Forms.Label();
            this.txtTienCong = new System.Windows.Forms.TextBox();
            this.btnAddDetail = new System.Windows.Forms.Button();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.btnSaveTicket = new System.Windows.Forms.Button();
            this.lblTotalTicket = new System.Windows.Forms.Label();
            this.tabCheckout = new System.Windows.Forms.TabPage();
            this.btnLoadUnpaid = new System.Windows.Forms.Button();
            this.dgvUnpaidTickets = new System.Windows.Forms.DataGridView();
            this.btnPay = new System.Windows.Forms.Button();

            this.tabControl1.SuspendLayout();
            this.tabReception.SuspendLayout();
            this.grpCarInfo.SuspendLayout();
            this.grpNewCar.SuspendLayout();
            this.tabRepairTicket.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.tabCheckout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnpaidTickets)).BeginInit();
            this.SuspendLayout();

            // tabControl1
            this.tabControl1.Controls.Add(this.tabReception);
            this.tabControl1.Controls.Add(this.tabRepairTicket);
            this.tabControl1.Controls.Add(this.tabCheckout);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1000, 650);
            this.tabControl1.TabIndex = 0;

            // tabReception
            this.tabReception.Controls.Add(this.lblBienSoSearch);
            this.tabReception.Controls.Add(this.txtBienSoSearch);
            this.tabReception.Controls.Add(this.btnLookup);
            this.tabReception.Controls.Add(this.grpCarInfo);
            this.tabReception.Controls.Add(this.grpNewCar);
            this.tabReception.Location = new System.Drawing.Point(4, 25);
            this.tabReception.Name = "tabReception";
            this.tabReception.Size = new System.Drawing.Size(992, 621);
            this.tabReception.TabIndex = 0;
            this.tabReception.Text = "Tiếp nhận Xe & Chủ xe";
            this.tabReception.UseVisualStyleBackColor = true;

            // lblBienSoSearch
            this.lblBienSoSearch.AutoSize = true;
            this.lblBienSoSearch.Location = new System.Drawing.Point(20, 25);
            this.lblBienSoSearch.Name = "lblBienSoSearch";
            this.lblBienSoSearch.Size = new System.Drawing.Size(108, 16);
            this.lblBienSoSearch.Text = "Nhập Biển Số Xe:";

            // txtBienSoSearch
            this.txtBienSoSearch.Location = new System.Drawing.Point(140, 22);
            this.txtBienSoSearch.Name = "txtBienSoSearch";
            this.txtBienSoSearch.Size = new System.Drawing.Size(180, 22);
            this.txtBienSoSearch.TabIndex = 0;

            // btnLookup
            this.btnLookup.Location = new System.Drawing.Point(340, 20);
            this.btnLookup.Name = "btnLookup";
            this.btnLookup.Size = new System.Drawing.Size(140, 27);
            this.btnLookup.TabIndex = 1;
            this.btnLookup.Text = "Tra cứu (SqlParameter)";
            this.btnLookup.UseVisualStyleBackColor = true;
            this.btnLookup.Click += new System.EventHandler(this.BtnLookup_Click);

            // grpCarInfo
            this.grpCarInfo.Controls.Add(this.lblCarInfoDisplay);
            this.grpCarInfo.Location = new System.Drawing.Point(20, 70);
            this.grpCarInfo.Name = "grpCarInfo";
            this.grpCarInfo.Size = new System.Drawing.Size(940, 100);
            this.grpCarInfo.TabIndex = 2;
            this.grpCarInfo.TabStop = false;
            this.grpCarInfo.Text = "Thông tin xe hiện tại trong hệ thống";

            // lblCarInfoDisplay
            this.lblCarInfoDisplay.AutoSize = true;
            this.lblCarInfoDisplay.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCarInfoDisplay.Location = new System.Drawing.Point(20, 35);
            this.lblCarInfoDisplay.Name = "lblCarInfoDisplay";
            this.lblCarInfoDisplay.Size = new System.Drawing.Size(200, 21);
            this.lblCarInfoDisplay.TabIndex = 0;
            this.lblCarInfoDisplay.Text = "Vui lòng nhập biển số tra cứu...";

            // grpNewCar
            this.grpNewCar.Controls.Add(this.lblTenKH);
            this.grpNewCar.Controls.Add(this.txtTenKH);
            this.grpNewCar.Controls.Add(this.lblDienThoai);
            this.grpNewCar.Controls.Add(this.txtDienThoai);
            this.grpNewCar.Controls.Add(this.lblDiaChi);
            this.grpNewCar.Controls.Add(this.txtDiaChi);
            this.grpNewCar.Controls.Add(this.lblHieuXe);
            this.grpNewCar.Controls.Add(this.txtHieuXe);
            this.grpNewCar.Controls.Add(this.lblNamSX);
            this.grpNewCar.Controls.Add(this.txtNamSX);
            this.grpNewCar.Controls.Add(this.btnRegisterCar);
            this.grpNewCar.Location = new System.Drawing.Point(20, 190);
            this.grpNewCar.Name = "grpNewCar";
            this.grpNewCar.Size = new System.Drawing.Size(940, 400);
            this.grpNewCar.TabIndex = 3;
            this.grpNewCar.TabStop = false;
            this.grpNewCar.Text = "Đăng ký Xe mới & Chủ xe";

            // lblTenKH
            this.lblTenKH.AutoSize = true;
            this.lblTenKH.Location = new System.Drawing.Point(20, 40);
            this.lblTenKH.Name = "lblTenKH";
            this.lblTenKH.Size = new System.Drawing.Size(93, 16);
            this.lblTenKH.Text = "Tên Khách Hàng:";

            // txtTenKH
            this.txtTenKH.Location = new System.Drawing.Point(140, 37);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(260, 22);
            this.txtTenKH.TabIndex = 0;

            // lblDienThoai
            this.lblDienThoai.AutoSize = true;
            this.lblDienThoai.Location = new System.Drawing.Point(440, 40);
            this.lblDienThoai.Name = "lblDienThoai";
            this.lblDienThoai.Size = new System.Drawing.Size(75, 16);
            this.lblDienThoai.Text = "Điện Thoại:";

            // txtDienThoai
            this.txtDienThoai.Location = new System.Drawing.Point(540, 37);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(200, 22);
            this.txtDienThoai.TabIndex = 1;

            // lblDiaChi
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(20, 85);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(52, 16);
            this.lblDiaChi.Text = "Địa Chỉ:";

            // txtDiaChi
            this.txtDiaChi.Location = new System.Drawing.Point(140, 82);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(600, 22);
            this.txtDiaChi.TabIndex = 2;

            // lblHieuXe
            this.lblHieuXe.AutoSize = true;
            this.lblHieuXe.Location = new System.Drawing.Point(20, 130);
            this.lblHieuXe.Name = "lblHieuXe";
            this.lblHieuXe.Size = new System.Drawing.Size(58, 16);
            this.lblHieuXe.Text = "Hiệu Xe:";

            // txtHieuXe
            this.txtHieuXe.Location = new System.Drawing.Point(140, 127);
            this.txtHieuXe.Name = "txtHieuXe";
            this.txtHieuXe.Size = new System.Drawing.Size(260, 22);
            this.txtHieuXe.TabIndex = 3;

            // lblNamSX
            this.lblNamSX.AutoSize = true;
            this.lblNamSX.Location = new System.Drawing.Point(440, 130);
            this.lblNamSX.Name = "lblNamSX";
            this.lblNamSX.Size = new System.Drawing.Size(95, 16);
            this.lblNamSX.Text = "Năm Sản Xuất:";

            // txtNamSX
            this.txtNamSX.Location = new System.Drawing.Point(540, 127);
            this.txtNamSX.Name = "txtNamSX";
            this.txtNamSX.Size = new System.Drawing.Size(200, 22);
            this.txtNamSX.TabIndex = 4;

            // btnRegisterCar
            this.btnRegisterCar.Location = new System.Drawing.Point(140, 175);
            this.btnRegisterCar.Name = "btnRegisterCar";
            this.btnRegisterCar.Size = new System.Drawing.Size(200, 35);
            this.btnRegisterCar.TabIndex = 5;
            this.btnRegisterCar.Text = "Đăng Ký Tiếp Nhận";
            this.btnRegisterCar.UseVisualStyleBackColor = true;
            this.btnRegisterCar.Click += new System.EventHandler(this.BtnRegisterCar_Click);

            // tabRepairTicket
            this.tabRepairTicket.Controls.Add(this.lblTicketCar);
            this.tabRepairTicket.Controls.Add(this.txtTicketCar);
            this.tabRepairTicket.Controls.Add(this.lblNoiDung);
            this.tabRepairTicket.Controls.Add(this.txtNoiDung);
            this.tabRepairTicket.Controls.Add(this.cboPhuTung);
            this.tabRepairTicket.Controls.Add(this.lblSoLuong);
            this.tabRepairTicket.Controls.Add(this.txtSoLuong);
            this.tabRepairTicket.Controls.Add(this.lblTienCong);
            this.tabRepairTicket.Controls.Add(this.txtTienCong);
            this.tabRepairTicket.Controls.Add(this.btnAddDetail);
            this.tabRepairTicket.Controls.Add(this.dgvDetails);
            this.tabRepairTicket.Controls.Add(this.btnSaveTicket);
            this.tabRepairTicket.Controls.Add(this.lblTotalTicket);
            this.tabRepairTicket.Location = new System.Drawing.Point(4, 25);
            this.tabRepairTicket.Name = "tabRepairTicket";
            this.tabRepairTicket.Size = new System.Drawing.Size(992, 621);
            this.tabRepairTicket.TabIndex = 1;
            this.tabRepairTicket.Text = "Lập Phiếu Sửa Chữa (SqlTransaction)";
            this.tabRepairTicket.UseVisualStyleBackColor = true;

            // lblTicketCar
            this.lblTicketCar.AutoSize = true;
            this.lblTicketCar.Location = new System.Drawing.Point(20, 20);
            this.lblTicketCar.Name = "lblTicketCar";
            this.lblTicketCar.Size = new System.Drawing.Size(58, 16);
            this.lblTicketCar.Text = "Biển Số:";

            // txtTicketCar
            this.txtTicketCar.Location = new System.Drawing.Point(100, 17);
            this.txtTicketCar.Name = "txtTicketCar";
            this.txtTicketCar.Size = new System.Drawing.Size(150, 22);
            this.txtTicketCar.TabIndex = 0;

            // lblNoiDung
            this.lblNoiDung.AutoSize = true;
            this.lblNoiDung.Location = new System.Drawing.Point(280, 20);
            this.lblNoiDung.Name = "lblNoiDung";
            this.lblNoiDung.Size = new System.Drawing.Size(95, 16);
            this.lblNoiDung.Text = "Nội Dung Sửa:";

            // txtNoiDung
            this.txtNoiDung.Location = new System.Drawing.Point(390, 17);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(560, 22);
            this.txtNoiDung.TabIndex = 1;

            // cboPhuTung
            this.cboPhuTung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhuTung.FormattingEnabled = true;
            this.cboPhuTung.Location = new System.Drawing.Point(20, 60);
            this.cboPhuTung.Name = "cboPhuTung";
            this.cboPhuTung.Size = new System.Drawing.Size(250, 24);
            this.cboPhuTung.TabIndex = 2;

            // lblSoLuong
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(290, 63);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(67, 16);
            this.lblSoLuong.Text = "Số Lượng:";

            // txtSoLuong
            this.txtSoLuong.Location = new System.Drawing.Point(365, 60);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(60, 22);
            this.txtSoLuong.TabIndex = 3;
            this.txtSoLuong.Text = "1";

            // lblTienCong
            this.lblTienCong.AutoSize = true;
            this.lblTienCong.Location = new System.Drawing.Point(445, 63);
            this.lblTienCong.Name = "lblTienCong";
            this.lblTienCong.Size = new System.Drawing.Size(71, 16);
            this.lblTienCong.Text = "Tiền Công:";

            // txtTienCong
            this.txtTienCong.Location = new System.Drawing.Point(525, 60);
            this.txtTienCong.Name = "txtTienCong";
            this.txtTienCong.Size = new System.Drawing.Size(120, 22);
            this.txtTienCong.TabIndex = 4;
            this.txtTienCong.Text = "100000";

            // btnAddDetail
            this.btnAddDetail.Location = new System.Drawing.Point(670, 58);
            this.btnAddDetail.Name = "btnAddDetail";
            this.btnAddDetail.Size = new System.Drawing.Size(150, 27);
            this.btnAddDetail.TabIndex = 5;
            this.btnAddDetail.Text = "+ Thêm Phụ Tùng";
            this.btnAddDetail.UseVisualStyleBackColor = true;
            this.btnAddDetail.Click += new System.EventHandler(this.BtnAddDetail_Click);

            // dgvDetails
            this.dgvDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Location = new System.Drawing.Point(20, 100);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowHeadersWidth = 51;
            this.dgvDetails.Size = new System.Drawing.Size(930, 420);
            this.dgvDetails.TabIndex = 6;

            // btnSaveTicket
            this.btnSaveTicket.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveTicket.Location = new System.Drawing.Point(20, 540);
            this.btnSaveTicket.Name = "btnSaveTicket";
            this.btnSaveTicket.Size = new System.Drawing.Size(280, 40);
            this.btnSaveTicket.TabIndex = 7;
            this.btnSaveTicket.Text = "Xác Nhận Lập Phụ Tùng & Trừ Kho";
            this.btnSaveTicket.UseVisualStyleBackColor = true;
            this.btnSaveTicket.Click += new System.EventHandler(this.BtnSaveTicket_Click);

            // lblTotalTicket
            this.lblTotalTicket.AutoSize = true;
            this.lblTotalTicket.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalTicket.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTotalTicket.Location = new System.Drawing.Point(600, 547);
            this.lblTotalTicket.Name = "lblTotalTicket";
            this.lblTotalTicket.Size = new System.Drawing.Size(147, 25);
            this.lblTotalTicket.TabIndex = 8;
            this.lblTotalTicket.Text = "Tổng tiền: 0 VNĐ";

            // tabCheckout
            this.tabCheckout.Controls.Add(this.btnLoadUnpaid);
            this.tabCheckout.Controls.Add(this.dgvUnpaidTickets);
            this.tabCheckout.Controls.Add(this.btnPay);
            this.tabCheckout.Location = new System.Drawing.Point(4, 25);
            this.tabCheckout.Name = "tabCheckout";
            this.tabCheckout.Size = new System.Drawing.Size(992, 621);
            this.tabCheckout.TabIndex = 2;
            this.tabCheckout.Text = "Thanh Toán & Hóa Đơn";
            this.tabCheckout.UseVisualStyleBackColor = true;

            // btnLoadUnpaid
            this.btnLoadUnpaid.Location = new System.Drawing.Point(20, 15);
            this.btnLoadUnpaid.Name = "btnLoadUnpaid";
            this.btnLoadUnpaid.Size = new System.Drawing.Size(220, 30);
            this.btnLoadUnpaid.TabIndex = 0;
            this.btnLoadUnpaid.Text = "Tải Danh Sách Chưa Thanh Toán";
            this.btnLoadUnpaid.UseVisualStyleBackColor = true;
            this.btnLoadUnpaid.Click += new System.EventHandler(this.BtnLoadUnpaid_Click);

            // dgvUnpaidTickets
            this.dgvUnpaidTickets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUnpaidTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnpaidTickets.Location = new System.Drawing.Point(20, 60);
            this.dgvUnpaidTickets.MultiSelect = false;
            this.dgvUnpaidTickets.Name = "dgvUnpaidTickets";
            this.dgvUnpaidTickets.ReadOnly = true;
            this.dgvUnpaidTickets.RowHeadersWidth = 51;
            this.dgvUnpaidTickets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUnpaidTickets.Size = new System.Drawing.Size(940, 480);
            this.dgvUnpaidTickets.TabIndex = 1;

            // btnPay
            this.btnPay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPay.Location = new System.Drawing.Point(20, 555);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(260, 40);
            this.btnPay.TabIndex = 2;
            this.btnPay.Text = "Xác Nhận Thanh Toán";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.BtnPay_Click);

            // FormGarage
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormGarage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Garage & Bảo dưỡng Xe ô tô";
            this.tabControl1.ResumeLayout(false);
            this.tabReception.ResumeLayout(false);
            this.tabReception.PerformLayout();
            this.grpCarInfo.ResumeLayout(false);
            this.grpCarInfo.PerformLayout();
            this.grpNewCar.ResumeLayout(false);
            this.grpNewCar.PerformLayout();
            this.tabRepairTicket.ResumeLayout(false);
            this.tabRepairTicket.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.tabCheckout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnpaidTickets)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabReception;
        private System.Windows.Forms.Label lblBienSoSearch;
        private System.Windows.Forms.TextBox txtBienSoSearch;
        private System.Windows.Forms.Button btnLookup;
        private System.Windows.Forms.GroupBox grpCarInfo;
        private System.Windows.Forms.Label lblCarInfoDisplay;
        private System.Windows.Forms.GroupBox grpNewCar;
        private System.Windows.Forms.Label lblTenKH;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label lblDienThoai;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblHieuXe;
        private System.Windows.Forms.TextBox txtHieuXe;
        private System.Windows.Forms.Label lblNamSX;
        private System.Windows.Forms.TextBox txtNamSX;
        private System.Windows.Forms.Button btnRegisterCar;
        private System.Windows.Forms.TabPage tabRepairTicket;
        private System.Windows.Forms.Label lblTicketCar;
        private System.Windows.Forms.TextBox txtTicketCar;
        private System.Windows.Forms.Label lblNoiDung;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.ComboBox cboPhuTung;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label lblTienCong;
        private System.Windows.Forms.TextBox txtTienCong;
        private System.Windows.Forms.Button btnAddDetail;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Button btnSaveTicket;
        private System.Windows.Forms.Label lblTotalTicket;
        private System.Windows.Forms.TabPage tabCheckout;
        private System.Windows.Forms.Button btnLoadUnpaid;
        private System.Windows.Forms.DataGridView dgvUnpaidTickets;
        private System.Windows.Forms.Button btnPay;
    }
}