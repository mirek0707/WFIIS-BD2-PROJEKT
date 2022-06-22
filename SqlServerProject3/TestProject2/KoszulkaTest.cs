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
    ///This is a test class for KoszulkaTest and is intended
    ///to contain all KoszulkaTest Unit Tests
    ///</summary>
    [TestClass()]
    public class KoszulkaTest
    {
        static string sqlconnect = @"DATA SOURCE=MSSQLServer83;"
                + "INITIAL CATALOG=ProjektBD2; INTEGRATED SECURITY=SSPI;";

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            SqlConnection connection = new SqlConnection(sqlconnect);
            String sqlcommand = "create table TestKoszulka ( KoszulkaID int PRIMARY KEY, Koszulka dbo.Koszulka);"
                              + "insert into TestKoszulka (KoszulkaID, Koszulka) values (1,'Nike','Striped Division IV', 'zolty', 'krotkie', 119.99);";
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
            String sqlcommand = "DROP TABLE TestKoszulka;";
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
            String sqlcommand = "SELECT Koszulka.getCena() as test_cena FROM TestKoszulka;";
            Double expected = 119.99;
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
        ///A test for getDlRekawow
        ///</summary>
        [TestMethod()]
        public void getDlRekawowTest()
        {
            SqlConnection connection = new SqlConnection(sqlconnect);
            String sqlcommand = "SELECT Koszulka.getDlRekawow() as test_dl FROM TestKoszulka;";
            string expected = "krotkie";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlcommand, connection);
                SqlDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    Assert.AreEqual(expected, datareader["test_dl"]);
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
            String sqlcommand = "SELECT Koszulka.getKolor() as test_kolor FROM TestKoszulka;";
            string expected = "zolty";
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
            String sqlcommand = "SELECT Koszulka.getMarka() as test_marka FROM TestKoszulka;";
            string expected = "Nike";
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
            String sqlcommand = "SELECT Koszulka.getModel() as test_model FROM TestKoszulka;";
            string expected = "Striped Division IV";
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
            String sqlcommand = "SELECT Koszulka.ToString() as test_string FROM TestKoszulka;";
            double c = 119.99;
            string expected = "Koszulka:" +
                "\tMarka: " + "Nike" + "\n" +
                "\tModel: " + "Striped Division IV " + "\n" +
                "\tKolor: " + "zolty" + "\n" +
                "\tDługość rękawów: " + "krotkie" + "\n" +
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
