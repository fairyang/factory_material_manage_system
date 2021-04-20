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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            Class1 sqlu = new Class1();
            string db = "bishe";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
            string sql = "select * from waresinfo";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            this.dataGridView1.DataSource = ds.Tables[0].DefaultView;



            string sql1 = "select * from cangKu";
            MySqlDataAdapter adapter1 = new MySqlDataAdapter(sql1, con);
            DataSet ds1 = new DataSet();
            adapter1.Fill(ds1);
            this.comboBox1.DataSource = ds1.Tables[0].DefaultView;
            this.comboBox1.DisplayMember = "cangKu_type";


        }

        private void button1_Click(object sender, EventArgs e)
        { Class1 sqlu = new Class1();
            string db = "bishe";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
            string sql = "select 物料编码, 物料名称, 图号, 数量, 所在仓库 from waresinfo where 所在仓库 like '甲'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            this.dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string serch = this.comboBox1.Text;
            Class1 sqlu = new Class1();
            string db = "bishe";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
            string sql = "select * from waresinfo where 所在仓库='" + serch + "'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            this.dataGridView2.DataSource = ds.Tables[0].DefaultView;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
