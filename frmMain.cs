using System;
using System.Windows.Forms;
using WordPad;

namespace BoanoEs15_WordPad
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            CurrentDocument.Modified = false;
            CurrentDocument.New(rtb, this);
        }
        #region HANDLERS
        private void rtb_TextChanged(object sender, EventArgs e) => CurrentDocument.TextModified(this);
        private void esciToolStripMenuItem_Click(object sender, EventArgs e) => Close();
        private void salvaToolStripButton_Click(object sender, EventArgs e) => CurrentDocument.Save(rtb, this);
        private void salvaToolStripMenuItem_Click(object sender, EventArgs e) => CurrentDocument.Save(rtb, this);
        private void apriToolStripMenuItem_Click(object sender, EventArgs e) => CurrentDocument.Open(rtb, this);
        private void apriToolStripButton_Click(object sender, EventArgs e) => CurrentDocument.Open(rtb, this);
        private void salvaconnomeToolStripMenuItem_Click(object sender, EventArgs e) => CurrentDocument.SaveAs(rtb, this);
        private void nuovoToolStripButton_Click(object sender, EventArgs e) => CurrentDocument.New(rtb, this);
        private void nuovoToolStripMenuItem_Click(object sender, EventArgs e) => CurrentDocument.New(rtb, this);
        private void tagliaToolStripButton_Click(object sender, EventArgs e) => rtb.Cut();
        private void tagliaToolStripMenuItem_Click(object sender, EventArgs e) => rtb.Cut();
        private void copiaToolStripButton_Click(object sender, EventArgs e) => rtb.Copy();
        private void copiaToolStripMenuItem_Click(object sender, EventArgs e) => rtb.Copy();
        private void incollaToolStripButton_Click(object sender, EventArgs e) => rtb.Paste();
        private void incollaToolStripMenuItem_Click(object sender, EventArgs e) => rtb.Paste();
        private void UndotoolStripButton_Click(object sender, EventArgs e) => rtb.Undo();
        private void annullaToolStripMenuItem_Click(object sender, EventArgs e) => rtb.Undo();
        private void redotoolStripButton_Click(object sender, EventArgs e) => rtb.Redo();
        private void ripristinaToolStripMenuItem_Click(object sender, EventArgs e) => rtb.Redo();
        #endregion
    }
}
