using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

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
                        ti.Date = row[0];
                        //ti.Type = row[1];
                        ti.Name = row[2];
                        //ti.Subject = row[3];
                        ti.GrossAmount = row[1];
                        //ti.Fees = row[5];
                        //ti.NetAmount = row[6];
                        _records.Add(ti);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                sr.Close();
            }
        }
    }
    public class TransactionInfo
    {
        public string Date;
        public string Type;
        public string Name;
        public string Subject;
        public string GrossAmount;
        public string Fees;
        public string NetAmount;
    }
}
