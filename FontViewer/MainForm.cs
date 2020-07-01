using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.IO;

using Microsoft.Win32;

using FontViewer.Properties;

namespace FontViewer
{
    public partial class MainForm : Form
    {
        #region Constructors

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Methods

        private void MainForm_Load(object sender, EventArgs e)
        {
            fontFolderLinkToolStripStatusLabel.Text = fontsFolderPath;

            foreach (FontFamily font in fonts.Families)
            {
                fontListBox.Items.Add(font.Name);
                searchComboBox.Items.Add(font.Name);
            }

            RegistryKey fontRegKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts");

            foreach (String item in fontRegKey.GetValueNames())
            {
                fontsDictionory.Add(item, fontRegKey.GetValue(item).ToString());
            }

            fontCountToolStripStatusLabel.Text = String.Format(fontCountToolStripStatusLabel.Text, fontListBox.Items.Count.ToString());
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (searchButton.ImageIndex == 1)
            {
                searchComboBox.Text = String.Empty;
                searchComboBox.Focus();
            }
        }

        private void searchComboBox_Enter(object sender, EventArgs e)
        {
            if (String.Equals(searchComboBox.Text, Resources.EnterFontNameText))
            {
                // First erase string, then set formats.

                searchComboBox.Text = String.Empty;
                searchComboBox.Font = searchTextBoxRegularFont;
                searchComboBox.ForeColor = SystemColors.WindowText;

                searchComboBox.SelectedIndex = -1;
            }
        }

        private void searchComboBox_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(searchComboBox.Text))
            {
                // First set formats, then fill in search tip string.

                searchComboBox.Font = searchTextBoxItalicFont;
                searchComboBox.ForeColor = SystemColors.GrayText;
                searchComboBox.Text = Resources.EnterFontNameText;

                searchButton.ImageIndex = 0;
            }
        }

        private void searchComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!String.IsNullOrEmpty(searchComboBox.Text))
            {
                // First search the font, then start third-party font viewer.

                fontListBox.SelectedIndex = fontListBox.FindString(searchComboBox.Text);

                fontListBox_KeyDown(sender, e);
            }
        }

        private void searchComboBox_TextChanged(object sender, EventArgs e)
        {
            Boolean isSearchTextBoxEmpty = String.IsNullOrEmpty(searchComboBox.Text);

            searchButton.ImageIndex = isSearchTextBoxEmpty ? 0 : 1;

            if (!isSearchTextBoxEmpty)
            {
                fontListBox.SelectedIndex = fontListBox.FindString(searchComboBox.Text);
            }
        }

        private void fontListControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            Boolean isFontListBox = sender is ListBox;

            String fontName = isFontListBox ? (sender as ListBox).Items[e.Index].ToString() : (sender as ComboBox).Items[e.Index].ToString();
            Single fontPreviewSize = isFontListBox ? 25.0f : 11.5f;

            drawFontItem(e, fontName, fontPreviewSize, isFontListBox);
        }

        private void fontListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fontListBox.SelectedItem != null)
            {
                String fontName = fontListBox.SelectedItem.ToString();
                String fontFileName = getFontFileName(fontName);

                fontNameToolStripStatusLabel.Text = String.Format(@"{0} ({1})", fontName, fontFileName);
            }
        }

        private void fontListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                start3rdFontViewer();
            }
        }

        private void fontListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                start3rdFontViewer();
            }
        }

        private void fontFolderLinkToolStripStatusLabel_Click(object sender, EventArgs e)
        {
            using (Process.Start
                (Path.Combine(Environment.SystemDirectory, "rundll32.exe"),
                "shell32.dll,SHHelpShortcuts_RunDLL FontsFolder")) { }

            fontFolderLinkToolStripStatusLabel.LinkVisited = true;
        }

        #endregion

        #region Helper Methods

        private void drawFontItem(DrawItemEventArgs e, String fontName, Single fontPreviewSize, Boolean drawHeadFoot)
        {
            using (FontFamily font = new FontFamily(fontName))
            {
                e.DrawBackground();

                if (e.State == DrawItemState.Selected)
                {
                    e.Graphics.FillRectangle(Brushes.LightBlue, e.Bounds);
                }

                using (StringFormat fontStringFormat = new StringFormat())
                {
                    fontStringFormat.Alignment = StringAlignment.Center;
                    fontStringFormat.LineAlignment = StringAlignment.Center;

                    Brush stringBrush = (Enum.Format(typeof(DrawItemState), e.State, "g").Contains("Selected")) ? Brushes.White : Brushes.Black;

                    e.Graphics.DrawRectangle(Pens.LightBlue, e.Bounds);

                    if (drawHeadFoot)
                    {
                        String fontFileName = getFontFileName(font);
                        String fontBottomName = Path.Combine(fontsFolderPath, fontFileName);

                        e.Graphics.DrawString(fontName, SystemFonts.MenuFont, stringBrush, e.Bounds.Left + 10, e.Bounds.Top + 10);
                        e.Graphics.DrawString(fontBottomName, SystemFonts.MenuFont, stringBrush, e.Bounds.Left + 10, e.Bounds.Bottom - 25);
                    }

                    // Use try-catch structure to handle "cannot draw with specified fonts" error.

                    try { e.Graphics.DrawString(fontName, new Font(font, fontPreviewSize, getFontStyle(font)), stringBrush, e.Bounds, fontStringFormat); }
                    catch { }

                    e.Graphics.Dispose();
                }
            }
        }

        private FontStyle getFontStyle(FontFamily fontFamily)
        {
            if (fontFamily.IsStyleAvailable(FontStyle.Regular))
            {
                return FontStyle.Regular;
            }

            if (fontFamily.IsStyleAvailable(FontStyle.Bold))
            {
                return FontStyle.Bold;
            }

            if (fontFamily.IsStyleAvailable(FontStyle.Italic))
            {
                return FontStyle.Italic;
            }

            if (fontFamily.IsStyleAvailable(FontStyle.Strikeout))
            {
                return FontStyle.Strikeout;
            }

            if (fontFamily.IsStyleAvailable(FontStyle.Underline))
            {
                return FontStyle.Underline;
            }

            return FontStyle.Regular;
        }

        private String getFontFileName(String fontName)
        {
            FontFamily font = new FontFamily(fontName);

            return getFontFileName(font);
        }

        private String getFontFileName(FontFamily fontFamily)
        {
            String fontRegName = fontFamily.GetName(CultureInfo.GetCultureInfo("en-us").LCID);

            foreach (KeyValuePair<String, String> item in fontsDictionory)
            {
                if (item.Key.Contains(fontRegName))
                {
                    return item.Value;
                }
            }

            return String.Empty;
        }

        private void start3rdFontViewer()
        {
            if (fontListBox.SelectedIndex >= 0)
            {
                String fontName = fontListBox.SelectedItem.ToString();
                String fontFileName = getFontFileName(fontName);

                if (!String.IsNullOrEmpty(fontFileName))
                {
                    String command = Path.Combine(fontsFolderPath, fontFileName);

                    using (Process.Start(command)) { }
                }
            }
        }

        #endregion

        #region Fields

        private static readonly Font searchTextBoxItalicFont = new Font(SystemFonts.MenuFont, FontStyle.Italic);
        private static readonly Font searchTextBoxRegularFont = new Font(SystemFonts.MenuFont, FontStyle.Regular);

        private static readonly InstalledFontCollection fonts = new InstalledFontCollection();
        private static readonly Dictionary<String, String> fontsDictionory = new Dictionary<String, String>();

        private static readonly String fontsFolderPath = Path.Combine(Environment.GetEnvironmentVariable("SystemRoot"), "Fonts");

        #endregion
    }
}