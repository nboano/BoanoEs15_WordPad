using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using DevExpress.XtraRichEdit.API.RichTextBox;
using DevExpress.XtraRichEdit.Layout;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace WordPad
{
    public static class CurrentDocument
    {
        #region CAMPI
        private static string filename = null;
        private static bool modified;
        private static RichTextBox rtb;
        private static Form f;
        #endregion
        #region PROPERTY
        public static RichTextBox ActiveRTB { set => rtb = value; }
        public static Form ActiveForm { set => f = value; }
        public static string FileName
        {
            set
            {
                filename = value;
            }
            get
            {
                if (filename == null) filename = $"Nuovo_{DateTime.Now.ToString("s")}.rtf";
                return filename;
            }
        }
        public static string RelativeFileName
        {
            get
            {
                string s = null;
                if (!string.IsNullOrEmpty(FileName))
                {
                    // s = Path.GetFileName(filename);
                    // OPPURE
                    s = FileName.Substring(FileName.LastIndexOf('\\') + 1);
                }
                return s;
            }
        }
        public static bool Modified
        {
            set
            {
                modified = value;
            }
            get
            {
                return modified;
            }
        }
        #endregion
        #region METODI PUBBLICI
        public static void TextModified(Control cntParole)
        {
            Modified = true;
            if (f.Text[0] != '*') f.Text = "* - " + f.Text;
            cntParole.Text = $"{rtb.Text.Split(' ').Length} parole💀";
        }
        public static void New()
        {
            if (modified && MessageBox.Show($"Salvare le modifiche a {RelativeFileName}?", "Conferma Salvataggio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Save();
            rtb.Clear();
            filename = null;
            f.Text = $"{RelativeFileName} - FlopPad 💀";
        }
        public static void Open()
        {
            string txt = null;
            OpenFileDialog dlg = new OpenFileDialog()
            {
                Filter = "Documento RTF|*.rtf|Tutti i file|*.*",
                Title = "My WordPad - Apri",
                Multiselect = false,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            };
            DialogResult r = dlg.ShowDialog();
            if (r == DialogResult.OK)
            {
                FileName = dlg.FileName;
                rtb.LoadFile(FileName);

                Modified = false;
                f.Text = $"{RelativeFileName} - FlopPad 💀";
            }
        }
        public static void Save()
        {
            if (FileName.IndexOf('\\') == -1)
                SaveAs();
            else
                rtb.SaveFile(FileName);

            Modified = false;
            f.Text = $"{RelativeFileName} - FlopPad 💀";
        }
        public static void SaveAs()
        {
            SaveFileDialog dlg = new SaveFileDialog()
            {
                Title = "My WordPad - Salva con nome",
                Filter = "Documento RTF|*.rtf|Tutti i file|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            };
            DialogResult r = dlg.ShowDialog();
            if (r == DialogResult.OK)
            {
                FileName = dlg.FileName;
                rtb.SaveFile(FileName);

                Modified = false;
                f.Text = $"{RelativeFileName} - FlopPad 💀";
            }
        }
        public static void PickFont()
        {
            var ftp = new FontDialog() { Font = rtb.SelectionFont };
            if (ftp.ShowDialog() == DialogResult.OK)
            {
                rtb.SelectionFont = ftp.Font;
            }
        }
        public static void PickColor()
        {
            var cdl = new ColorDialog() { Color = rtb.SelectionColor };
            if (cdl.ShowDialog() == DialogResult.OK)
            {
                rtb.SelectionColor = cdl.Color;
            }
        }
        public static void PickBackColor()
        {
            var cdl = new ColorDialog() { Color = rtb.SelectionBackColor };
            if (cdl.ShowDialog() == DialogResult.OK)
            {
                rtb.SelectionBackColor = cdl.Color;
            }
        }
        public static void PickPageColor()
        {
            var cdl = new ColorDialog() { Color = rtb.BackColor };
            if (cdl.ShowDialog() == DialogResult.OK)
            {
                rtb.BackColor = cdl.Color;
            }
        }
        public static void Bolderize()
        {
            try
            {
                Font new1, old1;
                old1 = rtb.SelectionFont;
                if (old1.Bold)
                    new1 = new Font(old1, old1.Style & ~FontStyle.Bold);
                else
                    new1 = new Font(old1, old1.Style | FontStyle.Bold);

                rtb.SelectionFont = new1;
            }
            catch (Exception)
            {
            }
        }
        public static void Underline()
        {
            try
            {
                Font new1, old1;
                old1 = rtb.SelectionFont;
                if (old1.Underline)
                    new1 = new Font(old1, old1.Style & ~FontStyle.Underline);
                else
                    new1 = new Font(old1, old1.Style | FontStyle.Underline);

                rtb.SelectionFont = new1;
            }
            catch (Exception)
            {
            }
        }
        public static void Italic()
        {
            try
            {
                Font new1, old1;
                old1 = rtb.SelectionFont;
                if (old1.Italic)
                    new1 = new Font(old1, old1.Style & ~FontStyle.Italic);
                else
                    new1 = new Font(old1, old1.Style | FontStyle.Italic);

                rtb.SelectionFont = new1;
            }
            catch (Exception)
            {
            }
        }
        public static void InsertImageFromFile()
        {
            FileDialog fDialog = new OpenFileDialog()
            {
                Title = "Inserisci un'immagine nel FlopPad",
                Multiselect = false,
                Filter = "Immagini |*.bmp;*.jpg;*.png;*.gif;*.ico",
            };
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                var image = Image.FromFile(fDialog.FileName);
                Clipboard.SetImage(image);
                rtb.Paste();
            }
        }
        public static void InsertImageFromPath(string fpath)
        {
            var image = Image.FromFile(fpath);
            Clipboard.SetImage(image);
            rtb.Paste();
        }
        public static void Find(bool replace = false)
        {
            string replaceWith = null;
            string word = Interaction.InputBox("Inserisci testo da cercare", "Trova");
            if (string.IsNullOrEmpty(word)) return;

            if (replace)
            {
                replaceWith = Interaction.InputBox("Inserisci testo sostitutivo", "Sostituisci");
                if (string.IsNullOrEmpty(replaceWith)) return;
            }

            int s_start = rtb.SelectionStart, startIndex = 0, index;
            int cnt = 0;

            while ((index = rtb.Text.IndexOf(word, startIndex)) != -1)
            {
                rtb.Select(index, word.Length);
                rtb.SelectionBackColor = Color.Yellow;
                if (replaceWith != null)
                    rtb.SelectedText = replaceWith;
                startIndex = index + word.Length;
                cnt++;
            }
            rtb.SelectionStart = 0;
            rtb.SelectionLength = rtb.TextLength;
            rtb.SelectionColor = Color.Black;

            MessageBox.Show($"{cnt} occorrenze trovate {(replace ? "e sostituite" : "")}.");
        }
        public static void SetTemplate((Font, Color) template)
        {
            rtb.SelectionFont = template.Item1;
            rtb.SelectionColor = template.Item2;
        }
        #endregion
    }
    public static class PrintHelper
    {
        #region CAMPI
        private static PrintDocument prn = new PrintDocument();
        private static PageSetupDialog dlgSetup = new PageSetupDialog();
        private static PrintDialog dlgPrint = new PrintDialog();
        private static PrintPreviewDialog dlgPrintPreview = new PrintPreviewDialog();
        private static int linesPrinted;
        private static string[] lines;
        private static RichTextBox rtb;
        #endregion
        #region PARAMS
        public static void SetPrintParameters(RichTextBox _rtb)
        {
            // IMPOSTO PARAMETRI DI DEFAULT

            rtb = _rtb;

            #region MARGINI

            prn.DefaultPageSettings.Margins.Left = 79; // 79 * 0.254mm
            prn.DefaultPageSettings.Margins.Right = 79;

            prn.DefaultPageSettings.Margins.Top = 100;
            prn.DefaultPageSettings.Margins.Bottom = 100;

            dlgSetup.EnableMetric = true;

            #endregion
            #region VARIE

            prn.PrinterSettings.Copies = 1;

            #endregion

            dlgSetup.Document = prn;
            dlgPrintPreview.Document = prn;
            dlgPrint.Document = prn;

            prn.PrintPage += Prn_PrintPage;
        }
        #endregion
        #region METODI PRIVATI
        private static void Prn_PrintPage(object sender, PrintPageEventArgs e)
        {
            double x = prn.DefaultPageSettings.Margins.Left;
            double y = prn.DefaultPageSettings.Margins.Top;
            int w = prn.DefaultPageSettings.PaperSize.Width;

            int pos = 0;

            SizeF misurastr = new SizeF();

            while (pos < rtb.Text.Length)
            {
                if (rtb.Text[pos] == '\n' || x >= w)
                {
                    pos++;
                    y += misurastr.Height;
                    x = prn.DefaultPageSettings.Margins.Left;
                }
                else
                {
                    rtb.Select(pos, 1);
                    misurastr = e.Graphics.MeasureString(rtb.SelectedText, rtb.SelectionFont);
                    e.Graphics.DrawString(rtb.SelectedText, rtb.SelectionFont, new SolidBrush(rtb.SelectionColor), (float)x, (float)y);
                    if (rtb.Text[pos] == ' ') x += misurastr.Width;
                    else x += misurastr.Width * 2/3;
                    pos++;
                }
            }
        }
        #endregion
        #region METODI PUBBLICI
        public static void PageSetup()
        {
            dlgSetup.ShowDialog();
        }
        public static void Print()
        {
            if (dlgPrintPreview.ShowDialog() == DialogResult.OK)
                prn.Print();
        }
        public static void PrintPreview()
        {
            dlgPrintPreview.ShowDialog();
        }
        #endregion
    }
    public static class Templates
    {
        public static (Font, Color) Normale = (new Font("Arial", 11, FontStyle.Regular), Color.Black);
        public static (Font, Color) Titolo1 = (new Font("Arial", 36, FontStyle.Bold), Color.Blue);
        public static (Font, Color) TitoloNatale = (new Font("Blackadder ITC", 24, FontStyle.Bold), Color.DarkRed);
    }
}
