using System;
using System.Windows.Forms;

namespace Mod5_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddTask_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTask.Text))
            {
                ListViewItem item = new ListViewItem(txtTask.Text);
                item.SubItems.Add("Не выполнено");
                lstTasks.Items.Add(item);
                txtTask.Clear();
            }
            else
                MessageBox.Show("Введите задачу!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnDelTask_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lstTasks.SelectedItems)
                     lstTasks.Items.Remove(item);
            }
            else
                MessageBox.Show("Выберите задачу для удаления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnMarkAsDone_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lstTasks.SelectedItems)
                {
                    item.SubItems[1].Text = "Выполнено";
                    item.Font = new System.Drawing.Font(item.Font, System.Drawing.FontStyle.Strikeout);
                }
            }
            else
                MessageBox.Show("Выберите задачу для отметки как выполненную!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}