using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Azure_FileUpload
{
    class ProcessSQLInput
    {
        //I don't even know what 
        //the hell is that monstocity below 
        public static void ParseFiles()
        {
            string text = ReadFile();
            SqlConnection conn = ConnectToDatabase();
            Format(text, conn);
            CloseConn(conn);
        }

        static string ReadFile()
        {

            return System.IO.File.ReadAllText(@"C:\Users\Illya SKvortsov\source\repos\Azure_FileUpload\Azure_FileUpload\resources\UID_Email.csv");

        }

        static void Format(string text, SqlConnection conn)                                                 
        {                                      
            

            string[] split = text.Split('\n');
            int splitLength = split.Length;

            int[] rowId = new int[splitLength];

            foreach (int i in rowId)
            {
                rowId[i] = 0;
            }

            Console.WriteLine("foreach loop:\n");
            foreach (var word in split)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine("split:\n{0}", split);
            string[] firstName, lastName, age;
            firstName = new string[splitLength];
            lastName = new string[splitLength];
            age = new string[splitLength];


            for (int i = 0; i < splitLength; i++)
            {
                string[] secondSplit = split[i].Split(',');
                Parse(conn, i, secondSplit[0], secondSplit[1], Int32.Parse(secondSplit[2]));
            }
            
            Console.WriteLine("Done");

        }

        static SqlConnection ConnectToDatabase()
        {
            string connString = "(connection string)";
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                Console.WriteLine("Connecting to the database...");
                conn.Open();
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine("Connected Successfully");
            return conn;
        }

        static void CloseConn(SqlConnection conn)
        {
            conn.Close();
        }

        static void Parse(SqlConnection conn, int rowId, string firstName, string lastName, int age)
        {
            string cmdString;
            SqlCommand cmd;

            cmdString = "INSERT INTO ProcessedRow (record_id, row_id, first_name, last_name, age) VALUES (1, '" + rowId + "', '" + firstName + "', '" + lastName + "', '" + age + "')";
            cmd = new SqlCommand(cmdString, conn);
            cmd.ExecuteNonQuery();
        }

    }
}
