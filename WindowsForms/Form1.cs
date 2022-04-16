using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsForms
{
    public partial class Form1 : Form
    {
        //tao 2 bien cuc bo
        string strCon = @"Data Source=THANHDUY;Initial Catalog=eCommerce;Integrated Security=True";
        //doi tuong ket noi
        SqlConnection sqlCon = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EnableButton(true, false, false);
            DataView();
         
        }
        public void DataView()
        {
            lsvCategory.Items.Clear();
            sqlCon = new SqlConnection(strCon);
            sqlCon.Open();
            //Truy van doi tuong
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from Category";
            //Gui truy van vao ket noi
            sqlCmd.Connection = sqlCon;
            SqlDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                int Id = reader.GetInt32(0);
                string NameC = reader.GetString(1);
                ListViewItem lvi = new ListViewItem(Id.ToString());
                lvi.SubItems.Add(NameC.ToString());
                lsvCategory.Items.Add(lvi);
            }
        }
        private void lsvCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvCategory.SelectedItems.Count ==0)
            {
                return;
            }
            else
            {
                EnableButton(false, true, true);
                ListViewItem item = lsvCategory.SelectedItems[0];
                string id = item.SubItems[0].Text;
                string name = item.SubItems[1].Text;
                txtId.Text = id;
                txtName.Text = name;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtName.Clear();
            EnableButton(true, false, false);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string query = "insert into Category values('"+name+"')";
            DatabaseQuery(query);
            DataView();
            EnableButton(true, false, false);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string name = txtName.Text;
           string query= "update Category set Name = '" + name + "' where Id = " + id;
            DatabaseQuery(query);
            DataView();
            txtId.Clear();
            txtName.Clear();

        }
        public void DatabaseQuery(string query)
        {
            //Truy van doi tuong
            sqlCon = new SqlConnection(strCon);
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = query;
            //Gui truy van vao ket noi
            sqlCmd.Connection = sqlCon;
            SqlDataReader reader = sqlCmd.ExecuteReader();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string query = "delete Category where Id = " + id;
            DatabaseQuery(query);
            DataView();
            EnableButton(true, false, false);
            txtId.Clear();
            txtName.Clear();
        }
        public void EnableButton(bool create,bool update,bool delete)
        {
            btnCreate.Enabled = create;
            btnUpdate.Enabled = update;
            btnDelete.Enabled = delete;
        }
    }
}
