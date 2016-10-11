using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WXOutlook
{
    public partial class FormMain : Form
    {
        private string HazardSite = "CLE";
        private string StatementStart = "000";
        private string StatementEnd = "$$";

        private bool MorningChecked = false;
        private bool AfternoonChecked = false;
        private bool EveningChecked = false;

        private string HazardousOutlook = null;

        public FormMain()
        {
            InitializeComponent();

            timerClock.Enabled = true;
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            timerClock.Enabled = false;
            labelCurrentTime.Text = System.DateTime.Now.ToString("HH:mm:ss");

            if (!MorningChecked && System.DateTime.Now.Hour >= 0 && System.DateTime.Now.Hour <= 12)
            {
                HazardousOutlook = GetHazardousWeatherOutlook();
                if (HazardousOutlook != null)
                {
                    if (HazardousOutlook.Length > 0)
                    {
                        MorningChecked = true;
                        labelMorning.BackColor = Color.Green;
                        textBoxHazzardReport.Text = HazardousOutlook;
                        if (checkBoxSendAlertToEmail.Checked)
                        {
                            SendEmail(textBoxHazzardReport.Text);
                        }
                    }
                    else
                    {
                        labelMorning.BackColor = Color.Red;
                        textBoxHazzardReport.Text = "NWS - " + HazardSite + " Returned Invalid Outlook";
                    }
                }
                else
                {
                    labelMorning.BackColor = Color.Red;
                    textBoxHazzardReport.Text = "Error Retrieving Outlook from " + HazardSite;
                }
            }
            else if (!AfternoonChecked && System.DateTime.Now.Hour >= 13 && System.DateTime.Now.Hour <= 17)
            {
                HazardousOutlook = GetHazardousWeatherOutlook();
                if (HazardousOutlook != null)
                {
                    if (HazardousOutlook.Length > 0)
                    {
                        AfternoonChecked = true;
                        labelAfternoon.BackColor = Color.Green;
                        textBoxHazzardReport.Text = HazardousOutlook;
                        if (checkBoxSendAlertToEmail.Checked)
                        {
                            SendEmail(textBoxHazzardReport.Text);
                        }
                    }
                    else
                    {
                        labelAfternoon.BackColor = Color.Red;
                        textBoxHazzardReport.Text = "NWS - " + HazardSite + " Returned Invalid Outlook";
                    }
                }
                else
                {
                    labelAfternoon.BackColor = Color.Red;
                    textBoxHazzardReport.Text = "Error Retrieving Outlook from " + HazardSite;
                }
            }
            else if (!EveningChecked && System.DateTime.Now.Hour >= 18 && System.DateTime.Now.Hour <= 23)
            {
                HazardousOutlook = GetHazardousWeatherOutlook();
                if (HazardousOutlook != null)
                {
                    if (HazardousOutlook.Length > 0)
                    {
                        EveningChecked = true;
                        labelEvening.BackColor = Color.Green;
                        textBoxHazzardReport.Text = HazardousOutlook;
                        if (checkBoxSendAlertToEmail.Checked)
                        {
                            SendEmail(textBoxHazzardReport.Text);
                        }
                    }
                    else
                    {
                        labelEvening.BackColor = Color.Red;
                        textBoxHazzardReport.Text = "NWS - " + HazardSite + " Returned Invalid Outlook";
                    }
                }
                else
                {
                    labelEvening.BackColor = Color.Red;
                    textBoxHazzardReport.Text = "Error Retrieving Outlook from " + HazardSite;
                }
            }
            else
            {

            }
            timerClock.Enabled = true;
        }

        private string GetHazardousWeatherOutlook()
        {
            string Statement = null;
            try
            {
                System.Net.WebRequest request = System.Net.WebRequest.Create("http://www.crh.noaa.gov/product.php?site=" + new System.Configuration.AppSettingsReader().GetValue("SiteCode", System.Type.GetType("System.String")) + "&issuedby=" + new System.Configuration.AppSettingsReader().GetValue("IssuedByCode", System.Type.GetType("System.String")) + "&product=" + new System.Configuration.AppSettingsReader().GetValue("ProductCode",System.Type.GetType("System.String")) + "&format=txt&version=1&glossary=0");
                System.Net.WebResponse response = request.GetResponse();
                System.IO.Stream responsestream = response.GetResponseStream();
                System.IO.StreamReader responsereader = new System.IO.StreamReader(responsestream);
                
                Statement = responsereader.ReadToEnd();
                
                responsereader.Close();
                responsereader.Dispose();
                responsereader = null;
                response.Close();
                response = null;
                request = null;

                Statement = ParseStatement(Statement).Replace("\n","\r\n");  //fix unix to windows
            }
            catch
            {
                Statement = "Invalid Configuration Options Specified/Unable to Retrieve NWS Data";
            }
            return Statement;
        }

        private string ParseStatement(string Statement)
        {
            try
            {
                return Statement.Substring(Statement.IndexOf(StatementStart), Statement.IndexOf(StatementEnd) - Statement.IndexOf(StatementStart));
            }
            catch
            {
                return "";
            }
        }

        private void SendEmail(string AlertText)
        {
            try
            {
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(new System.Configuration.AppSettingsReader().GetValue("SMTPServer", System.Type.GetType("System.String")).ToString(), Convert.ToInt32(new System.Configuration.AppSettingsReader().GetValue("SMTPPort", System.Type.GetType("System.String"))));
                client.Credentials = new System.Net.NetworkCredential(new System.Configuration.AppSettingsReader().GetValue("SMTPUserName", System.Type.GetType("System.String")).ToString(), new System.Configuration.AppSettingsReader().GetValue("SMTPPassword", System.Type.GetType("System.String")).ToString());
                client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                if (new System.Configuration.AppSettingsReader().GetValue("UseAuthentication", System.Type.GetType("System.String")).ToString().ToUpper() == "YES" || new System.Configuration.AppSettingsReader().GetValue("UseAuthentication", System.Type.GetType("System.String")).ToString().ToUpper() == "TRUE" || new System.Configuration.AppSettingsReader().GetValue("UseAuthentication", System.Type.GetType("System.String")).ToString().ToUpper() == "1")
                    client.EnableSsl = true;
                else
                    client.EnableSsl = false;
                client.SendAsync(new System.Net.Mail.MailMessage(new System.Configuration.AppSettingsReader().GetValue("SMTPUserName", System.Type.GetType("System.String")).ToString(), new System.Configuration.AppSettingsReader().GetValue("EmailAddress", System.Type.GetType("System.String")).ToString(), "NWS Hazard Statement", AlertText), null);
            }
            catch
            {
            }
        }
    }
}
