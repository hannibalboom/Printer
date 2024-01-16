using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace print
{
    
    public partial class print_frm : Form
    {
        PrintDocument pd = new PrintDocument();
        
        //接收form1的数据
        private DataGridView dataGridViewToPrint;
        public print_frm(DataGridView dataGridView)
        {
            InitializeComponent();
            dataGridViewToPrint = dataGridView;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 获取选中的纸张大小
            string paperSize = comboBox2.SelectedItem.ToString();

            //  根据选中的纸张大小设置PrintDocument的纸张大小
            switch (paperSize)
            {
                case "A4":
                    pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
                    break;
                case "A5":
                    pd.DefaultPageSettings.PaperSize = new PaperSize("A5", 583, 827);
                    break;
                case "B5":
                    pd.DefaultPageSettings.PaperSize = new PaperSize("B5", 693, 984);
                    break;
                case "B6":
                    pd.DefaultPageSettings.PaperSize = new PaperSize("B6", 492, 693);
                    break;
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            pd.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
           // 设置默认纸张大小为A4
            PrintDialog printDialog = new PrintDialog();
        printDialog.Document = pd;

        if (printDialog.ShowDialog() == DialogResult.OK)
        {
              
                pd.Print();
        }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            string paperSize = comboBox2.SelectedItem.ToString();
            switch (paperSize)
            {
                case "A4":
                    pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
                    break;
                case "A5":
                    pd.DefaultPageSettings.PaperSize = new PaperSize("A5", 583, 827);
                    break;
                case "B5":
                    pd.DefaultPageSettings.PaperSize = new PaperSize("B5", 693, 984);
                    break;
                case "B6":
                    pd.DefaultPageSettings.PaperSize = new PaperSize("B6", 492, 693);
                    break;
            }
            // 在打印页面上绘制表格数据
            Bitmap bitmap = new Bitmap(dataGridViewToPrint.Width, dataGridViewToPrint.Height);
            dataGridViewToPrint.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridViewToPrint.Width, dataGridViewToPrint.Height));
            e.PageSettings.PaperSize = new PaperSize("B6", 492, 693);
            e.Graphics.DrawImage(bitmap, new Point(100, 100)); // 调整位置
            Console.WriteLine($"PaperSize Width: {pd.DefaultPageSettings.PaperSize.Width}");
            Console.WriteLine($"PaperSize Height: {pd.DefaultPageSettings.PaperSize.Height}");
            Console.WriteLine($"PageBounds Width: {e.PageSettings.Bounds.Width}");
            Console.WriteLine($"PageBounds Height: {e.PageSettings.Bounds.Height}");
        }
    }
}
