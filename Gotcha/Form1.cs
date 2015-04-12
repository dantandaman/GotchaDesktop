using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Braintree;


namespace Gotcha
{
    public partial class GotchaWindow : Form
    {
        public List<TransactionInfo> _records;

        int LIMITTRANS = 1000;
        int NUMFRAUDWORDS = 20;
        int maxtrans = 0;
        int[] mostsigdigs = new int[1000];
        float[] price = new float[1000];
        int[] distrdigs = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        float erro, worstcase;
        float[] percdigs = new float[10];
        float[] percdigsexp = { (float)30.1, (float)17.6, (float)12.5, (float)9.7, (float)7.9, (float)6.7, (float)5.8, (float)5.1, (float)4.6, 0 };
        float wctolerance = (float)0.009;
        char[,] fraudwords = new char[1000, 20];
        int[] fraudcount = new int[1000];
        char[,] strings = new char[1000, 30];






        public GotchaWindow()
        {
            InitializeComponent();

            SetupStuff();
        }

        private void SetupStuff()
        {
            _records = new List<TransactionInfo>();
            FilterComboBox.Items.AddRange(new string[] { "Less Than $1", "Over $100", "International", "Benford's law check" });
        }

        //I will shift this code out once I get the API to read from PayPal done
        private void openFIleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TempOpenFIle.ShowDialog() == DialogResult.OK)
            {
                int id = 0;
                int date = 5;
                int name = 1;
                int amount = 11;
                int currency = 10;
                int type = 21;
                char seperator = '\t';
                OpenFile(TempOpenFIle.FileName, seperator, id, date, name, amount, currency, type);
            }
        }

        private void OpenFile(string path, char seperator, int id, int date, int name, int amount, int currency, int type )
        {
            BaseGridView.Rows.Clear();
            _records.Clear();
            StreamReader sr = new StreamReader(path);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                maxtrans++;
                try
                {
<<<<<<< HEAD
                    maxtrans++;
                    try
                    {
                        var row = line.Split('\t');
                        TransactionInfo ti = new TransactionInfo();
                        ti.Date = DateTime.Parse(row[0]);
                        //ti.Type = row[1];
                 //       ti.Name = row[2];
                  //      ti.Subject = row[3];
                        //For credit card data, uncomment the next line
                   //     ti.GrossAmount = float.Parse(row[1], NumberStyles.Currency);
                        ti.GrossAmount = float.Parse(row[8], NumberStyles.Currency);
                       // ti.Fees = row[5];
                      // ti.NetAmount = row[6];
                        //fixme, eventually pick off row 8 instead?
                        ti.Currency = "rupee";

                        
                        _records.Add(ti);
                        BaseGridView.Rows.Add(row);
                       
                    }
                     catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
=======
                    var row = line.Split(seperator);
                    TransactionInfo ti = new TransactionInfo();
                    if (date != -1)
                        ti.Date = DateTime.Parse(row[date]);
                    if (id != -1) 
                        ti.Id = row[id];
                    if (name != -1) 
                        ti.Name = row[name];
                    //      ti.Subject = row[3];
                    if (currency != -1) 
                        ti.Currency = row[currency];
                    if (amount != -1) 
                        ti.GrossAmount = float.Parse(row[amount], NumberStyles.Currency);
                    if (type != -1) 
                        ti.Type = row[type];
                    // ti.Fees = row[5];
                    //ti.NetAmount = row[12];
                    //fixme, eventually pick off row 8 instead?
                    // ti.Currency = (string)row[10]; ;


                    _records.Add(ti);
                    var displayLine = new string[6];
                    displayLine[0] = ti.Id;

                    if (ti.Date != DateTime.MinValue)
                        displayLine[1] = ti.Date.ToString();
                    else
                        displayLine[1] = "";
                    displayLine[2] = ti.Name;
                    if (ti.GrossAmount != float.MinValue)
                        displayLine[3] = ti.GrossAmount.ToString();
                    else
                        displayLine[3] = "";
                    displayLine[4] = ti.Currency;
                    displayLine[5] = ti.Type;
                    BaseGridView.Rows.Add(displayLine);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
>>>>>>> origin/master
                }
            }
            sr.Close();
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
            if (FilterComboBox.Text.Contains("law"))
            { //call the two related functions 
                mostsigdig();
                distrdig();
            }
            if (FilterComboBox.Text.Contains("Over $100"))
                Over100();
            if (FilterComboBox.Text.Contains("International"))
            { easyfraudword(); }
        }

        private void Over100()
        {
            double value = 100.00;
            FilterResults(value, false, Color.Pink);
        }

        private void LessThanADollar()
        {
            double value = 1.00;
            FilterResults(value, true, Color.SkyBlue);
            //int lineCounter = 0;
            //foreach(TransactionInfo ti in _records)
            //{
            //    lineCounter++;
            //    if (ti.GrossAmount < 1.00)
            //    {
            //        //this will add the result ti to the 2nd display view
            //        //you can reorder how the stuff is displayed, just change 
            //        //fixme,  this is highlighting neg. values, and I don't want it to.
            //        /*
            //        string[] row = new string[5];
            //        row[0] = ti.Date.ToString();
            //        row[1] = ti.Name;
            //        row[2] = ti.GrossAmount.ToString();
            //        row[3] = ti.Subject;
            //        row[4] = "Under $1";


            //        //this is the line which adds it to the table specifically
            //        FilterGridView.Rows.Add(row);
            //        */
            //        BaseGridView.Rows[lineCounter-1].Cells[1].Style = new DataGridViewCellStyle { BackColor = Color.Green};


            //    }
            //}
        }

        private void FilterResults(double priceLimit, bool lessThan, Color c)
        {
            for (int index = 0; index < _records.Count; index++)
            {
                TransactionInfo ti = _records[index];
                if (lessThan)
                {
                    if ((ti.GrossAmount < priceLimit) && (ti.GrossAmount > 0)) //this checks to see if it's non-negative and less than the threshold
                    {
                        BaseGridView.Rows[index].Cells[3].Style = new DataGridViewCellStyle { BackColor = c };
                    }
                }
                else
                {
                    if (ti.GrossAmount > priceLimit)
                    {
                        BaseGridView.Rows[index].Cells[3].Style = new DataGridViewCellStyle { BackColor = c };
                    }
                }
            }

        }

        private void FilterResults(string matchString, bool IsRegex, bool NameMatch, Color c)
        {
            Regex regX = new Regex(matchString, RegexOptions.IgnoreCase);
            for (int index = 0; index < _records.Count; index++)
            {
                TransactionInfo ti = _records[index];
                if (IsRegex)
                {
                    if (NameMatch)
                    {
                        if (regX.IsMatch(ti.Name))
                        {
                            BaseGridView.Rows[index].Cells[2].Style = new DataGridViewCellStyle { BackColor = c };
                        }
                    }
                    else //I assume this is on the Subject value hence, the boolean
                    {
                        if (regX.IsMatch(ti.Currency))
                        {
                            BaseGridView.Rows[index].Cells[4].Style = new DataGridViewCellStyle { BackColor = c };
                        }
                    }

                }
                else
                {
                    if (NameMatch)
                    {
                        if (ti.Name.Contains(matchString))
                        {
                            BaseGridView.Rows[index].Cells[2].Style = new DataGridViewCellStyle { BackColor = c };
                        }
                    }
                    else //I assume this is on the Subject value hence, the boolean
                    {
                        if (!ti.Currency.Contains(matchString))
                        {
                            BaseGridView.Rows[index].Cells[4].Style = new DataGridViewCellStyle { BackColor = c };
                        }
                    }
                }

            }
        }

        private void FilterResults(string customFilterName)
        {
            switch (customFilterName)
            {
                //case "fraudword": fraudword(); break;
                default: break;
            }
        }


        private void easyfraudword()
        {
            FilterResults("USD", false, false, Color.SkyBlue);
            //string tempEntry;
            //int lineCounter = 0;
            //lineCounter = 0;
            //foreach (TransactionInfo ti in _records)
            //{
            //    lineCounter++;
            //    //fixme, somehow force strings to lower case somewhere
            //    //fixme, ti.Currency isn't defined correctly above
            //    tempEntry = ti.Currency;


            //    if (tempEntry != "USD")
            //    {
            //        //fraudcount[j]++;
            //        // highlight that entry in blue
            //        //fixme, retest once you fix errors above
            //        BaseGridView.Rows[lineCounter - 1].DefaultCellStyle.BackColor = BackColor = Color.Blue;
            //    };

            //}



        }




        private void fraudword()
        {
            //This function checks for international transactions
            //fixme, this is specific to where I put it on my machine
            StreamReader srFW = new StreamReader(@"C:\Users\mitofskya\Source\Repos\GotchaDesktop\Gotcha\SampleData\fraudulentwords.txt"); ;

            int i, j, k;
            char[] temp = new char[300];
            string[] tempFraudWord = new string[100];
            string tempEntry;
            int lineCounter = 0;

            for (i = 0; i < NUMFRAUDWORDS; i++)
            {

                if (srFW.EndOfStream)
                    break;
                tempFraudWord[i] = srFW.ReadLine();

            }

            srFW.Close();

            for (j = 0; j < NUMFRAUDWORDS; j++)
            {
                lineCounter = 0;
                foreach (TransactionInfo ti in _records)
                {
                    lineCounter++;
                    //fixme, somehow force strings to lower case somewhere
                    //fixme, ti.Currency isn't defined correctly above
                    tempEntry = ti.Currency;


                    if (tempEntry.Contains(tempFraudWord[j]))
                    {
                        fraudcount[j]++;
                        // highlight that entry in blue
                        //fixme, retest once you fix errors above
                        BaseGridView.Rows[lineCounter - 1].Cells[1].Style = new DataGridViewCellStyle { BackColor = Color.Blue };//
                    };

                }
            }
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

            if (erro > wctolerance)
            {
                //We suspect fraud in the entire list. We need to give some type of warning
                //I'm going to try to highlight the entire first column in orange

                MessageBox.Show("There's something fishy here");
                

                //for (int ii = 0; ii < maxtrans; ii++)
                //{
                //    BaseGridView.Rows[ii].Cells[1].Style = new DataGridViewCellStyle { BackColor = Color.Orange };
                //}
            }
            else
                MessageBox.Show("Looks Clean!");

        }

        private void FirstCall()
        {
            //var getPost = new Calls.GetQuestion().ById(Id);
            //var api = new Api();
            //api.Get<Savo.Mobile.Core.Entities.Question, Savo.Mobile.Core.Calls.GetQuestion>(getPost, (resp) =>
            //{
            //    if (resp != null)
            //    {
            //        Asset = new AssetModel()
            //        {
            //            Id = resp.Id,
            //            AssetType = AssetTypes.Post,
            //            Title = resp.Title,
            //            OwnerName = resp.Owner.DisplayName,
            //            CreatedDate = resp.CreatedDate.ToShortDateString(),
            //            ModifiedDate = resp.ModifiedDate.ToShortDateString(),
            //            AverageRating = resp.AverageRating,
            //            Content = resp.Body,
            //            Tags = resp.Tags,
            //            LibraryTopicName = resp.Topic.Name,
            //            LibraryTopicId = resp.Topic.Id,
            //            UrlToView = resp.UrlToView
            //        };
            //    }
            //});
            string username = "test";
            string password = "password";

            RestClient client = new RestClient("http://example.com");
            client.Authenticator = new HttpBasicAuthenticator(username, password);

            RestRequest request = new RestRequest("resource/{id}", Method.GET);
            request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
            request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource

            // easily add HTTP Headers
            request.AddHeader("header", "value");

            // add files to upload (works with compatible verbs)
            //request.AddFile(path);

            // execute the request
            //IRestResponse response = client.Execute(request);
            //var content = response.Content; // raw content as string

            //// or automatically deserialize result
            //// return content type is sniffed but can be explicitly set via RestClient.AddHandler();
            //RestResponse<Person> response2 = client.Execute<Person>(request);
            //var name = response2.Data.Name;

            // easy async support
            client.ExecuteAsync(request, response =>
            {
                Console.WriteLine(response.Content);
            });

            // async with deserialization
            //var asyncHandle = client.ExecuteAsync<Person>(request, response =>
            //{
            //    Console.WriteLine(response.Data.Name);
            //});

            //// abort the request on demand
            //asyncHandle.Abort();

        }

        private void loadBrainTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var request = new TransactionSearchRequest().Status.Is(TransactionStatus.SETTLED);

            BaseGridView.Rows.Clear();
            _records.Clear();
            var collection = Constants.Gateway.Transaction.Search(request);

            foreach (Transaction item in collection)
            {

                var ti = new TransactionInfo();
                ti.GrossAmount = float.Parse(item.Amount.ToString(), NumberStyles.Currency);
                ti.Name = "";//item.CurrencyIsoCode.ToString();
                ti.Currency = item.CurrencyIsoCode.ToString();
                ti.Id = item.Id.ToString();
                ti.Date = item.CreatedAt.Value;
                ti.Type = item.Type.ToString();
                // ti.GrossAmount = float.Parse("2", NumberStyles.Currency);
                _records.Add(ti);

                var displayLine = new string[6];
                displayLine[0] = ti.Id;
                displayLine[1] = ti.Date.ToString();
                displayLine[2] = ti.Name;
                displayLine[3] = ti.GrossAmount.ToString();
                displayLine[4] = ti.Currency;
                displayLine[5] = ti.Type;
                BaseGridView.Rows.Add(displayLine);

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void changeToleranceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openCustomFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputFileForm iff = new InputFileForm();
            iff.ShowDialog();
            if (iff.DialogResult == DialogResult.OK)
            {
                if (TempOpenFIle.ShowDialog() == DialogResult.OK)
                {
                    ConfigValues cv = iff.cv;
                    char seperator = '\t';
                    if (cv.UseCommas)
                    {
                        seperator = ',';
                    }
                    OpenFile(TempOpenFIle.FileName, seperator, cv.idCol, cv.dateCol, cv.amountCol, cv.currencyCol, cv.typeCol, cv.typeCol);
                }
            }
        }

        private void smileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SmileForm sf = new SmileForm();
            sf.ShowDialog();
        }
    }
    public class TransactionInfo
    {
        public DateTime Date = DateTime.MinValue;
        public string Type = "";
        public string Name = "";
        public string Subject = "";
        public float GrossAmount = float.MinValue;
        //public float Fees;
        //public float NetAmount;
        public string Currency = "";
        public string Id = "";
    }

    public class ConfigValues
    {
        public bool UseCommas;
        public int idCol;
        public int dateCol;
        public int nameCol;
        public int amountCol;
        public int currencyCol;
        public int typeCol;
    }

    public class Constants
    {
        public static BraintreeGateway Gateway = new BraintreeGateway
        {
            Environment = Braintree.Environment.SANDBOX,
            PublicKey = "z3nnsbgrfz3wthk4",
            PrivateKey = "f370c8a08621aabda380abfb3a59e258",
            MerchantId = "vd4g7gdx4th996cm"

        };
    }
}
