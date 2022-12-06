using System;
using System.Windows.Forms;

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
        public static void TextModified(Form f)
        {
            Modified = true;
            if (f.Text[0] != '*') f.Text = "* - " + f.Text;
        }
        public static void New(RichTextBox rtb, Form f)
        {
            if(modified && MessageBox.Show($"Salvare le modifiche a {RelativeFileName}?", "Conferma Salvataggio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Save(rtb, f);
            rtb.Clear();
            filename = null;
            f.Text = $"{RelativeFileName} - My WordPad";
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
                f.Text = $"{RelativeFileName} - My WordPad";
            }
        }
        public static void Save(RichTextBox rtb, Form f)
        {
            if (FileName.IndexOf('\\') == -1)
                SaveAs(rtb, f);
            else
                rtb.SaveFile(FileName);

            Modified = false;
            f.Text = $"{RelativeFileName} - My WordPad";
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
                f.Text = $"{RelativeFileName} - My WordPad";
            }
        }
        #endregion
    }
}
