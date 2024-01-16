using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace print
{
    public partial class Form1 : Form
    {
        DataGridView dataGridView1 = new DataGridView();
        string[] row1 = new string[] { "a", "b", "c" };
        string[] row2 = new string[] { "d", "e", "f" };
        public Form1()
        {
            dataGridView1.Columns.Add("Column1", "列1");
            dataGridView1.Columns.Add("Column2", "列2");
            dataGridView1.Columns.Add("Column3", "列3");

            dataGridView1.Rows.Add(row1);
            dataGridView1.Rows.Add(row2);
            InitializeComponent();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
           
            print_frm frm = new print_frm(dataGridView1);
            frm.Show();
        }


    }
}
