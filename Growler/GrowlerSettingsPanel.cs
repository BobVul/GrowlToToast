using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Growl.DisplayStyle;

namespace GrowlToToast.Growler
{
    public partial class GrowlerSettingsPanel : SettingsPanelBase
    {
        public GrowlerSettingsPanel()
        {
            InitializeComponent();
        }

        private void checkBoxSilent_CheckedChanged(object sender, EventArgs e)
        {
            this.SaveSetting(GrowlerSettingKeymap.GetKey(GrowlerSetting.Silent), checkBoxSilent.Checked);
        }

        private void checkBoxIgnoreClose_CheckedChanged(object sender, EventArgs e)
        {
            this.SaveSetting(GrowlerSettingKeymap.GetKey(GrowlerSetting.IgnoreClose), checkBoxIgnoreClose.Checked);
        }

        private void checkBoxShowAppName_CheckedChanged(object sender, EventArgs e)
        {
            this.SaveSetting(GrowlerSettingKeymap.GetKey(GrowlerSetting.ShowAppName), checkBoxShowAppName.Checked);
        }

        private void GrowlerSettingsPanel_Load(object sender, EventArgs e)
        {
            Dictionary<string, object> settings = this.GetSettings();
            object val;
            if (settings.TryGetValue(GrowlerSettingKeymap.GetKey(GrowlerSetting.Silent), out val) && (bool)val)
            {
                checkBoxSilent.Checked = true;
            }
            if (settings.TryGetValue(GrowlerSettingKeymap.GetKey(GrowlerSetting.IgnoreClose), out val) && (bool)val)
            {
                checkBoxIgnoreClose.Checked = true;
            }
            if (settings.TryGetValue(GrowlerSettingKeymap.GetKey(GrowlerSetting.ShowAppName), out val) && (bool)val)
            {
                checkBoxShowAppName.Checked = true;
            }
        }
    }
}
