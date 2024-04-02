using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jcDeskInventory
{
    public partial class frmAddProduct : Form
    {
        public frmAddProduct()
        {
            InitializeComponent();
        }

        static string sConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
        SqlConnection sqlConnection = new SqlConnection(sConnectionString);

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCategory.Text == "")
                {
                    MessageBox.Show("Please select a category for the product");
                }
                else
                {
                   
                    SqlCommand sqlCommand = new SqlCommand("AddProduct", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;   
                    
                    sqlCommand.Parameters.Clear();  
                    sqlCommand.Parameters.AddWithValue("@CategoryId", cmbCategory.SelectedValue);
                    sqlCommand.Parameters.AddWithValue("@ProductCode", Convert.ToInt32(txtCode.Text));
                    sqlCommand.Parameters.AddWithValue("@ProductName", txtName.Text);
                    sqlCommand.Parameters.AddWithValue("@ProductDescription", txtDescription.Text);
                    sqlCommand.Parameters.AddWithValue("@ProductCurrentQuantity", Convert.ToInt32(updCurrentQuantity.Value));
                                        
                    if(sqlConnection.State != ConnectionState.Open)
                        sqlConnection.Open();
                    int iResult=sqlCommand.ExecuteNonQuery();
                  

                    if(iResult == 1)
                    {
                        MessageBox.Show("Product succesfully added","Done", MessageBoxButtons.OK,MessageBoxIcon.Information);
                        formClearing.ClearFormControls(this);
                        cmbCategory.Focus();
                    }

                    
                }
                
            }
            catch (Exception ex)
            {
                

                MessageBox.Show(ex.Message, "There was a problem while adding product", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            finally
            {
                if (sqlConnection.State != ConnectionState.Closed)
                {
                    sqlConnection.Close();
                }
            }
        }

        
        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            try
            {
                //LOAD CATEGORIES
                DataTable dtCategories = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                string sqlQuery = "GetAllProductCategories";
                
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Clear(); //Just suggested by Intellicode
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dtCategories);
               
                //POPULATE COMBOBOX
                cmbCategory.Items.Clear();
                cmbCategory.DataSource = dtCategories;
                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember = "CategoryId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "There was a problem while loading product categories");
            }


        }

        private void chkCurrentQuantity_CheckedChanged(object sender, EventArgs e)
        {
            chkCurrentQuantity.Enabled = chkCurrentQuantity.Checked;
            updCurrentQuantity.Enabled = chkCurrentQuantity.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from Products where ProductCode like @ProductCode", sqlConnection);

            try
            {
                if(sqlConnection.State!=ConnectionState.Open)
                {
                    sqlConnection.Open();
                }
                    
                sqlCommand.Parameters.AddWithValue("@ProductCode", txtCode.Text);
                int iProductCount = (int)sqlCommand.ExecuteScalar();
        

                if (iProductCount > 0)
                {
                    MessageBox.Show("There is already a product with this code in the database. Please check.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCode.Text = String.Empty;
                    txtCode.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Problem while checking duplicated code");
            }

            finally //EXECUTE NO MATTER IF NO EXCEPTION HAS BEEN RAISED
            {
                if (sqlConnection.State != ConnectionState.Closed)
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
