using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient;

namespace xiangmu
{
    class Class1
    {
        public MySqlConnection fangfa(string test)
        {
            string sqlCon = "server=127.0.0.1;port=3308;user=root;password=123456; database=test;";
            MySqlConnection conn = new MySqlConnection(sqlCon);
            string sql = "select * from sorce";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Open();
            MySqlDataReader reader = cmd.ExecuteReader();//执行ExecuteReader()返回一个MySqlDataReader对象
            Console.WriteLine(reader);
            while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
            {
                //Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString());
                //Console.WriteLine(reader.GetInt32(0)+reader.GetString(1)+reader.GetString(2));
                Console.WriteLine(reader[1] );//"userid"是数据库对应的列名，推荐这种方式
            }
            return conn;
        
        }
    }
}
