using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Konsola
{
    class Program
    {
        static void menu()
        {
            Console.Clear();
            Console.WriteLine(@"
                    Aplikacja sklepu pilkarskiego
Rodzaj produktow:    
    1. Buty
    2. Pilki
    3. Koszulki
    4. Spodenki
    5. Getry
    6. Ochraniacze
W przypadku nieznanej opcji aplikacja wroci do menu glownego.
Wybierz numer opcji: ");
        }
        static void menu2()
        {
            Console.Clear();
            Console.WriteLine(@"
                    Aplikacja sklepu pilkarskiego
Wybierz markę:    
    1. Nike
    2. Adidas
    3. Puma
    4. New Balance
W przypadku nieznanej opcji aplikacja wroci do menu glownego.
Wybierz numer opcji: ");
        }
        static void Main(string[] args)
        {
            string[] tabele = new string[] {"Buty", "Pilka", "Koszulka", "Spodenki", "Getry", "Ochraniacze"};
            string[] marki = new string[] { "Nike", "Adidas", "Puma", "New Balance"};
            Console.Clear();

            string sqlconnect = @"DATA SOURCE=MSSQLServer83;"
                + "INITIAL CATALOG=ProjektBD2; INTEGRATED SECURITY=SSPI;";

            string sqlcommand = "";

            SqlConnection connection = null;

            while (true)
            {
                
                int option=-1;
                int option2 = -1;
                Console.WriteLine(@"
                    Aplikacja sklepu pilkarskiego
    1. Wyswietl produkty
    2. Wyswietl produkty posortowane po cenie
    3. Dodaj produkty
    4. Wyswietl produkty najpopularniejszych marek
    0. Wyjdz z aplikacji
Wybierz numer opcji: ");
                try
                {
                    option = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                }
                catch (FormatException)
                {
                    continue;
                }
                if (option == 0)
                {
                    Environment.Exit(0);
                    break;
                }
                else if (option == 1)
                {
                    menu();
                    try
                    {
                        option2 = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.Clear();
                    }
                    catch (FormatException)
                    {
                        continue;
                    }
                    if (option2 > 0 && option2 < 7)
                    {
                        sqlcommand = "Select " + tabele[option2 - 1] + ".ToString() from " + tabele[option2 - 1];
                    }
                    connection = new SqlConnection(sqlconnect);
                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlcommand, connection);
                        SqlDataReader datareader = command.ExecuteReader();

                        while (datareader.Read())
                        {

                            Console.Write(datareader[0].ToString());


                            Console.Write("\n");
                        }
                        Console.WriteLine("Operacja powiodla sie!");
                    }
                    catch (SqlException)
                    {
                        Console.WriteLine("\nBlad!");
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("\nBlad!");
                    }
                    finally { connection.Close(); }
                }
                else if (option == 2)
                {
                    int option3;
                    menu();
                    try
                    {
                        option2 = int.Parse(Console.ReadLine());
                        if (option2<1 || option2>6)
                        {
                            throw new FormatException();
                        }
                        Console.WriteLine();
                        Console.Clear();
                    }
                    catch (FormatException)
                    {
                        continue;
                    }
                                Console.WriteLine(@"
                    Aplikacja sklepu pilkarskiego
Sortowanie   
    1. Malejace
    2. Rosnace
W przypadku nieznanej opcji aplikacja wroci do menu glownego.
Wybierz numer opcji: ");
                    try
                    {
                        option3 = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.Clear();
                    }
                    catch (FormatException)
                    {
                        continue;
                    }
                    if (option3 == 1)
                    {
                        sqlcommand = "Select " + tabele[option2 - 1] + ".getMarka(), " + tabele[option2 - 1] + ".getModel(), " + tabele[option2 - 1] + ".getCena() from " + tabele[option2 - 1] + " ORDER BY " + tabele[option2 - 1] + ".getCena() DESC";
                    }
                    else if (option3 == 2)
                    {
                        sqlcommand = "Select " + tabele[option2 - 1] + ".getMarka(), " + tabele[option2 - 1] + ".getModel(), " + tabele[option2 - 1] + ".getCena() from " + tabele[option2 - 1] + " ORDER BY " + tabele[option2 - 1] + ".getCena() ASC";
                    }
                    
                    connection = new SqlConnection(sqlconnect);
                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlcommand, connection);
                        SqlDataReader datareader = command.ExecuteReader();

                        while (datareader.Read())
                        {

                            Console.Write(datareader[0].ToString()+ " ");
                            Console.Write(datareader[1].ToString()+" ");
                            Console.Write(datareader[2].ToString()+" zl");


                            Console.Write("\n");
                        }
                        Console.WriteLine("Operacja powiodla sie!");
                    }
                    catch (SqlException)
                    {
                        Console.WriteLine("\nBlad!");
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("\nBlad!");
                    }
                    finally { connection.Close(); }
                }
                else if (option == 3)
                {
                    menu();
                    try
                    {
                        option2 = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.Clear();
                    }
                    catch (FormatException)
                    {
                        continue;
                    }
                    if (option2 == 1)
                    {
                        string marka, model, przez, kolor, zaawans;
                        double cena;
                        Console.WriteLine("Podaj markę: ");
                        marka = Console.ReadLine();

                        Console.WriteLine("Podaj model: ");
                        model = Console.ReadLine();

                        Console.WriteLine("Podaj przeznaczenie: ");
                        przez = Console.ReadLine();

                        Console.WriteLine("Podaj kolor: ");
                        kolor = Console.ReadLine();

                        Console.WriteLine("Podaj zaawansowanie: ");
                        zaawans = Console.ReadLine();

                        Console.WriteLine("Podaj cenę: ");
                        try
                        {
                            cena = double.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Podałeś dane złego typu, przeniesiesz się do menu głownego.");
                            continue;
                        }

                        sqlcommand = "insert into dbo.Buty values ('" + marka + "/" + model + "/" + przez + "/" + kolor + "/" + zaawans + "/" + cena.ToString() + "');";
                    }
                    else if (option2 == 2)
                    {
                        string marka, model, przez, kolor, zaawans;
                        double cena;
                        int rozmiar;
                        Console.WriteLine("Podaj markę: ");
                        marka = Console.ReadLine();

                        Console.WriteLine("Podaj rozmiar: ");
                        try
                        {
                            rozmiar = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Podałeś dane złego typu, przeniesiesz się do menu głownego.");
                            continue;
                        }

                        Console.WriteLine("Podaj model: ");
                        model = Console.ReadLine();

                        Console.WriteLine("Podaj przeznaczenie: ");
                        przez = Console.ReadLine();

                        Console.WriteLine("Podaj kolor: ");
                        kolor = Console.ReadLine();

                        Console.WriteLine("Podaj zaawansowanie: ");
                        zaawans = Console.ReadLine();

                        Console.WriteLine("Podaj cenę: ");
                        try
                        {
                            cena = double.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Podałeś dane złego typu, przeniesiesz się do menu głownego.");
                            continue;
                        }

                        sqlcommand = "insert into dbo.Pilka values ('" + marka+ "/"+rozmiar + "/" + model + "/" + przez + "/" + kolor + "/" + zaawans + "/" + cena.ToString() + "');";
                    }
                    else if (option2 == 3)
                    {
                        string marka, model, kolor, dl_rekaw;
                        double cena;
                        Console.WriteLine("Podaj markę: ");
                        marka = Console.ReadLine();

                        Console.WriteLine("Podaj model: ");
                        model = Console.ReadLine();

                        Console.WriteLine("Podaj kolor: ");
                        kolor = Console.ReadLine();

                        Console.WriteLine("Podaj długość rękawów: ");
                        dl_rekaw= Console.ReadLine();

                        Console.WriteLine("Podaj cenę: ");
                        try
                        {
                            cena = double.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Podałeś dane złego typu, przeniesiesz się do menu głownego.");
                            continue;
                        }

                        sqlcommand = "insert into dbo.Koszulka values ('" + marka + "/" + model + "/" + kolor + "/" + dl_rekaw + "/" + cena.ToString() + "');";
                    }
                    else if (option2 == 4)
                    {
                        string marka, model, kolor;
                        double cena;
                        Console.WriteLine("Podaj markę: ");
                        marka = Console.ReadLine();

                        Console.WriteLine("Podaj model: ");
                        model = Console.ReadLine();

                        Console.WriteLine("Podaj kolor: ");
                        kolor = Console.ReadLine();

                        Console.WriteLine("Podaj cenę: ");
                        try
                        {
                            cena = double.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Podałeś dane złego typu, przeniesiesz się do menu głownego.");
                            continue;
                        }

                        sqlcommand = "insert into dbo.Spodenki values ('" + marka + "/" + model + "/" + kolor + "/" + cena.ToString() + "');";
                    }
                    else if (option2 == 5)
                    {
                        string marka, model, kolor;
                        double cena;
                        Console.WriteLine("Podaj markę: ");
                        marka = Console.ReadLine();

                        Console.WriteLine("Podaj model: ");
                        model = Console.ReadLine();

                        Console.WriteLine("Podaj kolor: ");
                        kolor = Console.ReadLine();

                        Console.WriteLine("Podaj cenę: ");
                        try
                        {
                            cena = double.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Podałeś dane złego typu, przeniesiesz się do menu głownego.");
                            continue;
                        }

                        sqlcommand = "insert into dbo.Getry values ('" + marka + "/" + model + "/" + kolor + "/" + cena.ToString() + "');";
                    }
                    else if (option2 == 6)
                    {
                        string marka, model, przezn;
                        double cena;
                        Console.WriteLine("Podaj markę: ");
                        marka = Console.ReadLine();

                        Console.WriteLine("Podaj model: ");
                        model = Console.ReadLine();

                        Console.WriteLine("Podaj przeznaczenie (część ciała): ");
                        przezn = Console.ReadLine();

                        Console.WriteLine("Podaj cenę: ");
                        try
                        {
                            cena = double.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Podałeś dane złego typu, przeniesiesz się do menu głownego.");
                            continue;
                        }

                        sqlcommand = "insert into dbo.Ochraniacze values ('" + marka + "/" + model + "/" + przezn + "/" + cena.ToString() + "');";
                    }
                    connection = new SqlConnection(sqlconnect);
                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlcommand, connection);
                        command.ExecuteNonQuery();
                        Console.WriteLine("Operacja powiodla sie!");
                    }
                    catch (SqlException)
                    {
                        Console.WriteLine("\nBlad!");
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("\nBlad!");
                    }
                    finally { connection.Close(); }
                }
                else if (option == 4)
                {
                    menu2();
                    try
                    {
                        option2 = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.Clear();
                    }
                    catch (FormatException)
                    {
                        continue;
                    }
                    
                    try
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            if (option2 > 0 && option2 < 5)
                            {
                                sqlcommand = "Select " + tabele[i] + ".ToString() from " + tabele[i] + " Where " + tabele[i] + ".getMarka() = '" + marki[option2 - 1] + "'";
                            }
                            connection = new SqlConnection(sqlconnect);
                            connection.Open();
                            SqlCommand command = new SqlCommand(sqlcommand, connection);
                            SqlDataReader datareader = command.ExecuteReader();

                            while (datareader.Read())
                            {

                                Console.Write(datareader[0].ToString());


                                Console.Write("\n");
                            }
                        }
                        Console.WriteLine("Operacja powiodla sie!");
                    }
                    catch (SqlException)
                    {
                        Console.WriteLine("\nBlad!");
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("\nBlad!");
                    }
                    finally { connection.Close(); }
                }
            }
        }
    }
}
