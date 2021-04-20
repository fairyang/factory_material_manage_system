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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        public static string mingzi;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.textBox2.PasswordChar = new char();
                
            }
            else
            {
                this.textBox2.PasswordChar = '*';
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.textBox2.PasswordChar = '*';
            Random rand = new Random();
            int num1 = rand.Next(1000, 9999);
            string num2 = Convert.ToString(num1);
            this.label3.Text = num2;
            skinEngine1.SkinFile = @"C:\Users\fair yang\Desktop\仓库管理系统\项目\xiangmu\bin\Debug\Skins\DeepGreen.ssk";
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            Random rand = new Random();
            int num1 = rand.Next(1000, 9999);
            string num2 = Convert.ToString(num1);
            this.label3.Text = num2; 
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int num1 = rand.Next(1000, 9999);
            string num2 = Convert.ToString(num1);
            this.label3.Text = num2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1 sqlu = new Class1();
            string db = "bishe";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
            string sql = "select * from usersinfo";
            MySqlCommand com = new MySqlCommand(sql, con);
            MySqlDataReader reader = com.ExecuteReader();
            string name = null;
            while (reader.Read())
            {
                name = reader[1].ToString();
              
                if (textBox1.Text.Equals(name))
                {

                     reader.Close();
                     string sql1 = "select * from usersinfo";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql1, con);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        string mima = ds.Tables[0].Rows[i]["usersinfo_pwd"].ToString();
                        string name1 = ds.Tables[0].Rows[i]["usersinfo_zh"].ToString();
                        if (textBox2.Text.Equals(mima)&&textBox1.Text.Equals(name1))
                        {
                            if (this.textBox3.Text.Equals(this.label3.Text))
                            {
                                mingzi = this.textBox1.Text;
                                con.Close();

                                Form2 frm2 = new Form2();
                                frm2.Show();
                                
                               
                                return;
                            }
                            else
                            {
                                MessageBox.Show("验证码错误", "登录提示");
                                Random rand = new Random();
                                int num1 = rand.Next(1000, 9999);
                                string num2 = Convert.ToString(num1);
                                this.label3.Text = num2;
                                return;
                            }
                        }
                        else if (i+1 == ds.Tables[0].Rows.Count)
                        {
                            if (this.textBox2.Text.Equals(""))
                            {
                                MessageBox.Show("密码不能为空", "登录提示");
                                Random rand = new Random();
                                int num1 = rand.Next(1000, 9999);
                                string num2 = Convert.ToString(num1);
                                this.label3.Text = num2;
                            }
                            else { 
                                MessageBox.Show("密码错误，请检查后重新输入", "登录提示");
                                Random rand = new Random();
                                int num1 = rand.Next(1000, 9999);
                                string num2 = Convert.ToString(num1);
                                this.label3.Text = num2;
                                }
                           con.Close();
                            return;
                           
                        }
                        

                       
                       
                    }



                   

                }

               
                }
           
            MessageBox.Show("用户名输入错误","登陆提示");
           
            con.Close();
            reader.Close();
            Random rand1 = new Random();
            int num3 = rand1.Next(1000, 9999);
            string num4 = Convert.ToString(num3);
            this.label3.Text = num4;
          
            }
        private void Form2_Load(object sender, EventArgs e)
        {
            this.textBox2.PasswordChar = '*';

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

      

       
    }
}
