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
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form16_Load(object sender, EventArgs e)
        {
            Class1 sqlu = new Class1();
            string db = "wareHouse";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
            string sql = string.Format("select * from usersinfo where usersinfo_zh='{0}'", Form1.mingzi);
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            this.dataGridView1.DataSource = ds.Tables[0].DefaultView;
            con.Close();
        }
    }
}
