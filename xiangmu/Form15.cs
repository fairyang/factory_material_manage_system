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
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            Class1 sqlu = new Class1();
            string db = "wareHouse";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
            string sq3 = "select * from usersinfo";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sq3, con);
            DataSet ds2 = new DataSet();
            adapter.Fill(ds2);
            this.dataGridView1.DataSource = ds2.Tables[0].DefaultView;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1 sqlu = new Class1();
            string db = "wareHouse";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("请选择删除信息"); return;
            }
            string sql = string.Format("delete from usersinfo where usersinfo_zh='{0}'", textBox1.Text);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            int i = cmd.ExecuteNonQuery();
            if (i == 0)
            {
                MessageBox.Show("删除失败！");
                textBox1.Clear(); 
            }
            else
            {
                MessageBox.Show("删除成功！");
                textBox1.Clear(); 

            }
            con.Close();
            textBox1.ReadOnly = true;
            string sq3 = "select * from usersinfo";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sq3, con);
            DataSet ds2 = new DataSet();
            adapter.Fill(ds2);
            this.dataGridView1.DataSource = ds2.Tables[0].DefaultView;
        }
    }
}
