using CallOffModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallOffsForm
{
    public partial class Form1 : Form
    {
        Double upperLimit;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            upperLimit = 250;
            textBox9.Text = upperLimit.ToString();
            CallOff off1 = new CallOff(DateTime.Today, 150);
            CallOff off2 = new CallOff(DateTime.Today, 90);
            CallOff off3 = new CallOff(DateTime.Today, 10);
            BindingList<CallOff> callOffs = new BindingList<CallOff>();
            callOffs.Add(off1);
            callOffs.Add(off3);
            callOffs.Add(off2);
            dataGridView1.DataSource = callOffs.Select(myClass => new { myClass.CallOffDate, myClass.Amount }).ToList();

            dataGridView1.DataSource = callOffs;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView cell = (DataGridView)sender;
             valueBeforeEdit = Double.Parse(cell.CurrentCell.Value.ToString());
        }
        double valueBeforeEdit;
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView cell = (DataGridView)sender;
            
            if(isValidAmount(valueBeforeEdit, Double.Parse(cell.CurrentCell.Value.ToString()),cell.CurrentCell.ColumnIndex))
            {
                textBox9.Text = ColumnSum(dataGridView1, 1).ToString();
            }
            else
            {
                MessageBox.Show("There is not enough resource available for this call off.");
                cell.CurrentCell.Value = valueBeforeEdit;
            }
        }
        public bool isValidAmount(Double valueBeforeEdit, Double valueAfterEdit, int columnIndex)
        {
                var sum = ColumnSum(dataGridView1, columnIndex);
                if(sum>upperLimit)
                {
                    Console.WriteLine("Arrgghhhh fuckitall");
                   return false;
                }
                else
                {
                    return true;
                }
            
        }
        private double ColumnSum(DataGridView dgv, int columnIndex)
        {
            double sum = 0;
            for (int i = 0; i < dgv.Rows.Count; ++i)
            {
                double d = 0;
                Double.TryParse(dgv.Rows[i].Cells[columnIndex].Value.ToString(), out d);
                sum += d;
            }
            return sum;
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            MessageBox.Show("Dafuck?");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
        }
    }
}
