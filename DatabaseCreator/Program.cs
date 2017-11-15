using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCreator
{
    class Program
    {
        static string databaseName;
        static void Main(string[] args)
        {
            Console.WriteLine("Ange namn på nytt databas:");
            try
            {
                databaseName = Console.ReadLine();
                CreateDatabase(databaseName);
            }
            catch (Exception)
            {
                Console.WriteLine("Namet på database finns redan\nTryck Enter för och fortsätta");
                Console.ReadLine();
                //throw;

            }
            
            //Console.WriteLine("Skriv tabell namn:");
            var TableName = Console.ReadLine();
            
            //OpenEducation();
            //CreateTables(TableName);
            Console.ReadLine();                       
        }

        
        private static void CreateDatabase(string databaseName)
        {
            var cns = "Data Source=(localdb)\\MSSQLLocalDB;Database=Master";
            SqlConnection cn = new SqlConnection(cns);
            cn.Open();
            var cmd = cn.CreateCommand();
            cmd.CommandText = "CREATE DATABASE [" + databaseName + "]";
            cmd.ExecuteNonQuery();
            Console.WriteLine(databaseName);
            cn.Close();

        }

        private static SqlConnection OpenEducation()
        {
            var cns = "Data Source=(localdb)\\MSSQLLocalDB;Database="+databaseName+"";
            SqlConnection cn = new SqlConnection(cns);
            return cn;
            
        }
        private static void CreateTables(string name)
        {
            var cn = OpenEducation();
            cn.Open();
            var cmd = cn.CreateCommand();
            cmd.CommandText = "CREATE TABLE [dbo].["+name+"] (["+name+"ID] [int] not null primary key identity(1,1), ["+name+"] [nvarchar](15) null)";

            cn.Close();
        }
    }
}
