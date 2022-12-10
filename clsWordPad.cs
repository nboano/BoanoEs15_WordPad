using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace WordPad
{
    public static class CurrentDocument
    {
        #region CAMPI
        private static string filename = null;
        private static bool modified;
        #endregion
        #region PROPERTY
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
        public static void TextModified(Form f, Control cntParole, RichTextBox rtb)
        {
            Modified = true;
            if (f.Text[0] != '*') f.Text = "* - " + f.Text;
            cntParole.Text = $"{rtb.Text.Split(' ').Length} parole💀";
        }
        public static void New(RichTextBox rtb, Form f)
        {
            if(modified && MessageBox.Show($"Salvare le modifiche a {RelativeFileName}?", "Conferma Salvataggio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Save(rtb, f);
            rtb.Clear();
            filename = null;
            f.Text = $"{RelativeFileName} - FlopPad 💀";
        }
        public static void Open(RichTextBox rtb, Form f)
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
        public static void Save(RichTextBox rtb, Form f)
        {
            if (FileName.IndexOf('\\') == -1)
                SaveAs(rtb, f);
            else
                rtb.SaveFile(FileName);

            Modified = false;
            f.Text = $"{RelativeFileName} - FlopPad 💀";
        }
        public static void SaveAs(RichTextBox rtb, Form f)
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
        public static void PickFont(RichTextBox rtb)
        {
            var ftp = new FontDialog() { Font = rtb.SelectionFont };
            if (ftp.ShowDialog() == DialogResult.OK)
            {
                rtb.SelectionFont = ftp.Font;
            }
        }
        public static void PickColor(RichTextBox rtb)
        {
            var cdl = new ColorDialog() { Color = rtb.SelectionColor };
            if(cdl.ShowDialog() == DialogResult.OK)
            {
                rtb.SelectionColor = cdl.Color;
            }
        }
        public static void PickBackColor(RichTextBox rtb)
        {
            var cdl = new ColorDialog() { Color = rtb.SelectionBackColor };
            if (cdl.ShowDialog() == DialogResult.OK)
            {
                rtb.SelectionBackColor = cdl.Color;
            }
        }
        public static void PickPageColor(RichTextBox rtb)
        {
            var cdl = new ColorDialog() { Color = rtb.BackColor };
            if (cdl.ShowDialog() == DialogResult.OK)
            {
                rtb.BackColor = cdl.Color;
            }
        }
        public static void Bolderize(RichTextBox rtb)
        {
            Font new1, old1;
            old1 = rtb.SelectionFont;
            if (old1.Bold)
                new1 = new Font(old1, old1.Style & ~FontStyle.Bold);
            else
                new1 = new Font(old1, old1.Style | FontStyle.Bold);

            rtb.SelectionFont = new1;
        }
        public static void Underline(RichTextBox rtb)
        {
            Font new1, old1;
            old1 = rtb.SelectionFont;
            if (old1.Underline)
                new1 = new Font(old1, old1.Style & ~FontStyle.Underline);
            else
                new1 = new Font(old1, old1.Style | FontStyle.Underline);

            rtb.SelectionFont = new1;
        }
        public static void Italic(RichTextBox rtb)
        {
            Font new1, old1;
            old1 = rtb.SelectionFont;
            if (old1.Italic)
                new1 = new Font(old1, old1.Style & ~FontStyle.Italic);
            else
                new1 = new Font(old1, old1.Style | FontStyle.Italic);

            rtb.SelectionFont = new1;
        }
        public static void InsertImageFromFile(RichTextBox rtb)
        {
            FileDialog fDialog = new OpenFileDialog() {
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
        public static void Find(RichTextBox rtb, bool replace = false)
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
                if(replaceWith!= null)
                    rtb.SelectedText = replaceWith;
                startIndex = index + word.Length;
                cnt++;
            }
            rtb.SelectionStart = 0;
            rtb.SelectionLength = rtb.TextLength;
            rtb.SelectionColor = Color.Black;

            MessageBox.Show($"{cnt} occorrenze trovate {(replace ? "e sostituite" : "")}.");
        }
        public static void SetTemplate(RichTextBox rtb, (Font, Color) template)
        {
            rtb.SelectionFont = template.Item1;
            rtb.SelectionColor = template.Item2;
        }
        #endregion
    }
    public static class Templates
    {
        public static (Font, Color) Normale = (new Font("Arial", 11, FontStyle.Regular), Color.Black);
    }
}
