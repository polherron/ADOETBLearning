using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOETBLearning
{
    public partial class DataConnectionForm : Form
    {
        public DataConnectionForm()
        {
            InitializeComponent();
        }

        private void DataConnectionForm_Load(object sender, EventArgs e)
        {
            String str = ConfigurationManager.ConnectionStrings["sqlConnection"].ToString();

            SqlConnection conn = new SqlConnection(str);

            //Create the command
            SqlCommand cmd = new SqlCommand("SELECT * FROM students", conn);

            //Open the connection
            conn.Open();

            //Add the reader
            SqlDataReader reader = cmd.ExecuteReader();

            //Create a data tableto hld the data
            DataTable dt = new DataTable();

            //Load the data into the table
            dt.Load(reader);

            //Connect the DataGridView to the table
            dgvStudent.DataSource = dt;

            //Refresh the grid view control so that it dieplays the data.
            dgvStudent.Refresh();

            //Close the conection
            conn.Close();
        }

        private void txtFName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
