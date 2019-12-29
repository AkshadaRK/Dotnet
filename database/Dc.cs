using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
//this is dot net project

namespace database
{
    public delegate void DBdelegate();
    class Dc
    {
        public event DBdelegate Add;
        public event DBdelegate Delete;
        MySqlConnection CN;
        MySqlCommand CMD;
        public void insert()
        {
            
            CN = new MySqlConnection(ConfigurationManager.ConnectionStrings["InfowayMySqlConStr"].ConnectionString);
                Console.WriteLine("Enter Emp ID");
                int empid = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Emp Name");
                String empname = Console.ReadLine();
                Console.WriteLine("enter city");
                String empcity = Console.ReadLine();


                CN.Open();

                CMD = new MySqlCommand("insert into emp1 values(@empid,@empname,@empcity)", CN);
                CMD.CommandType = CommandType.Text;
                CMD.Parameters.AddWithValue("empid", empid);
                CMD.Parameters.AddWithValue("empname", empname);
                CMD.Parameters.AddWithValue("empcity", empcity);
                int i = CMD.ExecuteNonQuery();
           
            Console.WriteLine("Commands executed! Total rows affected are " +i);
                Console.WriteLine("Done!");
            if (i == 1)
            {
                if (Add!=null)
                {
                    Add();
                }
            }
            Console.ReadLine();
                Console.Clear();
                CN.Close();
          
            
        }
        public void view()
        {
            CN = new MySqlConnection(ConfigurationManager.
                ConnectionStrings["InfowayMySqlConStr"].ConnectionString);
          
            CN.Open();

            CMD = new MySqlCommand("select * from emp1 ", CN);
            CMD.CommandType = CommandType.Text;
            using (MySqlDataReader reader = CMD.ExecuteReader())
            {
                Console.WriteLine("Emp Id\t\t\t Name \t\t\t City\t");
                while (reader.Read())
                {
                    Console.WriteLine(String.Format
                        ("{0} \t\t\t | {1} \t\t\t |{2}\t",
                        reader[0], reader[1], reader[2]));
                }
            }

            Console.WriteLine("Commands executed! Total rows affected are "
                + CMD.ExecuteNonQuery());
            Console.WriteLine("Done!");
            Console.ReadLine();
            Console.Clear();
            CN.Close();
        }


        public void sort()
        {
            CN = new MySqlConnection(ConfigurationManager.
                ConnectionStrings["InfowayMySqlConStr"].ConnectionString);

            CN.Open();

            CMD = new MySqlCommand("select * from emp1 order by empname ", CN);
            CMD.CommandType = CommandType.Text;
            using (MySqlDataReader reader = CMD.ExecuteReader())
            {
                Console.WriteLine("Emp Id\t\t\t Name \t\t\t City\t");
                while (reader.Read())
                {
                    Console.WriteLine(String.Format
                        ("{0} \t\t\t | {1} \t\t\t |{2}\t",
                        reader[0], reader[1], reader[2]));
                }
            }

            Console.WriteLine("Commands executed! Total rows affected are "
                + CMD.ExecuteNonQuery());
            Console.WriteLine("Done!");
            Console.ReadLine();
            Console.Clear();
            CN.Close();
        }
        public void search()
        {
            CN = new MySqlConnection
                (ConfigurationManager.ConnectionStrings["InfowayMySqlConStr"].
                ConnectionString);

            CN.Open();
            Console.WriteLine("Enter Emp ID");
            int empid = int.Parse(Console.ReadLine());
            CMD = new MySqlCommand("select * from emp1 where " +
                "empid1=@empid", CN);
            CMD.Parameters.AddWithValue("empid", empid);

            CMD.CommandType = CommandType.Text;
            using (MySqlDataReader reader = CMD.ExecuteReader())
            {
                Console.WriteLine("Emp Id\t\t\t Name \t\t\t City\t");
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0} \t\t\t | {1} \t\t\t |{2}\t",
                        reader[0], reader[1], reader[2]));
                }
            }

            Console.WriteLine("Commands executed! Total rows affected are " + CMD.ExecuteNonQuery());
            Console.WriteLine("Done!");
            Console.ReadLine();
            Console.Clear();
            CN.Close();
        }
        public void delete()
        {
            CN = new MySqlConnection(ConfigurationManager.ConnectionStrings["InfowayMySqlConStr"].ConnectionString);

            CN.Open();
            Console.WriteLine("Enter Emp ID You Want To delete");
            int empid = int.Parse(Console.ReadLine());
            CMD = new MySqlCommand("Delete from emp1 where empid1=@empid", CN);
            CMD.Parameters.AddWithValue("empid", empid);
            int i = CMD.ExecuteNonQuery();
            Console.WriteLine("Commands executed! Total rows affected are " +i);
            Console.WriteLine("Done!");
            if (i == 1)
            {
                if (Delete!= null)
                {
                    Delete();
                }
            }
            Console.ReadLine();
            Console.Clear();
            CN.Close();
        }
    }
}
