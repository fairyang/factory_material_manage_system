using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace xiangmu
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Class1 sqlu = new Class1();
            string db = "bishe";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
            string sql = "select * from usersinfo";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql,con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            this.dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
    }
}
