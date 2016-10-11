using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WXWarn
{
    public partial class FormMain : Form
    {
        private string feedurl = "http://alerts.weather.gov/cap/wwaatmget.php?x=";
        System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
        System.Data.DataTable feedTable;


        public FormMain()
        {
            InitializeComponent();

            BuildUpdateFrequencyTable();

            dataGridViewFeedTable.AutoGenerateColumns = false;
            dataGridViewFeedTable.Columns["Zone"].DataPropertyName = "Zone";
            dataGridViewFeedTable.Columns["NextUpdate"].DataPropertyName = "NextUpdate";
            dataGridViewFeedTable.Columns["Activity"].DataPropertyName = "Activity";
            dataGridViewFeedTable.DataSource = feedTable;
            
            timerPoll.Enabled = true;
            timerPoll_Tick(this, null);
        }


        private void BuildUpdateFrequencyTable()
        {
            feedTable = new DataTable("UpdateTable");
            feedTable.Columns.Add("Zone", System.Type.GetType("System.String"));
            feedTable.Columns.Add("NextUpdate", System.Type.GetType("System.DateTime"));
            feedTable.Columns.Add("Activity", System.Type.GetType("System.String"));
            foreach (string zone in Program.zones)
            {
                System.Data.DataRow newrow = feedTable.NewRow();
                newrow["Zone"] = zone;
                newrow["NextUpdate"] = System.DateTime.Now;
                newrow["Activity"] = "No Current Watches/Warnings";
                feedTable.Rows.Add(newrow);
            }
        }

        #region "Get NWS Data Summary"
        private string GetNWSData(string URL, string ActionPerforming)
        {
            bool showtext = false;
            bool entrylinkfound = false;
            string returnurl = null;

            try
            {
                textBoxStatus.AppendText(ActionPerforming + "\r\n");
                System.Xml.XmlReader xmlreader = System.Xml.XmlReader.Create(URL);
                while (xmlreader.Read())
                {
                    switch (xmlreader.NodeType)
                    {
                        case System.Xml.XmlNodeType.Element:
                            {
                                switch (xmlreader.Name.ToLower())
                                {
                                    case "title":
                                        {
                                            showtext = true;
                                            break;
                                        }
                                    case "entry":
                                        {
                                            entrylinkfound = true;
                                            break;
                                        }
                                    case "id":
                                        {
                                            if (entrylinkfound)
                                                showtext = true;  //we are going to capture this text, below, not print it
                                            break;
                                        }
                                    //case "summary":
                                    //    {
                                    //        if (entrylinkfound)
                                    //            showtext = false;  //if entrylink found, the don't print summary, otherwise print summary
                                    //        else
                                    //            showtext = true;
                                    //        break;
                                    //    }
                                    default:
                                        {
                                            //textBoxStatus.AppendText("START ELEMENT" + xmlreader.Name + "\r\n");
                                            showtext = false;
                                            break;
                                        }
                                }
                                break;
                            }
                        case System.Xml.XmlNodeType.Text:
                            {
                                //display each element text
                                if (showtext)
                                {
                                    if (entrylinkfound)
                                    {
                                        //Additional Link to Alert Data - send it back and I'll show it at the end of this alert
                                        if (xmlreader.Value.Trim().ToLower() != URL.ToLower())
                                            returnurl = xmlreader.Value.Trim();
                                        else
                                            returnurl = null;  //the detailed link/url is the same as what we are looking at - no additional information
                                        //turn off so it doesn't trigger again
                                        entrylinkfound = false;
                                    }
                                    else
                                    {
                                        //Print Data As Normal
                                        textBoxStatus.AppendText(xmlreader.Value + "\r\n");
                                    }
                                }
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
            }
            catch (System.Exception ex)
            {
                textBoxStatus.AppendText("Error " + ActionPerforming + " - " + ex.Message + "\r\n");
                returnurl = null;
            }

            return returnurl;
        }
        #endregion

        #region "Get NWS Alert Data Detail"

        private void GetNWSDetailAlert(System.Data.DataRow ZoneRow, string URL, string ActionPerforming)
        {
            bool showtext = false;
            //following used for more detailed information about this entry
            bool foundalert = true;

            try
            {
                textBoxStatus.AppendText(ActionPerforming + "\r\n");
                System.Xml.XmlReader xmlreader = System.Xml.XmlReader.Create(URL);
                while (xmlreader.Read())
                {
                    switch (xmlreader.NodeType)
                    {
                        case System.Xml.XmlNodeType.Element:
                            {
                                switch (xmlreader.Name.ToLower())
                                {
                                    case "alert":
                                        {
                                            foundalert = true;
                                            break;
                                        }
                                    case "headline":
                                        {
                                            if (foundalert)
                                                showtext = true;
                                            break;
                                        }
                                    case "description":
                                        {
                                            if (foundalert)
                                                showtext = true;
                                            break;
                                        }
                                    case "instruction":
                                        {
                                            if (foundalert)
                                                showtext = true;
                                            break;
                                        }
                                    default:
                                        {
                                            showtext = false;
                                            //textBoxStatus.AppendText("START ELEMENT" + xmlreader.Name + "\r\n");
                                            break;
                                        }
                                }
                                break;
                            }
                        case System.Xml.XmlNodeType.Text:
                            {
                                if (showtext)
                                {
                                    //Print Data As Normal
                                    textBoxStatus.AppendText(xmlreader.Value + "\r\n");
                                    if (xmlreader.Value.ToString().Trim().ToLower().Contains("watch"))
                                    {
                                        ZoneRow["NextUpdate"] = System.DateTime.Now.AddMinutes(Program.UpdateFrequencyIfNoEvent);
                                        ZoneRow["Activity"] = "Active Watch";
                                        if (checkBoxPlayAlertSounds.Checked)
                                        {
                                            if (checkBoxPlayAlertSounds.Checked)
                                            {
                                                new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(PlaySound)).Start(Program.WatchSound);
                                            }
                                        }
                                    }
                                    else if (xmlreader.Value.ToString().Trim().ToLower().Contains("warning"))
                                    {
                                        ZoneRow["NextUpdate"] = System.DateTime.Now.AddMinutes(Program.UpdateFrequencyIfNoEvent);
                                        ZoneRow["Activity"] = "Active Warnings";
                                        if (checkBoxPlayAlertSounds.Checked)
                                        {
                                            if (checkBoxPlayAlertSounds.Checked)
                                            {
                                                new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(PlaySound)).Start(Program.WarningSound);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        ZoneRow["NextUpdate"] = System.DateTime.Now.AddMinutes(Program.UpdateFrequencyIfNoEvent);
                                        ZoneRow["Activity"] = "No Current Watches/Warnings";
                                        if (checkBoxPlayAlertSounds.Checked)
                                        {
                                            new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(PlaySound)).Start(Program.NoEventSound);
                                        }

                                    }
                                }
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
            }
            catch (System.Exception ex)
            {
                textBoxStatus.AppendText("Error " + ActionPerforming + " - " + ex.Message + "\r\n");
            }
        }
        #endregion

        #region "Timer Routine"

        private void timerPoll_Tick(object sender, EventArgs e)
        {
            labelCurrentTime.Text = System.DateTime.Now.ToString();

            foreach (System.Data.DataRow dr in feedTable.Rows)
            {
                if (System.DateTime.Now > Convert.ToDateTime(dr["NextUpdate"]))
                {
                    string moreinformation = GetNWSData(feedurl + dr["Zone"].ToString(), "Contacting NWS Alert System and Getting Zone " + dr["Zone"].ToString() + " Data....");
                    if (moreinformation != null)
                    {
                        GetNWSDetailAlert(dr, moreinformation, "Detailed Information is as follows...");
                    }
                    else
                    {
                        dr["NextUpdate"] = System.DateTime.Now.AddMinutes(Program.UpdateFrequencyIfNoEvent);
                        dr["Activity"] = "No Current Watches/Warnings";
                        if (checkBoxPlayAlertSounds.Checked)
                        {
                            new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(PlaySound)).Start(Program.NoEventSound);
                        }
                        if (checkBoxTextToSpeech.Checked)
                        {
                            System.IO.FileStream sink;
                            
                            SpeechLib.SpVoiceClass voice = new SpeechLib.SpVoiceClass();
                            //voice.Speak(textBox1.Text, SpeechLib.SpeechVoiceSpeakFlags.SVSFDefault);
                        }
                    }
                    textBoxStatus.AppendText("-------------------------------------------------------\r\n");
                }
            }
        }
        #endregion


        private void linkLabelCopyright_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.zackburns.com");
        }

        private static void PlaySound(object MP3File)
        {
            string mp3file = (string)MP3File;
            if (System.IO.File.Exists(mp3file))
            {
                NAudio.Wave.IWavePlayer mp3outdevice;
                NAudio.Wave.WaveStream mp3outstream;
                NAudio.Wave.WaveChannel32 volumestream;

                mp3outdevice = new NAudio.Wave.WaveOut();

                if (mp3file.EndsWith(".mp3"))
                {
                    NAudio.Wave.WaveStream mp3Reader = new NAudio.Wave.Mp3FileReader(mp3file);
                    volumestream = new NAudio.Wave.WaveChannel32(mp3Reader);
                    mp3outstream = volumestream;
                    mp3outdevice.Init(mp3outstream);
                    mp3outdevice.Play();
                }
            }
        }
    }
}
