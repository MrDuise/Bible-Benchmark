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

        public enum BookSearch { Entire, OldTestiment, NewTestiment };
        //BookSearch bookSearch = BookSearch.Entire
        public List<Verse> FindVersesBySearchString(String searchFor)
        {
            List<Verse> verses = new List<Verse>();

            //Uses prepared statements for security. @username @password are defined below
            String sqlStatement = "SELECT * FROM `t_asv` WHERE Name Like @verse";

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
                        verses.Add(new Verse((int)reader[1], (int)reader[2], (int)reader[3], (string)reader[4]));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
            }
            return verses;
        }

        public List<string> findAllBooks()
        {
            //list of books
            List<string> books = new List<string>();

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
                            books.Add((string)reader[1]);
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

        public bool findBookByName(string searchName)
        {
            return true;
        }

        public bool findBookByID(int Id)
        {
            return true;
        }

        public bool findChapterById(int id)
        {
            return true;
        }

        public bool findVersebyId(int id)
        {
            return true;
        }
    }
}
