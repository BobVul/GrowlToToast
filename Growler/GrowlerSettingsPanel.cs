using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Growl.DisplayStyle;

namespace Growler
{
    public partial class GrowlerSettingsPanel : SettingsPanelBase
    {
        public static readonly string SETTING_SILENT = "silent";

        public GrowlerSettingsPanel()
        {
            InitializeComponent();
        }

        private void checkBoxSilent_CheckedChanged(object sender, EventArgs e)
        {
            this.SaveSetting(SETTING_SILENT, checkBoxSilent.Checked);
        }

        private void GrowlerSettingsPanel_Load(object sender, EventArgs e)
        {
            Dictionary<string, object> settings = this.GetSettings();
            if (!settings.ContainsKey(SETTING_SILENT))
            {
                this.SaveSetting(SETTING_SILENT, false);
            }
            bool silent = (bool)settings[SETTING_SILENT];
            if (silent)
            {
                checkBoxSilent.Checked = true;
            }
        }
    }
}
