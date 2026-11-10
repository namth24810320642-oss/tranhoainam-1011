using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ProjectTaskManagement.BUS;
using ProjectTaskManagement.DTO;

namespace ProjectTaskManagement.GUI
{
    public partial class FormMain : Form
    {
        private DuAnBUS duAnBUS = new DuAnBUS();
        private TaskBUS taskBUS = new TaskBUS();

        private FlowLayoutPanel pnlKanbanToDo;
        private FlowLayoutPanel pnlKanbanInProgress;
        private FlowLayoutPanel pnlKanbanReview;
        private FlowLayoutPanel pnlKanbanDone;

        private bool isInitializing = true;

        public FormMain()
        {
            InitializeComponent();
            SetupKanbanPanels();
            LoadProjects();
            cboTrangThaiFilter.SelectedIndex = 0;
            isInitializing = false;
            RefreshTaskList();
        }

        private void SetupKanbanPanels()
        {
            pnlKanbanToDo = CreateKanbanColumn("TO DO", Color.LightGray);
            pnlKanbanInProgress = CreateKanbanColumn("IN PROGRESS", Color.LightSkyBlue);
            pnlKanbanReview = CreateKanbanColumn("REVIEW", Color.LightGoldenrodYellow);
            pnlKanbanDone = CreateKanbanColumn("DONE", Color.LightGreen);

            kanbanLayout.Controls.Add(pnlKanbanToDo, 0, 0);
            kanbanLayout.Controls.Add(pnlKanbanInProgress, 1, 0);
            kanbanLayout.Controls.Add(pnlKanbanReview, 2, 0);
            kanbanLayout.Controls.Add(pnlKanbanDone, 3, 0);
        }

        private FlowLayoutPanel CreateKanbanColumn(string title, Color headerBg)
        {
            FlowLayoutPanel panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.WhiteSmoke
            };
            Label lblTitle = new Label
            {
                Text = title,
                Width = 260,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = headerBg,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            panel.Controls.Add(lblTitle);
            return panel;
        }

        private void LoadProjects()
        {
            DataTable dt = duAnBUS.GetAllProjects();
            cboDuAn.DisplayMember = "tenduan";
            cboDuAn.ValueMember = "maduan";
            cboDuAn.DataSource = dt;
        }

        private void RefreshTaskList()
        {
            if (isInitializing) return;

            if (cboDuAn.SelectedValue != null && int.TryParse(cboDuAn.SelectedValue.ToString(), out int maDuAn))
            {
                string trangThai = cboTrangThaiFilter.SelectedItem?.ToString() ?? "tất cả";
                DataTable dt = taskBUS.FilterTasks(maDuAn, trangThai);
                dgvTasks.DataSource = dt;
                RenderKanbanBoard(maDuAn);
            }
        }

        private void RenderKanbanBoard(int maDuAn)
        {
            ClearKanbanCards();
            DataTable dtAll = taskBUS.FilterTasks(maDuAn, "tất cả");

            foreach (DataRow row in dtAll.Rows)
            {
                Panel card = new Panel
                {
                    Width = 240,
                    Height = 80,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.White,
                    Margin = new Padding(5)
                };

                Label lblTaskName = new Label
                {
                    Text = row["tentask"].ToString(),
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    Location = new Point(5, 5),
                    AutoSize = true
                };

                Label lblPriority = new Label
                {
                    Text = $"Ưu tiên: {row["douutien"]}",
                    Location = new Point(5, 30),
                    AutoSize = true
                };

                Label lblDeadline = new Label
                {
                    Text = $"Hạn: {Convert.ToDateTime(row["hannop"]):dd/MM/yyyy}",
                    Location = new Point(5, 50),
                    AutoSize = true,
                    ForeColor = Color.DarkRed
                };

                card.Controls.Add(lblTaskName);
                card.Controls.Add(lblPriority);
                card.Controls.Add(lblDeadline);

                string status = row["trangthai"].ToString();
                if (status.Equals("To Do", StringComparison.OrdinalIgnoreCase)) pnlKanbanToDo.Controls.Add(card);
                else if (status.Equals("In Progress", StringComparison.OrdinalIgnoreCase)) pnlKanbanInProgress.Controls.Add(card);
                else if (status.Equals("Review", StringComparison.OrdinalIgnoreCase)) pnlKanbanReview.Controls.Add(card);
                else if (status.Equals("Done", StringComparison.OrdinalIgnoreCase)) pnlKanbanDone.Controls.Add(card);
            }
        }

        private void ClearKanbanCards()
        {
            RemoveCardsFromPanel(pnlKanbanToDo);
            RemoveCardsFromPanel(pnlKanbanInProgress);
            RemoveCardsFromPanel(pnlKanbanReview);
            RemoveCardsFromPanel(pnlKanbanDone);
        }

        private void RemoveCardsFromPanel(FlowLayoutPanel panel)
        {
            for (int i = panel.Controls.Count - 1; i >= 1; i--)
            {
                panel.Controls.RemoveAt(i);
            }
        }

        private void CboDuAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTaskList();
        }

        private void CboTrangThaiFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTaskList();
        }

        private void BtnChangeStatus_Click(object sender, EventArgs e)
        {
            if (dgvTasks.CurrentRow != null && dgvTasks.CurrentRow.Cells["matask"].Value != null)
            {
                int maTask = Convert.ToInt32(dgvTasks.CurrentRow.Cells["matask"].Value);
                string currentStatus = dgvTasks.CurrentRow.Cells["trangthai"].Value.ToString();
                string nextStatus = currentStatus.Equals("To Do", StringComparison.OrdinalIgnoreCase) ? "In Progress" :
                                   currentStatus.Equals("In Progress", StringComparison.OrdinalIgnoreCase) ? "Review" : "Done";

                if (taskBUS.ChangeStatus(maTask, nextStatus))
                {
                    MessageBox.Show($"Đã chuyển trạng thái task #{maTask} thành '{nextStatus}'!");
                    RefreshTaskList();
                }
            }
        }

        private void BtnAssign_Click(object sender, EventArgs e)
        {
            if (dgvTasks.CurrentRow != null && dgvTasks.CurrentRow.Cells["matask"].Value != null)
            {
                int maTask = Convert.ToInt32(dgvTasks.CurrentRow.Cells["matask"].Value);
                int maThanhVien = 1;
                try
                {
                    if (taskBUS.AssignTask(maTask, maThanhVien))
                    {
                        MessageBox.Show($"Đã phân công Task #{maTask} cho Thành viên #{maThanhVien}!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Phân công thất bại hoặc đã tồn tại: " + ex.Message);
                }
            }
        }

        private void BtnRefreshReport_Click(object sender, EventArgs e)
        {
            var list = taskBUS.GetOverdueTasks();
            dgvOverdueReport.DataSource = list;
        }

        private void BtnCalcRate_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtMemberId.Text, out int maTV) && int.TryParse(txtProjectId.Text, out int maDA))
            {
                double rate = taskBUS.GetMemberCompletionRate(maTV, maDA);
                lblCompletionRate.Text = $"Tỷ lệ hoàn thành: {rate:F2}%";
            }
        }
    }
}