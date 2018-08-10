using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using Newtonsoft.Json.Linq;

namespace ExcelToJson
{
    public partial class Form1 : Form
    {
        Excel.Application xlApp;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        Excel.Range range;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;             
            }
        }

        public void ReadExcel(string fileName, string fileExt)
        {
            dynamic JARRAY;
            dynamic JARRAYOptions;
            dynamic JLIST = new JArray();

            int rCnt;
            int cCnt;
            int rw = 0;
            int cl = 0;
            
            xlApp = new Excel.Application();
            string str = "";
            xlWorkBook = xlApp.Workbooks.Open(fileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            //xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet = xlWorkBook.ActiveSheet;
            range = xlWorkSheet.UsedRange;
            rw = range.Rows.Count;
            cl = range.Columns.Count;
           
            for (rCnt = 1; rCnt <= rw; rCnt++)
            {
                JARRAYOptions = new JObject();
                JARRAYOptions.number = (string)(range.Cells[rCnt, 0] as Excel.Range).Value2;
                JARRAYOptions.text = (string)(range.Cells[rCnt, 11] as Excel.Range).Value2;
                JARRAY = new JObject();
                JARRAY.type = "Heading";
                JARRAY.options = JARRAYOptions;
                JLIST.Add(JARRAY);
                string editor_Or_Not = (string)(range.Cells[rCnt, 3] as Excel.Range).Value2;
                int index = editor_Or_Not.IndexOf("None");

                if (!editor_Or_Not.Contains("None"))
                {
                    JARRAY = new JObject();
                    JARRAY.text = "FullText"; 
                    str= (string)(range.Cells[rCnt, 2] as Excel.Range).Value2;
                    JARRAYOptions = new JObject();
                    JARRAYOptions.formLabel = str.Substring(0,5).Trim();
                    JARRAYOptions.name = str.Substring(0, 5).Trim()+ "_fullText";
                    JARRAYOptions.value = "";
                    JARRAY.options = JARRAYOptions;
                    JLIST.Add(JARRAY);
                }
               
                //for (cCnt = 1; cCnt <= cl; cCnt++)
                //{
                //    str = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                //    MessageBox.Show(str);
                //}
            }
            textBox2.Text = JLIST.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string fileName = openFileDialog1.FileName;
          string fileextns = System.IO.Path.GetExtension(fileName);
             ReadExcel(fileName, fileextns);
        }
    }
}
