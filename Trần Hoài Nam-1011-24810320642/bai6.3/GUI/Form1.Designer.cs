namespace ProjectTaskManagement.GUI
{
    partial class FormMain
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
            this.tabListView = new System.Windows.Forms.TabPage();
            this.cboDuAn = new System.Windows.Forms.ComboBox();
            this.cboTrangThaiFilter = new System.Windows.Forms.ComboBox();
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.btnAssign = new System.Windows.Forms.Button();
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.tabKanban = new System.Windows.Forms.TabPage();
            this.kanbanLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tabReport = new System.Windows.Forms.TabPage();
            this.btnRefreshReport = new System.Windows.Forms.Button();
            this.dgvOverdueReport = new System.Windows.Forms.DataGridView();
            this.lblMember = new System.Windows.Forms.Label();
            this.txtMemberId = new System.Windows.Forms.TextBox();
            this.lblProject = new System.Windows.Forms.Label();
            this.txtProjectId = new System.Windows.Forms.TextBox();
            this.btnCalcRate = new System.Windows.Forms.Button();
            this.lblCompletionRate = new System.Windows.Forms.Label();

            this.tabControl1.SuspendLayout();
            this.tabListView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.tabKanban.SuspendLayout();
            this.tabReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverdueReport)).BeginInit();
            this.SuspendLayout();

            // tabControl1
            this.tabControl1.Controls.Add(this.tabListView);
            this.tabControl1.Controls.Add(this.tabKanban);
            this.tabControl1.Controls.Add(this.tabReport);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1200, 750);
            this.tabControl1.TabIndex = 0;

            // tabListView
            this.tabListView.Controls.Add(this.cboDuAn);
            this.tabListView.Controls.Add(this.cboTrangThaiFilter);
            this.tabListView.Controls.Add(this.btnChangeStatus);
            this.tabListView.Controls.Add(this.btnAssign);
            this.tabListView.Controls.Add(this.dgvTasks);
            this.tabListView.Location = new System.Drawing.Point(4, 25);
            this.tabListView.Name = "tabListView";
            this.tabListView.Padding = new System.Windows.Forms.Padding(3);
            this.tabListView.Size = new System.Drawing.Size(1192, 721);
            this.tabListView.TabIndex = 0;
            this.tabListView.Text = "Danh sách công việc & Phân công";
            this.tabListView.UseVisualStyleBackColor = true;

            // cboDuAn
            this.cboDuAn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDuAn.FormattingEnabled = true;
            this.cboDuAn.Location = new System.Drawing.Point(15, 15);
            this.cboDuAn.Name = "cboDuAn";
            this.cboDuAn.Size = new System.Drawing.Size(200, 24);
            this.cboDuAn.TabIndex = 0;
            this.cboDuAn.SelectedIndexChanged += new System.EventHandler(this.CboDuAn_SelectedIndexChanged);

            // cboTrangThaiFilter
            this.cboTrangThaiFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThaiFilter.FormattingEnabled = true;
            this.cboTrangThaiFilter.Items.AddRange(new object[] { "tất cả", "To Do", "In Progress", "Review", "Done" });
            this.cboTrangThaiFilter.Location = new System.Drawing.Point(230, 15);
            this.cboTrangThaiFilter.Name = "cboTrangThaiFilter";
            this.cboTrangThaiFilter.Size = new System.Drawing.Size(150, 24);
            this.cboTrangThaiFilter.TabIndex = 1;
            this.cboTrangThaiFilter.SelectedIndexChanged += new System.EventHandler(this.CboTrangThaiFilter_SelectedIndexChanged);

            // btnChangeStatus
            this.btnChangeStatus.Location = new System.Drawing.Point(400, 13);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Size = new System.Drawing.Size(140, 28);
            this.btnChangeStatus.TabIndex = 2;
            this.btnChangeStatus.Text = "Chuyển trạng thái";
            this.btnChangeStatus.UseVisualStyleBackColor = true;
            this.btnChangeStatus.Click += new System.EventHandler(this.BtnChangeStatus_Click);

            // btnAssign
            this.btnAssign.Location = new System.Drawing.Point(550, 13);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(130, 28);
            this.btnAssign.TabIndex = 3;
            this.btnAssign.Text = "Giao việc cho TV";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.BtnAssign_Click);

            // dgvTasks
            this.dgvTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasks.Location = new System.Drawing.Point(15, 50);
            this.dgvTasks.MultiSelect = false;
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.ReadOnly = true;
            this.dgvTasks.RowHeadersWidth = 51;
            this.dgvTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTasks.Size = new System.Drawing.Size(1160, 650);
            this.dgvTasks.TabIndex = 4;

            // tabKanban
            this.tabKanban.Controls.Add(this.kanbanLayout);
            this.tabKanban.Location = new System.Drawing.Point(4, 25);
            this.tabKanban.Name = "tabKanban";
            this.tabKanban.Padding = new System.Windows.Forms.Padding(3);
            this.tabKanban.Size = new System.Drawing.Size(1192, 721);
            this.tabKanban.TabIndex = 1;
            this.tabKanban.Text = "Giao diện Kanban Board";
            this.tabKanban.UseVisualStyleBackColor = true;

            // kanbanLayout
            this.kanbanLayout.ColumnCount = 4;
            this.kanbanLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.kanbanLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.kanbanLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.kanbanLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.kanbanLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kanbanLayout.Location = new System.Drawing.Point(3, 3);
            this.kanbanLayout.Name = "kanbanLayout";
            this.kanbanLayout.RowCount = 1;
            this.kanbanLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kanbanLayout.Size = new System.Drawing.Size(1186, 715);
            this.kanbanLayout.TabIndex = 0;

            // tabReport
            this.tabReport.Controls.Add(this.btnRefreshReport);
            this.tabReport.Controls.Add(this.dgvOverdueReport);
            this.tabReport.Controls.Add(this.lblMember);
            this.tabReport.Controls.Add(this.txtMemberId);
            this.tabReport.Controls.Add(this.lblProject);
            this.tabReport.Controls.Add(this.txtProjectId);
            this.tabReport.Controls.Add(this.btnCalcRate);
            this.tabReport.Controls.Add(this.lblCompletionRate);
            this.tabReport.Location = new System.Drawing.Point(4, 25);
            this.tabReport.Name = "tabReport";
            this.tabReport.Padding = new System.Windows.Forms.Padding(3);
            this.tabReport.Size = new System.Drawing.Size(1192, 721);
            this.tabReport.TabIndex = 2;
            this.tabReport.Text = "Cảnh báo trễ hạn & Báo cáo tỷ lệ";
            this.tabReport.UseVisualStyleBackColor = true;

            // btnRefreshReport
            this.btnRefreshReport.Location = new System.Drawing.Point(15, 15);
            this.btnRefreshReport.Name = "btnRefreshReport";
            this.btnRefreshReport.Size = new System.Drawing.Size(260, 28);
            this.btnRefreshReport.TabIndex = 0;
            this.btnRefreshReport.Text = "Tải danh sách trễ hạn (SqlDataReader)";
            this.btnRefreshReport.UseVisualStyleBackColor = true;
            this.btnRefreshReport.Click += new System.EventHandler(this.BtnRefreshReport_Click);

            // dgvOverdueReport
            this.dgvOverdueReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOverdueReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOverdueReport.Location = new System.Drawing.Point(15, 50);
            this.dgvOverdueReport.Name = "dgvOverdueReport";
            this.dgvOverdueReport.ReadOnly = true;
            this.dgvOverdueReport.RowHeadersWidth = 51;
            this.dgvOverdueReport.Size = new System.Drawing.Size(1160, 450);
            this.dgvOverdueReport.TabIndex = 1;

            // lblMember
            this.lblMember.AutoSize = true;
            this.lblMember.Location = new System.Drawing.Point(15, 520);
            this.lblMember.Name = "lblMember";
            this.lblMember.Size = new System.Drawing.Size(51, 16);
            this.lblMember.TabIndex = 2;
            this.lblMember.Text = "Mã TV:";

            // txtMemberId
            this.txtMemberId.Location = new System.Drawing.Point(70, 517);
            this.txtMemberId.Name = "txtMemberId";
            this.txtMemberId.Size = new System.Drawing.Size(60, 22);
            this.txtMemberId.TabIndex = 3;
            this.txtMemberId.Text = "1";

            // lblProject
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(150, 520);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(52, 16);
            this.lblProject.TabIndex = 4;
            this.lblProject.Text = "Mã DẠ:";

            // txtProjectId
            this.txtProjectId.Location = new System.Drawing.Point(210, 517);
            this.txtProjectId.Name = "txtProjectId";
            this.txtProjectId.Size = new System.Drawing.Size(60, 22);
            this.txtProjectId.TabIndex = 5;
            this.txtProjectId.Text = "1";

            // btnCalcRate
            this.btnCalcRate.Location = new System.Drawing.Point(290, 515);
            this.btnCalcRate.Name = "btnCalcRate";
            this.btnCalcRate.Size = new System.Drawing.Size(230, 28);
            this.btnCalcRate.TabIndex = 6;
            this.btnCalcRate.Text = "Tính % hoàn thành (ExecuteScalar)";
            this.btnCalcRate.UseVisualStyleBackColor = true;
            this.btnCalcRate.Click += new System.EventHandler(this.BtnCalcRate_Click);

            // lblCompletionRate
            this.lblCompletionRate.AutoSize = true;
            this.lblCompletionRate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCompletionRate.Location = new System.Drawing.Point(540, 518);
            this.lblCompletionRate.Name = "lblCompletionRate";
            this.lblCompletionRate.Size = new System.Drawing.Size(100, 23);
            this.lblCompletionRate.TabIndex = 7;
            this.lblCompletionRate.Text = "Tỷ lệ: --%";

            // FormMain
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lý công việc & tiến độ dự án (Kanban & List View)";
            this.tabControl1.ResumeLayout(false);
            this.tabListView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.tabKanban.ResumeLayout(false);
            this.tabReport.ResumeLayout(false);
            this.tabReport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverdueReport)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabListView;
        private System.Windows.Forms.ComboBox cboDuAn;
        private System.Windows.Forms.ComboBox cboTrangThaiFilter;
        private System.Windows.Forms.Button btnChangeStatus;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.DataGridView dgvTasks;
        private System.Windows.Forms.TabPage tabKanban;
        private System.Windows.Forms.TableLayoutPanel kanbanLayout;
        private System.Windows.Forms.TabPage tabReport;
        private System.Windows.Forms.Button btnRefreshReport;
        private System.Windows.Forms.DataGridView dgvOverdueReport;
        private System.Windows.Forms.Label lblMember;
        private System.Windows.Forms.TextBox txtMemberId;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.TextBox txtProjectId;
        private System.Windows.Forms.Button btnCalcRate;
        private System.Windows.Forms.Label lblCompletionRate;
    }
}