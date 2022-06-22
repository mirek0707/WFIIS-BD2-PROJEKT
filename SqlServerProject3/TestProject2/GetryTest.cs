using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Data.SqlTypes;
using System.Data.SqlClient;
namespace TestProject2
{
    
    
    /// <summary>
    ///This is a test class for GetryTest and is intended
    ///to contain all GetryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GetryTest
    {
        static string sqlconnect = @"DATA SOURCE=MSSQLServer83;"
                + "INITIAL CATALOG=ProjektBD2; INTEGRATED SECURITY=SSPI;";

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            SqlConnection connection = new SqlConnection(sqlconnect);
            String sqlcommand = "create table TestGetry ( GetryID int PRIMARY KEY, Getry dbo.Getry);"
                              + "insert into TestGetry (GetryID, Getry) values (1,'Adidas','Adi 21', 'zielony', 54.95);";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlcommand, connection);
                SqlDataReader datareader = command.ExecuteReader();
                datareader.Read();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void ClassCleanup()
        {
            SqlConnection connection = new SqlConnection(sqlconnect);
            String sqlcommand = "DROP TABLE TestGetry;";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlcommand, connection);
                SqlDataReader datareader = command.ExecuteReader();
                datareader.Read();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
        }
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for getCena
        ///</summary>
        [TestMethod()]
        public void getCenaTest()
        {
            SqlConnection connection = new SqlConnection(sqlconnect);
            String sqlcommand = "SELECT Getry.getCena() as test_cena FROM TestGetry;";
            Double expected = 54.95;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlcommand, connection);
                SqlDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    Assert.AreEqual(expected, datareader["test_cena"]);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
        }

        /// <summary>
        ///A test for getKolor
        ///</summary>
        [TestMethod()]
        public void getKolorTest()
        {
            SqlConnection connection = new SqlConnection(sqlconnect);
            String sqlcommand = "SELECT Getry.getKolor() as test_kolor FROM TestGetry;";
            string expected = "zielony";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlcommand, connection);
                SqlDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    Assert.AreEqual(expected, datareader["test_kolor"]);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
        }

        /// <summary>
        ///A test for getMarka
        ///</summary>
        [TestMethod()]
        public void getMarkaTest()
        {
            SqlConnection connection = new SqlConnection(sqlconnect);
            String sqlcommand = "SELECT Getry.getMarka() as test_marka FROM TestGetry;";
            string expected = "Adidas";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlcommand, connection);
                SqlDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    Assert.AreEqual(expected, datareader["test_marka"]);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
        }

        /// <summary>
        ///A test for getModel
        ///</summary>
        [TestMethod()]
        public void getModelTest()
        {
            SqlConnection connection = new SqlConnection(sqlconnect);
            String sqlcommand = "SELECT Getry.getModel() as test_model FROM TestGetry;";
            string expected = "Adi 21";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlcommand, connection);
                SqlDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    Assert.AreEqual(expected, datareader["test_model"]);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
        }


        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            SqlConnection connection = new SqlConnection(sqlconnect);
            String sqlcommand = "SELECT Getry.ToString() as test_string FROM TestGetry;";
            double c = 54.95;
            string expected = "Getry:" +
                "\tMarka: " + "Adidas" + "\n" +
                "\tModel: " + "Adi 21" + "\n" +
                "\tKolor: " + "zielony" + "\n" +
                "\tcena: " + c.ToString() + "zł\n";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlcommand, connection);
                SqlDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    Assert.AreEqual(expected, datareader["test_string"]);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
        }
    }
}
