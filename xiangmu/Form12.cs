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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1 sqlu1 = new Class1();
            string db1 = "wareHouse";
            MySqlConnection con1 = sqlu1.fangfa(db1);
            con1.Open();
            string sql1 = string.Format("select usersinfo_pwd from usersinfo where usersinfo_zh='{0}'", Form1.mingzi);
            MySqlCommand cmd1 = new MySqlCommand(sql1, con1);
            object obj = cmd1.ExecuteScalar();
            string obj1 = obj.ToString();
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("")||textBox3.Text.Equals(""))
            {
                MessageBox.Show("请输入完整信息"); return;
            }
            if (textBox1.Text.Equals(obj1))
            {

                if (textBox2.Text.Equals(textBox3.Text))
                {

                    string sql = string.Format("update usersinfo set usersinfo_pwd='{0}' where usersinfo_zh='{1}'", textBox3.Text, Form1.mingzi);
                    MySqlCommand cmd = new MySqlCommand(sql, con1);
                    int i = cmd.ExecuteNonQuery();
                    if (i == 0)
                    {
                        MessageBox.Show("修改失败！");
                        textBox1.Clear(); textBox2.Clear(); textBox3.Clear();
                    }
                    else
                    {
                        MessageBox.Show("修改成功！");

                        Application.Restart();
                    }
                }
                else
                {
                    MessageBox.Show("两次密码不匹配");
                }
            
            }
            else
            {
                MessageBox.Show("原密码不匹配"); return;
            }

        }

        private void Form12_Load(object sender, EventArgs e)
        {
            this.textBox1.PasswordChar = '*';
            this.textBox2.PasswordChar = '*';
            this.textBox3.PasswordChar = '*';
        }
    }
}
