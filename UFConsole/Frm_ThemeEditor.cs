using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UFConsole
{
    public partial class Frm_ThemeEditor : Form
    {
        public Frm_ThemeEditor()
        {
            InitializeComponent();
        }

        private void formOpacity_Scroll(object sender, EventArgs e)
        {
            Data.Settings.Default.FormOpacity = formOpacity.Value;
            Data.Settings.Default.Save();
        }

        private void btnConsoleBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            Color color = colorDialog.Color;

            Data.Settings.Default.ConsoleBackgroundColor = color;
            Data.Settings.Default.Save();
        }

        private void btnConsoleTextColor_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            Color color = colorDialog.Color;

            Data.Settings.Default.ConsoleTextColor = color;
            Data.Settings.Default.Save();
        }

        private void btnInputBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            Color color = colorDialog.Color;

            Data.Settings.Default.InputBackgroundColor = color;
            Data.Settings.Default.Save();
        }

        private void btnInputTextColor_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            Color color = colorDialog.Color;

            Data.Settings.Default.InputTextColor = color;
            Data.Settings.Default.Save();
        }

        private void btnSidebarBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            Color color = colorDialog.Color;

            Data.Settings.Default.SidebarBackgroundColor = color;
            Data.Settings.Default.Save();
        }

        private void btnSidebarTextColor_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            Color color = colorDialog.Color;

            Data.Settings.Default.SidebarTextColor = color;
            Data.Settings.Default.Save();
        }

        private void btnTopBarBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            Color color = colorDialog.Color;

            Data.Settings.Default.TopBarBackgroundColor = color;
            Data.Settings.Default.Save();
        }

        private void btnTopBarTextColor_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            Color color = colorDialog.Color;

            Data.Settings.Default.TopBarTextColor = color;
            Data.Settings.Default.Save();
        }

        private void btnColorKey_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            Color color = colorDialog.Color;

            Data.Settings.Default.FormColorKey = color;
            Data.Settings.Default.Save();
        }
    }
}
