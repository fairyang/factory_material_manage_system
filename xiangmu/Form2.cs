using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System;

using System.Collections.Generic;

using System.ComponentModel;

using System.Data;

using System.Drawing;

using System.Linq;

using System.Text;

using System.Windows.Forms;

using System.Data.OleDb;

using MySql.Data.MySqlClient;
namespace xiangmu
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        DataTable dt = new DataTable();
        MySqlConnection conn;
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 帮助HToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void 系统管理员功能ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            textBox15.ReadOnly = true;
           
            Class1 sqlu = new Class1();
            string db = "bishe";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
            string sql = "select usersinfo_qx from usersinfo where  usersinfo_zh='" + Form1.mingzi + "'";
            MySqlCommand com = new MySqlCommand(sql, con);
            object obj = com.ExecuteScalar();
            if (obj.ToString().Equals("员工"))
            {
                this.tool3.Enabled = false;
                this.pictureBox2.Enabled = false;
                this.pictureBox4.Enabled = false;
                this.pictureBox6.Enabled = false;
                this.pictureBox7.Enabled = false;
                this.pictureBox1.Enabled = false;
            
            }

            this.mingzi.Text = "你好!尊敬的" + Form1.mingzi + obj + "!";
            string sql1 = "select * from cangKu";
            MySqlDataAdapter adapter1 = new MySqlDataAdapter(sql1, con);
            DataSet ds1 = new DataSet();
            adapter1.Fill(ds1);
            this.comboBox3.DataSource = ds1.Tables[0].DefaultView;
            this.comboBox3.DisplayMember = "cangKu_type";
            
            this.comboBox2.DataSource = ds1.Tables[0].DefaultView;
            this.comboBox2.DisplayMember = "cangKu_type";


            string sql2 = "select * from waresinfo ";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql2, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            this.dataGridView1.DataSource = ds.Tables[0].DefaultView;

           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form10 frm10= new Form10();
            frm10.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form6 frm6 = new Form6();
            frm6.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form8 frm8 = new Form8();
            frm8.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form11 frm11 = new Form11();
            frm11.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form7 frm7 = new Form7();
            frm7.Show();
        }

        private void 密码修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form12 frm12 = new Form12();
            frm12.Show();
        }

        private void 信息修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form13 frm13 = new Form13();
            frm13.Show();
        }

        private void 权限设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
        }

        private void 修改人员信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 frm6 = new Form6();
            frm6.Show();
        }

        private void 添加人员ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form14 frm14 = new Form14();
            frm14.Show();
        }

        private void 删除人员ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form15 frm15 = new Form15();
            frm15.Show();
        }

        private void 查询个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form16 frm16 = new Form16();
            frm16.Show();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1 sqlu = new Class1();
            string db = "bishe";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
            if(textBox16.Text.Equals("")||textBox2.Text.Equals("")||textBox1.Text.Equals(""))
            {
                MessageBox.Show("信息不完整");
            }
            else if(int.Parse(textBox16.Text)>50000)
            {
                MessageBox.Show("超出库存量");
            }
            else
            {
                string sql = string.Format("insert into waresinfo values('{0}','{1}','{2}',{3},'{4}')",textBox2.Text,textBox1.Text,textBox19.Text, textBox16.Text, comboBox3.Text);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                int i = cmd.ExecuteNonQuery();
                if (i == 0)
                {
                    MessageBox.Show("添加失败！");
                }
                else
                {
                    MessageBox.Show("添加成功！");
                    string sql1 = "select * from waresinfo ";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql1, con);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    this.dataGridView1.DataSource = ds.Tables[0].DefaultView;
                    con.Close();
                }
                
            }
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Class1 sqlu = new Class1();
            string db = "bishe";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
            string sql = string.Format("select * from waresinfo where 物料编码='"+ textBox5.Text.Trim()+"'");//where 物料编码={0}", textBox5.Text.Trim());
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            this.dataGridView2.DataSource = ds.Tables[0].DefaultView;
            con.Close();
            /*
            Class1 sqlu = new Class1();
            string db = "bishe";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
            string sql1 = string.Format("select * from waresinfo where 物料编码={0}", textBox5.Text);
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql1, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            this.dataGridView2.DataSource = ds.Tables[0].DefaultView;
            */
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Class1 sqlu = new Class1();
            string db = "bishe";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
            string sql = string.Format("select 数量 from waresinfo where 物料编码='" + textBox5.Text.Trim() + "'");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            object sum = cmd.ExecuteScalar();
            string sum1 = sum.ToString();
            int sum2 = int.Parse(sum1);


            if(textBox6.Text.Equals("")||textBox7.Text.Equals(""))
            {
                MessageBox.Show("请输入完整信息"); return;
            }
            else if(int.Parse(textBox7.Text)>sum2)
            {
                MessageBox.Show("出货数量不能大于库存量"); return;
            }
            else if (int.Parse(textBox7.Text)<0)
            {
                MessageBox.Show("输入库存量错误"); return;
            }
            else
            {
                string sql2 = string.Format("update waresinfo set 数量='" + (sum2 - int.Parse(textBox7.Text)) + "'"  ); //物料编码 = '" + textBox6.Text + "'" 
                MySqlCommand cmd1 = new MySqlCommand(sql2, con);
                int i = cmd1.ExecuteNonQuery();
                if (i == 0)
                {
                    MessageBox.Show("出库失败！"); return;
                }
                else
                {
                    MessageBox.Show("出库成功！");
                    string sql1 = string.Format("select * from waresinfo where 物料编码='" + textBox6.Text.Trim() + "'");
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql1, con);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    this.dataGridView2.DataSource = ds.Tables[0].DefaultView;
                    con.Close(); return;
                }
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;

                notifyIcon1.BalloonTipTitle = "注意";
                notifyIcon1.BalloonTipText = "双击打开";
                notifyIcon1.ShowBalloonTip(1000);

                this.Hide();
            }
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (this.textBox3.Text.Equals("") || this.textBox4.Text.Equals(""))
            {
                MessageBox.Show("仓库名称或仓库容量不能为空！", "警告!");
            }
            else{
            Class1 sqlu = new Class1();
            string db = "bishe";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
            string sql3 = "select*from cangKu";
            MySqlCommand com3 = new MySqlCommand(sql3, con);
            MySqlDataReader reader = com3.ExecuteReader();
            string userpwd = null;
            while (reader.Read())
            {
                userpwd = reader[1].ToString();
                if (this.textBox3.Text.Equals(userpwd))
                {
                    MessageBox.Show("仓库名不能重复！", "警告");
                    return;
                }
                else
                {
                    reader.Close();
                    continue;
                }
                
            }
            string sql1 = string.Format("insert into cangKu values('{0}',{1})", textBox3.Text, textBox4.Text.ToString());
            MySqlCommand com = new MySqlCommand(sql1, con);
            int i = com.ExecuteNonQuery();
            if (i > 0)
            {
              
                string sql2 = string.Format("insert into waresinfo values('无','无',0,'{0}')",textBox3.Text);
                MySqlCommand com2 = new MySqlCommand(sql2, con);
                int i2 = com2.ExecuteNonQuery();
                if (i2 > 0) 
                {
                    MessageBox.Show("添加成功，");
                    con.Close();
                }
                //MessageBox.Show("添加成功");
            }
            else
            {
                MessageBox.Show("仓库添加失败！");
            }
            string sql = "select * from cangKu" ;
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            this.dataGridView3.DataSource = ds.Tables[0].DefaultView;
              
        }}

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.textBox8.Text = this.dataGridView3.CurrentRow.Cells[1].Value.ToString();
            this.textBox9.Text = this.dataGridView3.CurrentRow.Cells[0].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Class1 sqlu = new Class1();
            string db = "bishe";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
            string sql = "select * from cangKu";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            this.dataGridView3.DataSource = ds.Tables[0].DefaultView;
           
        }
        private void button2_Click(object sender, EventArgs e)
        {

            Class1 sqlu = new Class1();
            string db = "bishe";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
            string sql="select sum(数量) from waresinfo where 所在仓库='"+this.textBox8.Text+"'";
            MySqlCommand com = new MySqlCommand(sql, con);
            object obj = com.ExecuteScalar();
            string i = obj.ToString();
            int n = int.Parse(i);
           int sum = n;
            MessageBox.Show(sum.ToString());
            if (n > 0)
            {
                MessageBox.Show("仓库还有物品，删除失败！", "警告");
                
            }
            else
            {
                string sql1 = string.Format("delete from cangKu where cangKu_id ={0}",int.Parse( this.textBox9.Text));
                MySqlCommand cmd = new MySqlCommand(sql1, con);
                int a = cmd.ExecuteNonQuery(); 
                if (a==0)
                {
                    MessageBox.Show("删除失败！");
                
                }
                else
                {

                    MessageBox.Show("删除成功！");
                    string sql2 = "select * from cangKu";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql2, con);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    this.dataGridView3.DataSource = ds.Tables[0].DefaultView;
                    con.Close();
                }
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {Class1 sqlu = new Class1();
            string db = "bishe";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
           string sql="update cangKu set cangKu_type='"+this.textBox10.Text+"'where cangKu_id="+int.Parse(this.textBox9.Text);
           MySqlCommand cmd = new MySqlCommand(sql, con);
           int a = cmd.ExecuteNonQuery();
           if (a == 0)
           {
               MessageBox.Show("修改失败！");

           }
           else
           {
               MessageBox.Show("修改成功！");
               string sql2 = "select * from cangKu";
               MySqlDataAdapter adapter = new MySqlDataAdapter(sql2, con);
               DataSet ds = new DataSet();
               adapter.Fill(ds);
               this.dataGridView3.DataSource = ds.Tables[0].DefaultView;
               
               string sql3 = "update waresinfo set 所在仓库='" + this.textBox10.Text + "'where 所在仓库=" + int.Parse(this.textBox9.Text);
               MySqlCommand cmm = new MySqlCommand(sql3, con);
               con.Close();
           }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Class1 sqlu = new Class1();
            string db = "bishe";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
            string sql = string.Format("select cangKu_num from cangKu where cangKu_type='{0}'", comboBox2.Text);
            MySqlCommand com = new MySqlCommand(sql, con);
            object obj = com.ExecuteScalar();
            string i = obj.ToString();
            int n = int.Parse(i);



            string sql2 = string.Format("select sum(数量) from waresinfo where 所在仓库='{0}'",comboBox2.Text);
            MySqlCommand com2 = new MySqlCommand(sql2, con);
            object obj2 = com2.ExecuteScalar();
            string i2 = obj2.ToString();
            int n2 = int.Parse(i2);
            int shengyu = n -n2;
            textBox15.Text = shengyu.ToString();
        }

        private void button15_Click(object sender, EventArgs e)
        {

            Class1 sqlu = new Class1();
            string db = "bishe";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
            string sql = string.Format("select * from cangKu");
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            this.dataGridView5.DataSource = ds.Tables[0].DefaultView;
            con.Close();
        }
        
        private void button12_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog fd = new OpenFileDialog();

            if (fd.ShowDialog() == DialogResult.OK)

            {

                string fileName = fd.FileName;

                bind(fileName);


            }
        }
        private void bind(string fileName)

        {

            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + fileName + ";" + "Extended Properties='Excel 8.0; HDR=Yes; IMEX=1'";

            string strExcel = "";
            OleDbDataAdapter da = null;
            strExcel = string.Format("select * from[{0}$]", "sheet1");
            da = new OleDbDataAdapter(strExcel, strConn);
            // OleDbDataAdapter da = new OleDbDataAdapter("SELECT *  FROM [student]", strConn);

            DataSet ds = new DataSet();

            try

            {

                da.Fill(ds);

                dt = ds.Tables[0];

                this.dataGridView4.DataSource = dt;

            }

            catch (Exception err)

            {

                MessageBox.Show("操作失败！" + err);

            }

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Class1 sqlu = new Class1();
            string db = "bishe";
            MySqlConnection con = sqlu.fangfa(db);
            con.Open();
            string sql = "select *from MBOM ";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            this.dataGridView6.DataSource = ds.Tables[0].DefaultView;
            con.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (this.textBox13.Text.Equals(""))
            {
                MessageBox.Show("反馈内容不能为空！", "警告！");
            }
            else
            {
                Class1 sqlu = new Class1();
                string db = "bishe";
                MySqlConnection con = sqlu.fangfa(db);
                con.Open();
                string sql = string.Format("insert into info values ('{0}',{1},'{2}')", this.textBox11.Text,this.textBox12.Text,this.textBox13.Text);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                int i = cmd.ExecuteNonQuery();
                if (i == 0)
                {
                    MessageBox.Show("反馈失败！");
                }
                else
                {
                    MessageBox.Show("反馈成功！");
                    this.textBox11.Clear();
                    this.textBox12.Clear();
                    this.textBox13.Clear();
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.textBox11.Clear();
            this.textBox12.Clear();
            this.textBox13.Clear();
        }

        private void 反馈查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form17 frm17 = new Form17();
            frm17.Show();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
                string connString = @"server=(local);database=bishe;uid=sa;pwd=123456";
            
            conn = new MySqlConnection(connString);
            conn.Open();       
            if (dataGridView4.Rows.Count > 0)
            {
               DataRow dr = null;

                for (int i = 0; i < dt.Rows.Count; i++)

                {
                    dr = dt.Rows[i];

                    insertToSql(dr);
                }
                //调用存储过程


                MessageBox.Show("导入成功！");
            }
            else
            {
                MessageBox.Show("没有数据！");

            }
           
        }
        private void insertToSql(DataRow dr)

        {

            //excel表中的列名和数据库中的列名一定要对应  

            string 图号 = dr["图号"].ToString();

            string 物料编码 = dr["物料编码"].ToString();

            string 父项图号 = dr["父项图号"].ToString();
            string 物料名称 = dr["物料名称"].ToString();
            string 数量 = dr["数量"].ToString();
            string 层级 = dr["层级"].ToString();
            string 备注 = dr["备注"].ToString();

            // string major = dr["Major"].ToString();

            string sql = "insert into dbo.EBOM values('" + 图号 + "','" + 物料编码 + "','" + 父项图号 + "','" + 物料名称 + "','" + 数量 + "','" + 层级 + "','" + 备注 + "')";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.ExecuteNonQuery();

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("转化成功！");
                MySqlCommand sqlcmd = new MySqlCommand("bom_transform", conn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add("@item", MySqlDbType.VarChar, 50).Value = textBox17.Text.Trim();
                sqlcmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("转化成功！");
                MySqlCommand cmd = new MySqlCommand("select * from dbo.MBOM ", conn);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataSet ds = new DataSet();
                sda.Fill(ds, "cs");
                dataGridView6.DataSource = ds.Tables[0];
            }
            catch (Exception err)

            {

                MessageBox.Show("转化失败！" + err);

            }
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void tool1_Click(object sender, EventArgs e)
        {

        }
    }

}
