using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WXWarn
{
    static class Program
    {
        static public string[] zones = null;

        static public int UpdateFrequencyIfNoEvent = 0;
        static public int UpdateFrequencyIfWatch = 0;
        static public int UpdateFrequencyIfWarning = 0;
        static public string NoEventSound = null;
        static public string WatchSound = null;
        static public string WarningSound = null;

        [STAThread]
        static void Main()
        {
            try
            {
                zones = new System.Configuration.AppSettingsReader().GetValue("Zones", System.Type.GetType("System.String")).ToString().Split(',');
                
                UpdateFrequencyIfNoEvent = Convert.ToInt32(new System.Configuration.AppSettingsReader().GetValue("UpdateFrequencyInMinutesIfNoEvent", System.Type.GetType("System.Int32")));
                UpdateFrequencyIfWatch = Convert.ToInt32(new System.Configuration.AppSettingsReader().GetValue("UpdateFrequencyInMinutesIfWatch", System.Type.GetType("System.Int32")));
                UpdateFrequencyIfWarning = Convert.ToInt32(new System.Configuration.AppSettingsReader().GetValue("UpdateFrequencyInMinutesIfWarning", System.Type.GetType("System.Int32")));
                
                NoEventSound = new System.Configuration.AppSettingsReader().GetValue("NoEventSound", System.Type.GetType("System.String")).ToString();
                WatchSound = new System.Configuration.AppSettingsReader().GetValue("WatchSound", System.Type.GetType("System.String")).ToString();
                WarningSound = new System.Configuration.AppSettingsReader().GetValue("WarningSound", System.Type.GetType("System.String")).ToString();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());
            }
            catch
            {
                MessageBox.Show("Error in Configuration File", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
