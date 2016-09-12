/// \file CommandData.cs
///
/// \class CommandData
/// 
/// \brief 
/// - This class sets up the structure for sending and receiving messages through the message queue.
///   
/// \author
/// - Marcus Rankin, Ibrahim Naamani, Geun Young Gil
/// 
/// \reference
/// - Norbert Mika: SET - Windows Mobile Programming - Module 08.
/// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WinJointDBAssignment_Client
{
    public class CommandData
    {
        /* System Connection Protocol */
        public const char CONNECT = 'C';        ///< Service connection requested
        public const char ACCEPTED = 'A';       ///< Connection accepted
        public const char NOTACCEPTED = 'N';    ///< Connection not accepted
        public const char DISCONNECT = 'D';      ///< Service disconnect requested

        /* System Database Query Protocol */
        public const char GAMETABLE = 'G';      ///< For adding new game/user to game table and retrieving end of game results for user
        public const char QUESTIONTABLE = 'Q';  ///< For User to retrieve a single question and answer
        public const char UPDATEQTABLE = 'U';   ///< For Admin to UPDATE the Question and Answer Tables
        public const char UPDATEATABLE = 'V';   ///< For Service to UPDATE the Answer Table for Admin
        public const char LEADERBOARD = 'L';    ///< Leaderboard requested (ADMIN & USER)
        public const char SCORETABLE = 'S';     ///< Scoretable requested (ADMIN)
        public const char USERSCORETABLE = 'T'; ///< Game score table (USER)
        public const char GAMEID = 'I';         ///< Game ID for adding new user game to Game Table (SERVICE/USER)
        public const char QABOARD = 'B';        ///< Question and Answer boards requested (ADMIN)
        public const char APBOARD = 'P';        ///< QuestionID, Question, Average and Percentage board requested (ADMIN)

        /* User Specific Information */
        public int userCount;      ///< User number for creating unique user message queue on Service computer
        public char systemMessage; ///< System message
        public string userType;    ///< User type (User or Admin)
        public string qName;       ///< Specific message queue name for each user

        /* Admin Specific Information */
        public int numberOfRows;   ///< For notifying Admin result of query

        /* GamesTable */
        public bool newGame;       ///< Is this the start of a new game
        public int gameId;         ///< Game ID number (Auto_Increments in database)
        public string userName;    ///< User name 
        public bool isRunning;     ///< Is the current game running 
        ///  (for displaying questions to the user or LIVE results to Admin)

        /* QuestionTable */
        public int questionId;     ///< Question number (Set: 1 - 10)
        public string question;    ///< Question (actual question string)

        /* AnswersTable */
        public int answerId;       ///< Answer ID number related to Question ID
        public string answer1;     ///< First possible answer to question
        public string answer2;     ///< Second possible answer to question
        public string answer3;     ///< Third possible answer to question
        public string answer4;     ///< Fourth possible answer to question
        public int correctAnswer;  ///< Correct answer to question

        /* ScoreTable */
        /// Note: ScoreTable has gameID and QuestionID from GamesTable and QuestionTable
        public int timeTaken;     ///< Users points per question (based on timeframe answered)

        /* LeaderBoardTable */
        /// Note: LeaderBoardTable has gameID 
        public int totalScore;     ///< Total score of game

        /* Office Automation */
        public double average;     ///< Average time to answer questions
        public double percentage;  ///< Percentage of answering questions correctly

        /* Data Table */
        public DataTable table;   ///< Table for returning query data for displaying

        // CommandData Package Constructor
        public CommandData()
        {
            // Default settings for new CommandData package
            userCount = 0;
            systemMessage = ' ';
            userType = "User";  /// Default is User unless specified by Admin
            qName = "serviceQ"; /// Default is the Services main queue for connecting
            newGame = true;
            gameId = 0;
            userName = "";
            isRunning = false;   /// Default is false to allow user to see Leaderboard and choose when to start game
            questionId = 0;
            question = "";
            timeTaken = 0;
            answerId = 0;
            answer1 = "";
            answer2 = "";
            answer3 = "";
            answer4 = "";
            correctAnswer = 0;
            totalScore = 0;

            // Office Automation (calculated, not in tables)
            average = 0.0;
            percentage = 0.0;
        }
    }
}
