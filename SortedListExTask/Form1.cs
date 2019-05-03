using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortedListExTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        SortedList<string, string> Task = new SortedList<string, string>();
        //Datetime as a key

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            try
            {
                //DateTime taskDate = dtpTaskDate.Value.Date;

                if (txtTask.Text == string.Empty)
                {
                    MessageBox.Show("You must enter a task.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Task.ContainsKey(dtpTaskDate.Value.ToShortDateString()))
                {
                    MessageBox.Show("Only one task per day is allowed.");
                }
                else
                {
                    
                    Task.Add(dtpTaskDate.Value.ToShortDateString(), txtTask.Text);
                    lstTasks.Items.Add(dtpTaskDate.Value.ToShortDateString());

                    //Task.Clear();
                    dtpTaskDate.Value = DateTime.Now;
                    #region "wrong" way 
                    //task.Add(taskDate, txtTask.Text)
                    //lstTasks.Items.Add(taskDate)

                    //task.Clear
                    //dtpTaskDate.Value = DateTie.Now

                    //foreach (KeyValuePair<string, string> kvp in Task)
                    //{
                    //    if (!lstTasks.Items.Contains(kvp.Key))
                    //    {
                    //        lstTasks.Items.Add(kvp.Key);

                    //    }

                    //}
                    #endregion
                }

                txtTask.Text = string.Empty;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (lstTasks.SelectedIndex != -1)
                {
                    lblTaskDetails.Text = Task[lstTasks.SelectedItem.ToString()];
                }
                else
                {
                    lblTaskDetails.Text = string.Empty;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            try
            {
                lblTaskDetails.ResetText();

                Task.Remove(lstTasks.SelectedItem.ToString());

                lstTasks.Items.Remove(lstTasks.SelectedItem);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            string allTasks = string.Empty;
            if(Task.Count == 0)
            {
                MessageBox.Show("There is no tasks.");
            }
            for (int i = 0; i <= Task.Count - 1; i++)
            {
                allTasks += $"{Task.Keys[i]} {Task.Values[i]} \n";
            }

            MessageBox.Show(allTasks);

        }
    }


}
