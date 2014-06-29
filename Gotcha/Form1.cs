using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gotcha
{
    public partial class GotchaWindow : Form
    {
        public List<TransactionInfo> _records;

        public GotchaWindow()
        {
            InitializeComponent();

            SetupStuff();
        }

        private void SetupStuff()
        {
            _records = new List<TransactionInfo>();
            FilterComboBox.Items.AddRange(new string[]{"Less Than $1", "Over $100", "International"});
        }

        //I will shift this code out once I get the API to read from PayPal done
        private void openFIleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TempOpenFIle.ShowDialog() == DialogResult.OK)
            {
                string path = TempOpenFIle.FileName;
                StreamReader sr = new StreamReader(path);
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    try
                    {
                        var row = line.Split('\t');
                        TransactionInfo ti = new TransactionInfo();
                        ti.Date = DateTime.Parse(row[0]);
                        //ti.Type = row[1];
                        ti.Name = row[2];
                        //ti.Subject = row[3];
                        ti.GrossAmount = float.Parse(row[1], NumberStyles.Currency);
                        //ti.Fees = row[5];
                        //ti.NetAmount = row[6];
                        _records.Add(ti);
                        BaseGridView.Rows.Add(row);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                sr.Close();
            }
        }

        private void runMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this highlights the specific cell #3 in row #5
            BaseGridView.Rows[5].Cells[3].Style = new DataGridViewCellStyle { BackColor = Color.Yellow };
        }

        private void FilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FilterComboBox.Text.Contains("Less Than $1"))
                LessThanADollar();
        }

        private void LessThanADollar()
        {
            foreach(TransactionInfo ti in _records)
            {
                if (ti.GrossAmount < 1.00)
                {
                    //this will add the result ti to the 2nd display view
                    //you can reorder how the stuff is displayed, just change 
                    string[] row = new string[5];
                    row[0] = ti.Date.ToString();
                    row[1] = ti.Name;
                    row[2] = ti.GrossAmount.ToString();
                    row[3] = ti.Subject;
                    row[4] = "Under $1";
                    //this is the line which adds it to the table specifically
                    FilterGridView.Rows.Add(row);
                }
            }
        }

        private void fraudword()
        {


        }


        private void mostsigdig()
        {
            int i, msd;
            for (i = 0; i < maxtrans; i++)
            {
                if (price[i] >= 1.0)
                    msd = (int)price[i];
                else
                    msd = (int)(price[i] * 100.0);

                while (msd != 0)
                {

                    mostsigdigs[i] = msd % 10;
                    msd = msd / 10;
                }
                printf(" MSD is %d \n", mostsigdigs[i]);
            }

        }

        private void distrdig()
        {

        }


    }
    public class TransactionInfo
    {
        public DateTime Date;
        public string Type;
        public string Name;
        public string Subject;
        public float GrossAmount;
        public float Fees;
        public float NetAmount;
    }
}
