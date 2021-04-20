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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1 sqlu = new Class1();
            string db = "bishe";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
            string sql = "select * from usersinfo where usersinfo_qx='员工'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            this.dataGridView1.DataSource = ds.Tables[0].DefaultView;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1 sqlu = new Class1();
            string db = "bishe";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
            string sql = "select * from usersinfo where usersinfo_name='" + this.textBox1.Text + "'and usersinfo_qx='员工'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            this.dataGridView1.DataSource = ds.Tables[0].DefaultView;
          
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.textBox2.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            this.textBox3.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.textBox2.ReadOnly = true;
            this.textBox3.ReadOnly = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Class1 sqlu = new Class1();
            string db = "bishe";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
            if(textBox4.Text.Equals("")||textBox5.Text.Equals(""))
            {
                MessageBox.Show("请输入完整信息"); return;
            }
            string sql = "update usersinfo set usersinfo_tell='" + textBox4.Text + "', usersinfo_add='" + textBox5.Text + "' where usersinfo_tell='" + textBox2.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            int i = cmd.ExecuteNonQuery();
            if (i == 0)
            {
                MessageBox.Show("修改失败！");
            }
            else
            {
                MessageBox.Show("修改成功！"); 
                string sq3 = "select * from usersinfo";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sq3, con);
                DataSet ds2 = new DataSet();
                adapter.Fill(ds2);
                this.dataGridView1.DataSource = ds2.Tables[0].DefaultView;
            }
            con.Close();

        }
    }
}
