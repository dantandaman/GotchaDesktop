using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gotcha
{
    public partial class InputFileForm : Form
    {
        public ConfigValues cv;
        public InputFileForm()
        {
            InitializeComponent();
        }

        private void ContinueBttn_Click(object sender, EventArgs e)
        {
            cv = new ConfigValues();
            cv.UseCommas = CommaRadioButton2.Checked;
            cv.idCol = (int)numericUpDown1.Value;
            cv.dateCol = (int)numericUpDown2.Value;
            cv.nameCol = (int)numericUpDown3.Value;
            cv.amountCol = (int)numericUpDown4.Value;
            cv.currencyCol = (int)numericUpDown5.Value;
            cv.typeCol = (int)numericUpDown6.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelBttn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

    //public class ConfigValues
    //{
    //    public bool UseCommas;
    //    public int idCol;
    //    public int dateCol;
    //    public int nameCol;
    //    public int amountCol;
    //    public int currencyCol;
    //    public int typeCol;
    //}
}
