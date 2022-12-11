using DevExpress.LookAndFeel;
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
            CurrentDocument.ActiveForm = this;
            CurrentDocument.ActiveRTB = rtb;
            CurrentDocument.New();
            CurrentDocument.SetTemplate(Templates.Normale);
            PrintHelper.SetPrintParameters(rtb);
        }
        #region HANDLERS
        private void rtb_TextChanged(object sender, EventArgs e) => CurrentDocument.TextModified(lblParole);
        private void esciToolStripMenuItem_Click(object sender, EventArgs e) => Close();
        private void salvaToolStripButton_Click(object sender, EventArgs e) => CurrentDocument.Save();
        private void salvaToolStripMenuItem_Click(object sender, EventArgs e) => CurrentDocument.Save();
        private void apriToolStripMenuItem_Click(object sender, EventArgs e) => CurrentDocument.Open();
        private void apriToolStripButton_Click(object sender, EventArgs e) => CurrentDocument.Open();
        private void salvaconnomeToolStripMenuItem_Click(object sender, EventArgs e) => CurrentDocument.SaveAs();
        private void nuovoToolStripButton_Click(object sender, EventArgs e) => CurrentDocument.New();
        private void nuovoToolStripMenuItem_Click(object sender, EventArgs e) => CurrentDocument.New();
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
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) => CurrentDocument.New();
        private void IncollabarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => rtb.Paste();
        private void TagliabarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => rtb.Cut();
        private void CopiabarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => rtb.Copy();
        private void NuovoDocButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => CurrentDocument.New();
        private void ApribarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => CurrentDocument.Open();
        private void SalvaDocBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => CurrentDocument.Save();
        private void SaveAsbarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => CurrentDocument.SaveAs();
        private void UndobarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => rtb.Undo();
        private void RedobarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => rtb.Redo();
        private void FontStylebarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => CurrentDocument.PickFont();
        private void ForeColorbarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => CurrentDocument.PickColor();
        private void BackTextColorbarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => CurrentDocument.PickBackColor();
        private void BoldbarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => CurrentDocument.Bolderize();
        private void ItalicbarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => CurrentDocument.Italic();
        private void UnderlinebarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => CurrentDocument.Underline();
        private void PageColorbarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => CurrentDocument.PickPageColor();
        private void ImgFromFilebarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => CurrentDocument.InsertImageFromFile();
        private void AlignSXbarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => rtb.SelectionAlignment = HorizontalAlignment.Left;
        private void AlignCenterbarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => rtb.SelectionAlignment = HorizontalAlignment.Center;
        private void AlignDXbarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => rtb.SelectionAlignment = HorizontalAlignment.Right;
        private void ElPuntatobarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => rtb.SelectionBullet = !rtb.SelectionBullet;
        #endregion
        private void TrovabarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => CurrentDocument.Find();
        private void TrovaSostbarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => CurrentDocument.Find(true);
        private void TValentinebarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => UserLookAndFeel.Default.SetSkinStyle(SkinStyle.Valentine);
        private void T365barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => UserLookAndFeel.Default.SetSkinStyle(SkinStyle.WXICompact);
        private void THalloweenbarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => UserLookAndFeel.Default.SetSkinStyle(SkinStyle.Pumpkin);
        private void TNatalebarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => UserLookAndFeel.Default.SetSkinStyle(SkinStyle.Xmas2008Blue);
        private void TmNormalebarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => CurrentDocument.SetTemplate(Templates.Normale);
        private void Titolo1barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => CurrentDocument.SetTemplate(Templates.Titolo1);
        private void TmplNatalebarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            CurrentDocument.InsertImageFromPath(@"../../img/tema-natale.png");
            CurrentDocument.SetTemplate(Templates.TitoloNatale);
        }
        private void AnteprbarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => PrintHelper.PrintPreview();
        private void ImpostaPagbarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => PrintHelper.PageSetup();
        private void StampabarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => PrintHelper.Print();
    }
}
