using System;
using System.Windows.Forms;
using WordPad;

namespace BoanoEs15_WordPad
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
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
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) => CurrentDocument.New(rtb, this);
        private void IncollabarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => rtb.Paste();
        private void TagliabarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => rtb.Cut();
        private void CopiabarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => rtb.Copy();
        private void NuovoDocButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => CurrentDocument.New(rtb, this);
        private void ApribarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => CurrentDocument.Open(rtb, this);
        private void SalvaDocBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => CurrentDocument.Save(rtb, this);
        private void SaveAsbarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => CurrentDocument.SaveAs(rtb, this);
        private void UndobarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => rtb.Undo();
        private void RedobarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => rtb.Redo();
        private void FontStylebarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => CurrentDocument.PickFont(rtb);
        private void ForeColorbarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => CurrentDocument.PickColor(rtb);
        private void BackTextColorbarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => CurrentDocument.PickBackColor(rtb);
        private void BoldbarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => CurrentDocument.Bolderize(rtb);
        private void ItalicbarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => CurrentDocument.Italic(rtb);
        private void UnderlinebarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => CurrentDocument.Underline(rtb);
        private void PageColorbarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => CurrentDocument.PickPageColor(rtb);
        private void ImgFromFilebarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => CurrentDocument.InsertImageFromFile(rtb);
    }
}
