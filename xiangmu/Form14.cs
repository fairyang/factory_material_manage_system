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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1 sqlu = new Class1();
            string db = "wareHouse";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("") || textBox4.Text.Equals("") || textBox5.Text.Equals("") || textBox6.Text.Equals(""))
            {
                MessageBox.Show("信息不完整"); return;
            }
            string sql = string.Format("insert into usersinfo values ('{0}',default,default,'{1}','{2}','{3}','{4}','{5}')", this.textBox1.Text, textBox3.Text, textBox2.Text, textBox4.Text, textBox5.Text,textBox6.Text);
             MySqlCommand cmd = new MySqlCommand(sql, con);
            int i = cmd.ExecuteNonQuery();
            if (i == 0)
            {
                MessageBox.Show("修改失败！");
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); textBox6.Clear();
            }
            else
            {
                MessageBox.Show("修改成功！");
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); textBox6.Clear();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form14_Load(object sender, EventArgs e)
        {
            this.textBox6.Text = DateTime.Now.ToString();
            textBox6.ReadOnly = true;
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

        private void button1_Click(object sender, EventArgs e)
        {
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
    }
}
