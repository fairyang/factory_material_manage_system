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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            Class1 sqlu = new Class1();
            string db = "bishe";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
            string sql = "select * from usersinfo";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            this.dataGridView1.DataSource = ds.Tables[0].DefaultView;

            string sql2 = "select distinct  usersinfo_qx from usersinfo";
            MySqlDataAdapter adapter1 = new MySqlDataAdapter(sql2, con);
            DataSet ds2 = new DataSet();
            adapter1.Fill(ds2);
            this.comboBox1.DataSource = ds2.Tables[0].DefaultView;
            this.comboBox1.DisplayMember = "usersinfo_qx";
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1 sqlu = new Class1();
            string db = "bishe";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
            string sql = string.Format("update usersinfo set usersinfo_qx='{0}' where usersinfo_zh='{1}'", this.comboBox1.Text, textBox1.Text);
                MySqlCommand cmd = new MySqlCommand(sql,con);
                int i = cmd.ExecuteNonQuery();
                if (i == 0)
                {
                    MessageBox.Show("修改失败");
                }
                else
                {
                    MessageBox.Show("修改成功");

                }
            
            con.Close();
            Class1 sqlu1 = new Class1();
            string db1 = "bishe";
            MySqlConnection con1 = sqlu.fangfa(db1);
            con.Open();
            string sql1 = "select * from usersinfo";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql1, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            this.dataGridView1.DataSource = ds.Tables[0].DefaultView;
            this.textBox1.Clear();
           
          
        }

    }
}
