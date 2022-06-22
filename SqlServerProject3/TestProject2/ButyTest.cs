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
    ///This is a test class for ButyTest and is intended
    ///to contain all ButyTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ButyTest
    {
        static string sqlconnect = @"DATA SOURCE=MSSQLServer83;"
                + "INITIAL CATALOG=ProjektBD2; INTEGRATED SECURITY=SSPI;";

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            SqlConnection connection = new SqlConnection(sqlconnect);
            String sqlcommand = "create table TestButy ( ButyID int PRIMARY KEY, Buty dbo.Buty);"
                              + "insert into TestButy (ButyID, Buty) values (1,'Adidas','Predator Edge+ FG', 'trawa', 'bialy', 'profesjonalisci', 1199.0);";
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
            String sqlcommand = "DROP TABLE TestButy;";
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
            String sqlcommand = "SELECT Buty.getCena() as test_cena FROM TestButy;";
            Double expected = 1199.0;
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
            String sqlcommand = "SELECT Buty.getKolor() as test_kolor FROM TestButy;";
            string expected = "bialy";
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
            String sqlcommand = "SELECT Buty.getMarka() as test_marka FROM TestButy;";
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
            String sqlcommand = "SELECT Buty.getModel() as test_model FROM TestButy;";
            string expected = "Predator Edge+ FG";
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
        ///A test for getPrzezn
        ///</summary>
        [TestMethod()]
        public void getPrzeznTest()
        {
            SqlConnection connection = new SqlConnection(sqlconnect);
            String sqlcommand = "SELECT Buty.getPrzezn() as test_przezn FROM TestButy;";
            string expected = "trawa";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlcommand, connection);
                SqlDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    Assert.AreEqual(expected, datareader["test_przezn"]);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
        }

        /// <summary>
        ///A test for getZaawans
        ///</summary>
        [TestMethod()]
        public void getZaawansTest()
        {
            SqlConnection connection = new SqlConnection(sqlconnect);
            String sqlcommand = "SELECT Buty.getZaawans() as test_zaawans FROM TestButy;";
            string expected = "profesjonalisci";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlcommand, connection);
                SqlDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    Assert.AreEqual(expected, datareader["test_zaawans"]);
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
            String sqlcommand = "SELECT Buty.ToString() as test_string FROM TestButy;";
            double c = 1199.00;
            string expected = "Buty:" +
                "\tMarka: " + "Adidas" + "\n" +
                "\tModel: " + "Predator Edge+ FG" + "\n" +
                "\tPrzeznaczenie: " + "trawa" + "\n" +
                "\tKolor: " + "bialy" + "\n" +
                "\tZaawansowanie: " + "profesjonalisci" + "\n" +
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
