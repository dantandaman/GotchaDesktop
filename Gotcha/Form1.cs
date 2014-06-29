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
       
        int maxtrans=200;
        int[] mostsigdigs = new int[1000];
        float[] price = new float[1000];
        int[] distrdigs = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        float erro, worstcase;
        float[] percdigs = new float[10];
        float[] percdigsexp = {(float)30.1,(float)17.6,(float)12.5,(float)9.7,(float)7.9,(float)6.7,(float)5.8,(float)5.1,(float)4.6,0};
        float wctolerance=(float)0.009;

        public GotchaWindow()
        {
            InitializeComponent();

            SetupStuff();
        }

        private void SetupStuff()
        {
            _records = new List<TransactionInfo>();
            FilterComboBox.Items.AddRange(new string[]{"Less Than $1", "Over $100", "International","Benford's law check"});
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
            if(FilterComboBox.Text.Contains("law"))
            { //call the two related functions 
              mostsigdig();
         	  distrdig();

            }
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
            //This function is used in the power law check. It picks off the most sig. digit.
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
            //    printf(" MSD is %d \n", mostsigdigs[i]);


            }
            
        }

        private void distrdig()
        {
            //This function is also used in the power law check.

            int i;

            for (i = 0; i < maxtrans; i++)
                distrdigs[mostsigdigs[i]]++;
            erro = 0;
          //  printf(" Distribution of digits are \n");
            for (i = 0; i < 10; i++)
            {
                percdigs[i] = (float)(distrdigs[i]) * (float)100.0 / (float)maxtrans;
            //    erro = (float)0.1;
                erro = erro + (percdigs[i] - percdigsexp[i]) * (percdigs[i] - percdigsexp[i]);
            //    printf(" %d  ->  %d  -> %f\n", i, distrdigs[i], percdigs[i]);
            }
            worstcase = 0;
            for (i = 0; i < 9; i++)
                worstcase = worstcase + percdigsexp[i] * percdigsexp[i];
            worstcase = worstcase + (100 - (float)4.58) * (100 - (float)4.58);

            if(erro > wctolerance)
            {
              //We suspect fraud in the entire list. We need to give some type of warning
                //I'm going to try to highlight the entire first column in orange
          
               
                for(int ii=1;ii<maxtrans;ii++)
                {
                    BaseGridView.Rows[ii].Cells[1].Style = new DataGridViewCellStyle { BackColor = Color.Orange };
                }
            }

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
