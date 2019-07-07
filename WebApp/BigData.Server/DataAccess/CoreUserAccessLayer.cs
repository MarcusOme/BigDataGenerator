using BigData.Shared.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Z.Dapper.Plus;

namespace BigData.Server.DataAccess
{
    public class CoreUserAccessLayer : DataAccessgeneral
    {
        //create the connection object
        CoreUserContext db = new CoreUserContext();
        
        /// <summary>
        /// Function to get all the users present inside the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CoreUser> getAllUer()
        {
            using (var connection = new SqlConnection(conn_str))
            {
                var userList = connection.Query<CoreUser>("SELECT * FROM tblCoreUser").ToList();
                return userList;
            }
        }

        public void InsertUser()
        {
            using (var connection = new SqlConnection(conn_str))
            {
                try
                {
                    //load the name and surname list
                    string[] allNames = File.ReadAllText(@"Content\english_names.txt").Split(
                        new[] { ' ', '\n', '\r', ',', ';', ':', '.', '!', '?', '-' },
                        StringSplitOptions.RemoveEmptyEntries
                        );

                    string[] allSurnames = File.ReadAllText(@"Content\english_surnames.txt").Split(
                        new[] { ' ', '\n', '\r', ',', ';', ':', '.', '!', '?', '-' },
                        StringSplitOptions.RemoveEmptyEntries
                        );

                    List<string> allLanguages = new List<string>();
                    string[] lines = File.ReadAllLines(@"Content\languages.txt");
                    foreach (string s in lines)
                    {
                        var array = s.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                        allLanguages.Add(array[1]);
                    }

                    //create the association using a random function
                    int numberOfUsers = 20000;   //use this value to set the number of users to create

                    //set database for fast insertion

                    List<CoreUser> users = new List<CoreUser>();
                    Random rand = new Random();
                    Random rand2 = new Random();
                    Random rand3 = new Random();
                    Random rand4 = new Random();
                    for (int i = 0; i < numberOfUsers; i++)
                    {


                        int tmp1 = rand.Next(0, allNames.Length);
                        int tmp2 = rand.Next(0, allSurnames.Length);
                        int tmp3 = rand.Next(0, 730);   //two year span
                        int tmp4 = rand.Next(0, allLanguages.Count());

                        CoreUser tmp = new CoreUser()
                        {
                            FirstName = allNames[tmp1],
                            LastName = allSurnames[tmp2],
                            Nation = allLanguages.ElementAt(tmp4),
                            InsertDate = DateTime.Now.AddDays(-tmp3)
                        };
                        //add to list
                        users.Add(tmp);
                        //db.tblCoreUser.Add(tmp);

                        //save to avoid overload on db
                        if (i % 10000 == 0)
                        {

                            //db.tblCoreUser.AddRange(users);
                            //db.SaveChanges();
                            connection.BulkInsert(users);
                            //empty the list
                            users.Clear();
                            //db = new CoreUserContext();

                        }

                    }

                    if (users.Count() > 0)
                    {
                        //db = new CoreUserContext();
                        //db.tblCoreUser.AddRange(users);
                        //db.SaveChanges();
                        connection.BulkInsert(users);
                        users.Clear();
                    }
                    
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
