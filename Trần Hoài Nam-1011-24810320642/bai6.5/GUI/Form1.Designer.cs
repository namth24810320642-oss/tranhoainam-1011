namespace KaraokeManagement.GUI
{
    partial class FormKaraoke
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
            this.pnlRoomGrid = new System.Windows.Forms.FlowLayoutPanel();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.lblRoomTitle = new System.Windows.Forms.Label();
            this.lblGioVao = new System.Windows.Forms.Label();
            this.lblDichVu = new System.Windows.Forms.Label();
            this.cboDichVu = new System.Windows.Forms.ComboBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.btnAddService = new System.Windows.Forms.Button();
            this.dgvServices = new System.Windows.Forms.DataGridView();
            this.lblTienPhong = new System.Windows.Forms.Label();
            this.lblTienDichVu = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.grpLegend = new System.Windows.Forms.GroupBox();
            this.lblLegendGreen = new System.Windows.Forms.Label();
            this.lblLegendRed = new System.Windows.Forms.Label();

            this.grpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).BeginInit();
            this.grpLegend.SuspendLayout();
            this.SuspendLayout();

            // pnlRoomGrid
            this.pnlRoomGrid.AutoScroll = true;
            this.pnlRoomGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlRoomGrid.Location = new System.Drawing.Point(15, 60);
            this.pnlRoomGrid.Name = "pnlRoomGrid";
            this.pnlRoomGrid.Size = new System.Drawing.Size(550, 670);
            this.pnlRoomGrid.TabIndex = 0;

            // grpLegend
            this.grpLegend.Controls.Add(this.lblLegendGreen);
            this.grpLegend.Controls.Add(this.lblLegendRed);
            this.grpLegend.Location = new System.Drawing.Point(15, 5);
            this.grpLegend.Name = "grpLegend";
            this.grpLegend.Size = new System.Drawing.Size(550, 50);
            this.grpLegend.TabIndex = 1;
            this.grpLegend.TabStop = false;
            this.grpLegend.Text = "Trạng Thái Phòng";

            // lblLegendGreen
            this.lblLegendGreen.BackColor = System.Drawing.Color.LightGreen;
            this.lblLegendGreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLegendGreen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLegendGreen.Location = new System.Drawing.Point(50, 18);
            this.lblLegendGreen.Name = "lblLegendGreen";
            this.lblLegendGreen.Size = new System.Drawing.Size(180, 25);
            this.lblLegendGreen.TabIndex = 0;
            this.lblLegendGreen.Text = "Xanh: Phòng Trống";
            this.lblLegendGreen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblLegendRed
            this.lblLegendRed.BackColor = System.Drawing.Color.Salmon;
            this.lblLegendRed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLegendRed.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLegendRed.Location = new System.Drawing.Point(300, 18);
            this.lblLegendRed.Name = "lblLegendRed";
            this.lblLegendRed.Size = new System.Drawing.Size(180, 25);
            this.lblLegendRed.TabIndex = 1;
            this.lblLegendRed.Text = "Đỏ: Đang Hát";
            this.lblLegendRed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // grpDetail
            this.grpDetail.Controls.Add(this.lblRoomTitle);
            this.grpDetail.Controls.Add(this.lblGioVao);
            this.grpDetail.Controls.Add(this.lblDichVu);
            this.grpDetail.Controls.Add(this.cboDichVu);
            this.grpDetail.Controls.Add(this.lblSoLuong);
            this.grpDetail.Controls.Add(this.numSoLuong);
            this.grpDetail.Controls.Add(this.btnAddService);
            this.grpDetail.Controls.Add(this.dgvServices);
            this.grpDetail.Controls.Add(this.lblTienPhong);
            this.grpDetail.Controls.Add(this.lblTienDichVu);
            this.grpDetail.Controls.Add(this.lblTongTien);
            this.grpDetail.Controls.Add(this.btnCheckout);
            this.grpDetail.Location = new System.Drawing.Point(580, 5);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Size = new System.Drawing.Size(600, 725);
            this.grpDetail.TabIndex = 2;
            this.grpDetail.TabStop = false;
            this.grpDetail.Text = "Chi Tiết Sử Dụng & Gọi Dịch Vụ";

            // lblRoomTitle
            this.lblRoomTitle.AutoSize = true;
            this.lblRoomTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRoomTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblRoomTitle.Location = new System.Drawing.Point(20, 30);
            this.lblRoomTitle.Name = "lblRoomTitle";
            this.lblRoomTitle.Size = new System.Drawing.Size(220, 28);
            this.lblRoomTitle.TabIndex = 0;
            this.lblRoomTitle.Text = "Chưa Chọn Phòng Hát";

            // lblGioVao
            this.lblGioVao.AutoSize = true;
            this.lblGioVao.Location = new System.Drawing.Point(20, 65);
            this.lblGioVao.Name = "lblGioVao";
            this.lblGioVao.Size = new System.Drawing.Size(81, 16);
            this.lblGioVao.TabIndex = 1;
            this.lblGioVao.Text = "Giờ Vào: --:--";

            // lblDichVu
            this.lblDichVu.AutoSize = true;
            this.lblDichVu.Location = new System.Drawing.Point(20, 105);
            this.lblDichVu.Name = "lblDichVu";
            this.lblDichVu.Size = new System.Drawing.Size(83, 16);
            this.lblDichVu.TabIndex = 2;
            this.lblDichVu.Text = "Chọn Dịch Vụ:";

            // cboDichVu
            this.cboDichVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDichVu.FormattingEnabled = true;
            this.cboDichVu.Location = new System.Drawing.Point(110, 102);
            this.cboDichVu.Name = "cboDichVu";
            this.cboDichVu.Size = new System.Drawing.Size(200, 24);
            this.cboDichVu.TabIndex = 3;

            // lblSoLuong
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(325, 105);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(23, 16);
            this.lblSoLuong.TabIndex = 4;
            this.lblSoLuong.Text = "SL:";

            // numSoLuong
            this.numSoLuong.Location = new System.Drawing.Point(355, 103);
            this.numSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(60, 22);
            this.numSoLuong.TabIndex = 5;
            this.numSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // btnAddService
            this.btnAddService.Location = new System.Drawing.Point(430, 100);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(150, 27);
            this.btnAddService.TabIndex = 6;
            this.btnAddService.Text = "+ Gọi Dịch Vụ";
            this.btnAddService.UseVisualStyleBackColor = true;
            this.btnAddService.Click += new System.EventHandler(this.BtnAddService_Click);

            // dgvServices
            this.dgvServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServices.Location = new System.Drawing.Point(20, 140);
            this.dgvServices.Name = "dgvServices";
            this.dgvServices.ReadOnly = true;
            this.dgvServices.RowHeadersWidth = 51;
            this.dgvServices.Size = new System.Drawing.Size(560, 430);
            this.dgvServices.TabIndex = 7;

            // lblTienPhong
            this.lblTienPhong.AutoSize = true;
            this.lblTienPhong.Location = new System.Drawing.Point(20, 585);
            this.lblTienPhong.Name = "lblTienPhong";
            this.lblTienPhong.Size = new System.Drawing.Size(130, 16);
            this.lblTienPhong.TabIndex = 8;
            this.lblTienPhong.Text = "Tạm Tính Tiền Phòng: 0 VNĐ";

            // lblTienDichVu
            this.lblTienDichVu.AutoSize = true;
            this.lblTienDichVu.Location = new System.Drawing.Point(20, 610);
            this.lblTienDichVu.Name = "lblTienDichVu";
            this.lblTienDichVu.Size = new System.Drawing.Size(134, 16);
            this.lblTienDichVu.TabIndex = 9;
            this.lblTienDichVu.Text = "Tổng Tiền Dịch Vụ: 0 VNĐ";

            // lblTongTien
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.Red;
            this.lblTongTien.Location = new System.Drawing.Point(20, 635);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(184, 25);
            this.lblTongTien.TabIndex = 10;
            this.lblTongTien.Text = "Tổng Thanh Toán: 0 VNĐ";

            // btnCheckout
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCheckout.Location = new System.Drawing.Point(340, 665);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(240, 45);
            this.btnCheckout.TabIndex = 11;
            this.btnCheckout.Text = "Thanh Toán & Kết Thúc (SqlTransaction)";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.BtnCheckout_Click);

            // FormKaraoke
            this.ClientSize = new System.Drawing.Size(1195, 745);
            this.Controls.Add(this.grpLegend);
            this.Controls.Add(this.pnlRoomGrid);
            this.Controls.Add(this.grpDetail);
            this.Name = "FormKaraoke";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Đặt phòng & Dịch vụ Karaoke";
            this.grpLegend.ResumeLayout(false);
            this.grpDetail.ResumeLayout(false);
            this.grpDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.FlowLayoutPanel pnlRoomGrid;
        private System.Windows.Forms.GroupBox grpLegend;
        private System.Windows.Forms.Label lblLegendGreen;
        private System.Windows.Forms.Label lblLegendRed;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.Label lblRoomTitle;
        private System.Windows.Forms.Label lblGioVao;
        private System.Windows.Forms.Label lblDichVu;
        private System.Windows.Forms.ComboBox cboDichVu;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Button btnAddService;
        private System.Windows.Forms.DataGridView dgvServices;
        private System.Windows.Forms.Label lblTienPhong;
        private System.Windows.Forms.Label lblTienDichVu;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Button btnCheckout;
    }
}