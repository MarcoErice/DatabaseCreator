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
        static void Main(string[] args)
        {
            ShowMenu();
            var choice = Console.ReadLine();
            while (choice != "A")
            {
                switch (choice)
                {
                    case "1":
                        CreateDatabase();
                        break;
                    case "2":
                        CreateCoursesTable();
                        break;
                    case "3":
                        CreateStudentsTable();
                        break;
                    case "4":
                        CreateCourseStudentsTable();
                        break;
                    case "5":
                        FillTablesWithData();
                        break;
                    case "6":
                        ListTableContents();
                        break;

                }
                Console.Beep();
                ShowMenu();
                choice = Console.ReadLine();
            }
                     
        }
#region Show Menu
       
        private static void ShowMenu()
        {            
            Console.WriteLine("1. Skapa databasen Education");
            Console.WriteLine("2. Lägg till tabellen Courses");
            Console.WriteLine("3. Lägg till tabellen Students");
            Console.WriteLine("4. Lägg till tabellen CourseStudents");
            Console.WriteLine("5. Fyll tabellerna med data");
            Console.WriteLine("6. Lista innehållet i tabellerna");
            Console.WriteLine("A. Avsluta");
        }
#endregion
        private static void CreateDatabase()
        {
            var cns = "Data Source=(localdb)\\MSSQLLocalDB;Database=Master";
            SqlConnection cn = new SqlConnection(cns);
            cn.Open();
            var cmd = cn.CreateCommand();
            cmd.CommandText = "CREATE DATABASE [EducationX]";
            cmd.ExecuteNonQuery();            
            cn.Close();
        }
        private static void CreateCoursesTable()
        {
            var cns = "Data Source=(localdb)\\MSSQLLocalDB;Database=EducationX";
            SqlConnection cn = new SqlConnection(cns);
            cn.Open();
            var cmd = cn.CreateCommand();
            cmd.CommandText = "CREATE TABLE[dbo].[Courses] ([CourseID][int] IDENTITY(1,1) NOT NULL, [Name] [nvarchar] (30) NOT NULL)";
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        private static void CreateStudentsTable()
        {
            var cns = "Data Source=(localdb)\\MSSQLLocalDB;Database=EducationX";
            SqlConnection cn = new SqlConnection(cns);
            cn.Open();
            var cmd = cn.CreateCommand();
            cmd.CommandText = "CREATE TABLE[dbo].[Students] ([StudentID][int] IDENTITY(1,1) NOT NULL, [Name] [nvarchar] (30) NOT NULL)";
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        private static void CreateCourseStudentsTable()
        {
            var cns = "Data Source=(localdb)\\MSSQLLocalDB;Database=EducationX";
            SqlConnection cn = new SqlConnection(cns);
            cn.Open();
            var cmd = cn.CreateCommand();
            cmd.CommandText = "CREATE TABLE [dbo].[CourseStudents]([StudentCourseID][int] IDENTITY(1, 1) NOT NULL, [CourseID] [int] NOT NULL, [StudentID] [int] NOT NULL, CONSTRAINT[PK_CourseStudents] PRIMARY KEY CLUSTERED ([StudentCourseID]))";
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        private static void FillTablesWithData()
        {
            var cns = "Data Source=(localdb)\\MSSQLLocalDB;Database=EducationX";
            SqlConnection cn = new SqlConnection(cns);
            cn.Open();
            var cmd = cn.CreateCommand();
            for (var studentNo = 0; studentNo < 100; studentNo++)
            {
                cmd.CommandText = $"INSERT INTO Students (Name) VALUES ('{studentNo.ToString()}')";
                cmd.ExecuteNonQuery();
            }
            for (var courseNo = 0; courseNo < 100; courseNo++)
            {
                cmd.CommandText = $"INSERT INTO Courses (Name) VALUES ('{courseNo.ToString()}')";
                cmd.ExecuteNonQuery();
            }
            cn.Close();
        }
        private static void ListTableContents()
        {
            var cns = "Data Source=(localdb)\\MSSQLLocalDB;Database=EducationX";
            SqlConnection cn = new SqlConnection(cns);
            cn.Open();
            var cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT TOP (5) Name FROM Students;";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(0));
            }
            reader.Close();
            cn.Close();
        }

    }
}
