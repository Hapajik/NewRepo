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

namespace WFormApp9
{
    public partial class Uslugi : Form
    {
        string nusl;
        private string change_comma(string s)
        {
            int pos = s.IndexOf(",");
            if (pos > 0)
            {
                s = s.Substring(0, pos) + "." + s.Substring(pos + 1, 2);
            }
            return s;
        }

        public Uslugi()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            button1.Enabled = true;
            button3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string SQL_dob = "SELECT max(n_usl) as max FROM USLUGI";

            SqlConnection connection1 = new SqlConnection(Data.Glob_connection_string);
            connection1.Open();

            SqlCommand command1 = new SqlCommand(SQL_dob, connection1);
            SqlDataReader dr = command1.ExecuteReader();
            string max = "";
            int max2 = 0;
            while (dr.Read())
            {
                max = string.Format("{0}", dr["max"]);
            }
            dr.Close();
            connection1.Close();
            if (max == "") { max2 = 1; }
            else { max2 = Convert.ToInt32(max) + 1; }
            max = Convert.ToString(max2);

            SQL_dob = "INSERT INTO USLUGI(n_usl, naimen, stoim)  values (" + max + ", N'" + textBox1.Text +
                "', N'" + change_comma(textBox2.Text) + "')";


            connection1 = new SqlConnection(Data.Glob_connection_string);
            connection1.Open();

            command1 = new SqlCommand(SQL_dob, connection1);
            dr = command1.ExecuteReader();
            dr.Close();
            connection1.Close();
            MessageBox.Show("Данные сохранены");
            this.Activate();
        }

        private void Uslugi_Activated(object sender, EventArgs e)
        {
            SqlConnection connection1 = new SqlConnection(Data.Glob_connection_string); connection1.Open();

            string SQL = "Select n_usl, naimen, stoim from USLUGI";

            SqlDataAdapter adapter = new SqlDataAdapter(SQL, connection1);
            DataTable tb = new DataTable();
            adapter.Fill(tb);

            dataGridView1.Refresh();
            dataGridView1.DataSource = tb;
            dataGridView1.Columns[0].HeaderText = "№ Услуги";
            dataGridView1.Columns[0].Width = 100;
            connection1.Close();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox2.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
            nusl = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            button1.Enabled = false;
            button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection1 = new SqlConnection(Data.Glob_connection_string);
            connection1.Open();

            string SQL_izm = "UPDATE Uslugi set naimen=N'" + textBox1.Text +
                            "', stoim=N'" + change_comma(textBox2.Text) + "' WHERE n_usl=" + nusl;


            SqlCommand command1 = new SqlCommand(SQL_izm, connection1);
            SqlDataReader dr = command1.ExecuteReader();
            connection1.Close();
            MessageBox.Show("Данные сохранены");
            this.Activate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
