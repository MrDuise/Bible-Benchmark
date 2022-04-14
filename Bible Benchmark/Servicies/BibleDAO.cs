using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bible_Benchmark.Models;
using MySql.Data.MySqlClient;

namespace Bible_Benchmark.Servicies
{
    public class BibleDAO
    {
        String connectionString = "datasource=localhost;port=3306;username=root;password=root;database=bible-app;";

        
        //BookSearch bookSearch = BookSearch.Entire
        public List<Verse> FindVersesBySearchString(String searchFor, String bookSearch)
        {
            List<Verse> verses = new List<Verse>();
            var updatedVerses = new List<Verse>();

            //Uses prepared statements for security. @username @password are defined below
            String sqlStatement = "SELECT * FROM `t_asv` WHERE t Like @verse";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@verse", '%' + searchFor + '%');


                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int bookNumber = (int)reader[1];



                        if (bookSearch == "both")
                        {
                            verses.Add(new Verse((int)reader[1], (int)reader[2], (int)reader[3], (string)reader[4]));
                        }



                        if (bookSearch == "oldTest")
                        {
                            if (bookNumber >= 1 && bookNumber <= 37)
                            {
                                verses.Add(new Verse((int)reader[1], (int)reader[2], (int)reader[3], (string)reader[4]));
                            }
                        }

                        if (bookSearch == "newTest")
                        {

                            if (bookNumber >= 38 && bookNumber <= 66)
                            {
                                verses.Add(new Verse((int)reader[1], (int)reader[2], (int)reader[3], (string)reader[4]));
                            }
                        }



                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
            }
            return verses;
        }

        public List<Book> findAllBooks()
        {
            //list of books
            List<Book> books = new List<Book>();

            //Uses prepared statements for security. @username @password are defined below
            String sqlStatement = "SELECT * FROM `key_english`";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);



                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            books.Add(new Book((int)reader[0], (string)reader[1]));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return books;
        }




    }
}
