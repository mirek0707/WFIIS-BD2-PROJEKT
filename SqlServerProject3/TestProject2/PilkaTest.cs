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
    ///This is a test class for PilkaTest and is intended
    ///to contain all PilkaTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PilkaTest
    {
        static string sqlconnect = @"DATA SOURCE=MSSQLServer83;"
                + "INITIAL CATALOG=ProjektBD2; INTEGRATED SECURITY=SSPI;";

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            SqlConnection connection = new SqlConnection(sqlconnect);
            String sqlcommand = "create table TestPilka ( PilkaID int PRIMARY KEY, Pilka dbo.Pilka);"
                              + "insert into TestPilka (PilkaID, Pilka) values (1,'Adidas', 4,'Starlancer Club', 'trawa', 'bialy', 'rekreacyjna', 64.95);";
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
            String sqlcommand = "DROP TABLE TestPilka";
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
            String sqlcommand = "SELECT Pilka.getCena() as test_cena FROM TestPilka;";
            Double expected = 64.95;
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
            String sqlcommand = "SELECT Pilka.getKolor() as test_kolor FROM TestPilka;";
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
            String sqlcommand = "SELECT Pilka.getMarka() as test_marka FROM TestPilka;";
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
            String sqlcommand = "SELECT Pilka.getModel() as test_model FROM TestPilka;";
            string expected = "Starlancer Club";
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
            String sqlcommand = "SELECT Pilka.getPrzezn() as test_przezn FROM TestPilka;";
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
        ///A test for getRozmiar
        ///</summary>
        [TestMethod()]
        public void getRozmiarTest()
        {
            SqlConnection connection = new SqlConnection(sqlconnect);
            String sqlcommand = "SELECT Pilka.getRozmiar() as test_rozmiar FROM TestPilka;";
            Int32 expected = 4;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlcommand, connection);
                SqlDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    Assert.AreEqual(expected, datareader["test_rozmiar"]);
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
            String sqlcommand = "SELECT Pilka.getZaawans() as test_zaawans FROM TestPilka;";
            string expected = "rekreacyjna";
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
            String sqlcommand = "SELECT Pilka.ToString() as test_string FROM TestPilka;";
            double c = 64.95;
            int r = 4;
            string expected = "Pilka:" +
                "\tMarka: " + "Adidas" + "\n" +
                "\tRozmiar: " + r.ToString() + "\n" +
                "\tModel: " + "Starlancer Club" + "\n" +
                "\tPrzeznaczenie: " + "trawa" + "\n" +
                "\tKolor: " + "bialy" + "\n" +
                "\tZaawansowanie: " + "rekreacyjna" + "\n" +
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
