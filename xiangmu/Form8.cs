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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Equals(""))
            {
                MessageBox.Show("反馈内容不能为空！", "警告！");
            }
            else
            {
                Class1 sqlu = new Class1();
                string db = "bishe";
                MySqlConnection con = sqlu.fangfa(db);
                con.Open();
                string sql = string.Format("insert into info values ('匿名','无','{0}')", this.textBox1.Text);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                int i = cmd.ExecuteNonQuery();
                if (i == 0)
                {
                    MessageBox.Show("反馈失败！");
                }
                else
                {
                    MessageBox.Show("反馈成功！");
                    this.textBox1.Clear();
                }
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }
    }
}
