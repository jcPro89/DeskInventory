namespace jcDeskInventory
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            var frmAddProduct =new frmAddProduct();
            frmAddProduct.ShowDialog();
        }
    }
}