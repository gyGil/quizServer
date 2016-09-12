/// \file DAL.cs
///
/// \class DAL
/// 
/// \brief 
/// - This source file contains all the methods for sending and receiving data from
///   the mcDatabase (MultiChoiceDatabase). It will build the database queries by
///   utilizing the CommandData packages sent from either the Users or Admin.
///   
/// \author
/// - Marcus Rankin
/// 
/// \reference
/// - Norbert Mika: SET - Windows Mobile Programming - Modules 07 and Modules 08.
/// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MultiChoiceService
{
    class DAL
    {
        private MySqlConnection connection; ///< MySQL connection
        private string server;              ///< Server name/location
        private string database;            ///< Database name
        private string username;            ///< Database username login
        private string password;            ///< Database password login
        MySqlCommand cmd;                   ///< MySQL command statement
        MySqlDataReader reader;             ///< MySQL database data reader
                                            
        private string connectionString;    ///< MySQL connection parameters
        private string sqlCmd;              ///< MySQL query command string
        private int numOfRows;              ///< Number of rows affected by the query
        

        /// \brief  DAL
        ///
        /// \details <b>Details</b>
        /// - DAL Constructor. Sets up the MultiChoiceDatabase connection parameters and
        ///   the connection/command strings.
        ///
        /// \param N/A - <b>N/A</b> - N/A
        /// 
        /// \return <b>N/A</b> - N/A
        public DAL()
        {
            /* MySQL connection settings */
            server = "localhost";
            database = "mcdatabase";
            username = "root";
            password = "root";
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database
                                        + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            sqlCmd = "";
            numOfRows = 0;

            connection = new MySqlConnection(connectionString);
        }

        /// \brief  WriteToDatabase
        ///
        /// \details <b>Details</b>
        /// - Builds correct MySQL query strings from a CommandData package in order
        ///   to properly write (INSERT) data into the MultiChoiceDatabase (mcdatabase).
        ///
        /// \param comData - <b>CommandData</b> - Users or Admins data package
        /// 
        /// \return numOfRows <b>int</b> - Returns the number of rows affected by the database query
        public CommandData WriteToDatabase(CommandData comData)
        {
            /* Check which table in the mcdatabase is to be assessed */
            
                // Games Table
            if (comData.systemMessage == CommandData.GAMETABLE)
            {
                sqlCmd = "INSERT INTO gametable (userName, isRunning) " +
                          "VALUES ('" + comData.userName + "', " + comData.isRunning + ");";
            }
                // Update Games Table (when user finishes game)
            else if (comData.systemMessage == CommandData.UPDATEGAMETABLE)
            {
                sqlCmd = "UPDATE gametable SET isRunning = " + comData.isRunning +
                          " WHERE gameId = " + comData.gameId + ";";
            }
                // Question Table
            else if (comData.systemMessage == CommandData.UPDATEQTABLE)
            {
                sqlCmd = "UPDATE questiontable SET question = '" + comData.question +
                          "' WHERE questionId = " + comData.questionId + ";";

            }
                // Answers Table
            else if (comData.systemMessage == CommandData.UPDATEATABLE)
            {
                sqlCmd = "UPDATE answerstable SET answer1 = '" + comData.answer1 + "', answer2 = '" + comData.answer2 + 
                          "', answer3 = '" + comData.answer3 + "', answer4 = '" + comData.answer4 + "', correctAnswer = " + 
                            comData.correctAnswer + " WHERE answerId = " + comData.answerId + ";";
            }
            // Score Table
            else if (comData.systemMessage == CommandData.USERSCORETABLE)
            {
                ServiceLogger.Log("Inside User Score Table SQL Comm");

                sqlCmd = "INSERT INTO scoretable (gameId, questionId, timeTaken) " +
                          "VALUES (" + comData.gameId + ", " + comData.questionId + ", " + comData.timeTaken + ");";
            }
                // Leader Board Table
            else if (comData.systemMessage == CommandData.LEADERBOARD)
            {
                sqlCmd = "INSERT INTO leaderboardtable (gameId, totalScore) " +
                          "VALUES (" + comData.gameId + ", " + comData.totalScore + ");";
            }
            else
            {
                ServiceLogger.Log("Unable to read table type!");
                return comData;
            }

            /* Write data to the database */
            try
            {
                connection.Open(); // Open connection to database
                
                cmd = new MySqlCommand(sqlCmd, connection);
               
                cmd.Connection = connection; // Assign connection parameters
 
                numOfRows = cmd.ExecuteNonQuery();  // Execute the query and return number of rows affected
  
                comData.numberOfRows = numOfRows;   // Save the number of rows returned from query for Admin reference
            }
            catch (Exception e)
            {
                ServiceLogger.Log("Exception Occurred: " + e.Message);
            }
            finally
            {
                // Close the database connection if still open
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return comData;
        }

        /// \brief  ReadFromDatabase
        ///
        /// \details <b>Details</b>
        /// - Builds correct MySQL query strings from a CommandData package in order
        ///   to properly read (SELECT) data from the MultiChoiceDatabase (mcdatabase).
        ///
        /// \param comData - <b>CommandData</b> - Users or Admins data package
        /// 
        /// \return comData <b>CommandData</b> - Returns the Command Data object originally sent
        public CommandData ReadFromDatabase(CommandData comData)
        {
            ServiceLogger.Log("Read From Database Occurred.");

            /* Live gameplay statement for Admin ONLY! */
            if (comData.systemMessage == CommandData.SCORETABLE)
            {
                sqlCmd = "SELECT userName, gameTable.gameId, questionId, timeTaken FROM gameTable " +
                            "INNER JOIN scoreTable ON gameTable.gameId = scoreTable.gameId;";
            }
            /* Question & Answer Table statement for Admin ONLY! */
            else if (comData.systemMessage == CommandData.QABOARD)
            {
                sqlCmd = "SELECT questionId, question, answerId, answer1, answer2, answer3, answer4, correctAnswer " +
                            "FROM questionTable INNER JOIN answersTable ON questionId = answerId WHERE questionId = " +
                                comData.questionId + ";";
            }
            /* Office Automation (Average & Percentage Values) for Admin ONLY! */
            else if (comData.systemMessage == CommandData.APBOARD)
            {
                sqlCmd = @"SELECT DISTINCT q.questionID, q.question, SUM(a.timeTaken)/COUNT(a.timeTaken) AS averageTime, COUNT(b.timeTaken)/COUNT(a.timeTaken)*100 AS percentage   FROM questiontable q " +
                    @"LEFT OUTER JOIN scoretable a  ON q.questionID = a.questionID AND a.timeTaken >= 0 " +
                    @"LEFT OUTER JOIN scoretable b  ON q.questionID = b.questionID AND a.timeTaken > 0 " +
                    @"GROUP BY q.questionID;"; // 
            }
            /* Leader board statement for Users & Admin */
            else if (comData.systemMessage == CommandData.LEADERBOARD)
            {
                sqlCmd = "SELECT userName, totalScore FROM gameTable INNER JOIN leaderBoardTable " +
                            "ON gameTable.gameId = leaderBoardTable.gameId ORDER BY totalScore DESC;";
            }
            /* Question & Answer Table statement for Users Game */
            else if (comData.systemMessage == CommandData.QUESTIONTABLE)
            {
                sqlCmd = "SELECT question, answer1, answer2, answer3, answer4, correctAnswer FROM questionTable " +
                            "INNER JOIN answersTable ON questionTable.questionId = answersTable.answerId " +
                                "WHERE questionTable.questionId = " + comData.questionId + ";";
            }
            /* Game Table statement for returning User gameID during first connect */
            else if (comData.systemMessage == CommandData.GAMEID)
            {
                sqlCmd = "SELECT MAX(gameId) FROM gameTable WHERE userName = '" + comData.userName + "';";
            }
            /* User Game Table statement for end of game results */
            else if (comData.systemMessage == CommandData.GAMETABLE)
            {
                sqlCmd = "SELECT userName, gameTable.gameId, questionId, timeTaken FROM gameTable " +
                            "INNER JOIN scoreTable ON gameTable.gameId = scoreTable.gameId " +
                                "WHERE gameTable.gameId = " + comData.gameId + ";";
            }
            /* User Total Score results statement */
            else if (comData.systemMessage == CommandData.USERSCORETABLE)
            {
                sqlCmd = "SELECT userName, scoreTable.gameId, SUM(timeTaken) FROM gameTable " +
                            "INNER JOIN scoreTable ON gameTable.gameId = scoreTable.gameId " +
                                "WHERE gameTable.gameId = " + comData.gameId + ";";
            }
            else
            {
                ServiceLogger.Log("Unable to read table type!");
                return comData;
            }

            try
            {
                comData.table = new System.Data.DataTable();    // Create Data Table for returning database query infl

                ServiceLogger.Log("MySQL Database Connection Opened!");

                cmd = new MySqlCommand(sqlCmd, connection);

                connection.Open();

                if (comData.systemMessage != CommandData.GAMEID)
                {
                    reader = cmd.ExecuteReader();
                }

                // Build Score Table and add to CommandData object
                if (comData.systemMessage == CommandData.SCORETABLE)
                {
                    // Create Columns for Score Table
                    comData.table.Columns.Add("User Name", typeof(string));
                    comData.table.Columns.Add("Game ID", typeof(int));
                    comData.table.Columns.Add("Question ID", typeof(int));
                    comData.table.Columns.Add("Time Taken", typeof(int));

                    // Set Table Name
                    comData.table.TableName = "SCORETABLE";

                    // Add all table rows from database
                    while (reader.Read())
                    {
                        // Create Rows from Score table
                        comData.table.Rows.Add(reader["userName"].ToString(), reader["gameId"].ToString(), 
                                                reader["questionId"].ToString(), reader["timeTaken"].ToString());
                    }
                }
                // Build Question & Answer Table and add to CommandData object
                else if (comData.systemMessage == CommandData.QABOARD)
                {
                    // Set Table Name
                    comData.table.TableName = "QUESTION&ANSWERBOARD";

                    // Add all table rows from database
                    while (reader.Read())
                    {
                        // Create Rows from Question & Answer tables
                        Int32.TryParse(reader["questionId"].ToString(), out comData.questionId);

                        comData.question = reader["question"].ToString();
                        comData.answer1 = reader["answer1"].ToString();
                        comData.answer2 = reader["answer2"].ToString();
                        comData.answer3 = reader["answer3"].ToString();
                        comData.answer4 = reader["answer4"].ToString();
                        Int32.TryParse(reader["correctAnswer"].ToString(), out comData.correctAnswer);
                    }
                }
                // Build Average & Percentage Table and add to CommandData object
                else if (comData.systemMessage == CommandData.APBOARD)
                {
                    // Create Columns for Average & Percentage Table
                    comData.table.Columns.Add("Question ID", typeof(int));
                    comData.table.Columns.Add("Question", typeof(string));
                    comData.table.Columns.Add("Average Time", typeof(string));
                    comData.table.Columns.Add("Correctly Answered Percentage", typeof(string));

                    // Set Table Name
                    comData.table.TableName = "AVERAGE&PERCENTAGEBOARD";

                    // Add all table rows from database
                    while (reader.Read())
                    {
                        comData.table.Rows.Add(reader["questionID"].ToString(), reader["question"].ToString(), reader["averageTime"].ToString(), reader["percentage"].ToString());

                    }
                }
                // Build Leader Board Table and add to CommandData object
                else if (comData.systemMessage == CommandData.LEADERBOARD)
                {
                    // Create Columns for Leader Board Table
                    comData.table.Columns.Add("User Name", typeof(string));
                    comData.table.Columns.Add("Total Score", typeof(int));

                    // Set Table Name
                    comData.table.TableName = "LEADERBOARD";

                    // Add all table rows from database
                    while (reader.Read())
                    {
                        // Create Rows from Leader Board table
                        comData.table.Rows.Add(reader["userName"].ToString(), reader["totalScore"].ToString());
                    }
                }
                // Build Single Question and possible Answers Table and add to CommandData object
                else if (comData.systemMessage == CommandData.QUESTIONTABLE)
                {
                    // Set Table Name
                    comData.table.TableName = "QUESTIONTABLE";

                    // Add all table rows from database
                    while (reader.Read())
                    {
                        // Create Rows from Leader Board table
                        comData.question = reader["question"].ToString();
                        comData.answer1 = reader["answer1"].ToString();
                        comData.answer2 = reader["answer2"].ToString();
                        comData.answer3 = reader["answer3"].ToString();
                        comData.answer4 = reader["answer4"].ToString();
                        Int32.TryParse(reader["correctAnswer"].ToString(), out comData.correctAnswer);
                    }
                }
                // Get Users gameID during first connect and return for game data assignment
                else if (comData.systemMessage == CommandData.GAMEID)
                {
                     object gameId = cmd.ExecuteScalar();
                     comData.gameId = Convert.ToInt32(gameId);
                }
                // Build Game Score Table and add to CommandData object
                else if (comData.systemMessage == CommandData.GAMETABLE)
                {
                    // Create Columns for Score Table
                    comData.table.Columns.Add("User Name", typeof(string));
                    comData.table.Columns.Add("Game ID", typeof(int));
                    comData.table.Columns.Add("Question ID", typeof(int));
                    comData.table.Columns.Add("Time Taken", typeof(int));

                    // Set Table Name
                    comData.table.TableName = "GAMETABLE";

                    // Add all table rows from database
                    while (reader.Read())
                    {
                        // Create Rows from Score table
                        comData.table.Rows.Add(reader["userName"].ToString(), reader["gameId"].ToString(),
                                                reader["questionId"].ToString(), reader["timeTaken"].ToString());
                    }
                }
                // Build Total Score Table and add to CommandData object
                else if (comData.systemMessage == CommandData.USERSCORETABLE)
                {
                    // Create Columns for Score Table
                    comData.table.Columns.Add("User Name", typeof(string));
                    comData.table.Columns.Add("Game", typeof(int));
                    comData.table.Columns.Add("Total Score", typeof(int));

                    // Set Table Name
                    comData.table.TableName = "USERSCORETABLE";

                    // Add all table rows from database
                    while (reader.Read())
                    {
                        // Create Rows from Score table
                        comData.table.Rows.Add(reader["userName"].ToString(), reader["gameId"].ToString(),
                                                reader["SUM(timeTaken)"].ToString());
                    }
                }
                else
                {
                    ServiceLogger.Log("Unable to read table type!");
                }
            }
            catch (Exception e)
            {
                ServiceLogger.Log("Exception Occured: " + e.Message);
            }
            finally
            {
                if(connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    ServiceLogger.Log("MySQL Database Connection Closed.");
                }
            }

           return comData;
        }
    }
}
