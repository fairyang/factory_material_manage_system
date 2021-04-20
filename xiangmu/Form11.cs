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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        public static int newtity1;
        private void Form11_Load(object sender, EventArgs e)
        {
            Class1 sqlu = new Class1();
            string db = "bishe";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
            string sql = "select distinct 图号 from waresinfo";
            MySqlDataAdapter adapter1 = new MySqlDataAdapter(sql, con);
            DataSet ds1 = new DataSet();
            adapter1.Fill(ds1);
            this.comboBox1.DataSource = ds1.Tables[0].DefaultView;
            this.comboBox1.DisplayMember = "图号";
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1 sqlu = new Class1();
            string db = "bishe";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
            
            if (this.comboBox1.Text.Equals(""))
            {
                MessageBox.Show("图号不能为空！", "安全提示");
                return;
            }
            
            string sql = "select * from waresinfo where 图号='"+this.comboBox1.Text+"'";// 物料名称 = '" + this.textBox1.Text + "'and
               MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            this.dataGridView1.DataSource = ds.Tables[0].DefaultView;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1 sqlu = new Class1();
            string db = "bishe";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
            string sql = "select * from waresinfo  ";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            this.dataGridView1.DataSource = ds.Tables[0].DefaultView;
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        
                this.textBox2.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                this.textBox3.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                this.textBox5.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }

        private void button3_Click(object sender, EventArgs e)
        {
            Class1 sqlu = new Class1();
            string db = "bishe";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
            string sql2 = "select sum(数量) from waresinfo where 所在仓库='"+this.textBox5.Text+"'";
            MySqlCommand com = new MySqlCommand(sql2, con);
            object sum = com.ExecuteScalar();
            string sum1 = sum.ToString();
            int sum2 = int.Parse(sum1);
          
            int newtity=  int.Parse(this.textBox3.Text)+int.Parse(this.textBox4.Text);
            if (int.Parse(this.textBox4.Text)+sum2 > 50000)
            {
                MessageBox.Show("货物数量超出仓库最大容量！","安全提示");
            }
            else
            {
                if (int.Parse(this.textBox4.Text) > 0)
                {
                    string sql = " update waresinfo set 数量='"+newtity+ "'where  物料编码= '"+ this.textBox2.Text+" '";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    int i = cmd.ExecuteNonQuery();
                    if (i == 0)
                    {
                        MessageBox.Show("修改失败！");
                    }
                    else
                    {
                        MessageBox.Show("修改成功！"); newtity1 =newtity;
                    }
                    con.Close();
                    string sql1 = "select * from waresinfo ";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql1, con);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    this.dataGridView1.DataSource = ds.Tables[0].DefaultView;
                    con.Close();
                }
                else
                {
                    MessageBox.Show("新增数量不为负！", "提示");
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
            
        }
    }

