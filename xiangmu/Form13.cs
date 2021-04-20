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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void Form13_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        { Class1 sqlu1 = new Class1();
            string db1 = "wareHouse";
            MySqlConnection con1 = sqlu1.fangfa(db1);
            con1.Open();
            string sql1 = string.Format("select users_id from usersinfo where usersinfo_zh='{0}'", Form1.mingzi);
            MySqlCommand cmd1 = new MySqlCommand(sql1,con1);
            object obj = cmd1.ExecuteScalar();
            string obj1 = obj.ToString();
            int obj2 = int.Parse(obj1);





            Class1 sqlu = new Class1();
            string db = "wareHouse";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("") || textBox4.Text.Equals("") || textBox5.Text.Equals(""))
            {
                MessageBox.Show("信息不完整"); return;
            }
            string sql = string.Format("update usersinfo set usersinfo_zh='{0}',usersinfo_pwd=default, usersinfo_qx=default, usersinfo_sex='{1}', usersinfo_name='{2}', usersinfo_add='{3}', usersinfo_tell='{4}' where users_id={5}", this.textBox1.Text, textBox3.Text, textBox2.Text, textBox4.Text, textBox5.Text,obj2);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            int i = cmd.ExecuteNonQuery();
            if (i == 0)
            {
                MessageBox.Show("修改失败！");
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); 
            }
            else
            {
                MessageBox.Show("修改成功！");




                string sql4 = string.Format("select * from usersinfo where usersinfo_zh='{0}'",textBox1.Text);
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql4, con);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                this.dataGridView1.DataSource = ds.Tables[0].DefaultView;
                con.Close();
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear();
            }
        }


    }
}
