/// \file Service
///
/// \mainpage PROG2120 - Windows Mobile Programming Assignment 06 & Relational Databases Assignment 04 - Services & Windows Objects
///
/// \section intro Program Introduction
/// - This program creates a multi-threaded Windows Service that monitors requests from several Users and an Admin in order to 
///   query a database appropriately for administering a multiple choice game to users and the creation and/or change of the 
///   game by an Admin user. 
///
/// Major <b>Service.cs</b>
/// \section version Current version of this Program
/// <ul>
/// <li>\author         Marcus Rankin   (3379187)
///                     Geun Young Gil  (6944920)
///                     Ibrahim Naamani ()</li>
/// <li>\references     Norbert Mika - WMP Module 08
///                     Norbert Mika - RDB Module 05</li>
/// <li>\version        1.00.00</li>
/// <li>\date           2015.11.23</li>
/// <li>\pre            Nothing
/// <li>\warning        Nothing
/// <li>\copyright      Marcus Rankin, Geun Young Gil, Ibrahim Naamani
/// <ul>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Messaging;

namespace MultiChoiceService
{
    public partial class Service : ServiceBase
    {
        public static volatile bool running; ///< Message queue reading (thread) status
        Thread readMessage;             ///< Thread for reading local message queue
        private string messageQname;    ///< Service message queue name (serviceQ)
        MessageQueue messageQ;   ///< Service message queue

        public Service()
        {
            InitializeComponent();

            CanPauseAndContinue = true;  ///< Allow the Service to Pause or Continue
        }

        /// \brief  OnStart
        ///
        /// \details <b>Details</b>
        /// - What is to be executed by the service when started. 
        ///   In this case, a simple log is added.
        ///
        /// \param args - <b>string[]</b> - An array of arguments
        /// 
        /// \return <b>N/A</b> - N/A
        protected override void OnStart(string[] args)
        {
            running = true;

            messageQname = System.Environment.MachineName + "\\private$\\serviceQ";    // Machine name of the service computer and default queue name

            //Check if message queue exists
            if (!MessageQueue.Exists(messageQname))
            {
                MessageQueue.Create(messageQname);
            }

            messageQ = new MessageQueue(messageQname);  // Create service message queue
            messageQ.Purge();   // Clear/Delete all previous messages in the message queue
            readMessage = new Thread(new ThreadStart(ServiceConnectionQ));  // Create Service connection thread
            readMessage.Start();

            ServiceLogger.Log("Message Q Created");
        }

        /// \brief  OnStop
        ///
        /// \details <b>Details</b>
        /// - What is to be executed by the service when stopped. 
        ///   In this case, a simple log is added.
        ///
        /// \param N/A - <b>N/A</b> - N/A
        /// 
        /// \return <b>N/A</b> - N/A
        protected override void OnStop()
        {
            ServiceLogger.Log("Service Connection Reader has stopped!");
        }

        /// \brief  OnContinue
        ///
        /// \details <b>Details</b>
        /// - What is to be executed by the service when continued. 
        ///   In this case, a simple log is added.
        ///
        /// \param N/A - <b>N/A</b> - N/A
        /// 
        /// \return <b>N/A</b> - N/A
        protected override void OnContinue()
        {
            ServiceLogger.Log("Service Connection Reader is continuing!");
        }

        /// \brief  OnPause
        ///
        /// \details <b>Details</b>
        /// - What is to be executed by the service when paused. 
        ///   In this case, a simple log is added.
        ///
        /// \param N/A - <b>N/A</b> - N/A
        /// 
        /// \return <b>N/A</b> - N/A
        protected override void OnPause()
        {
            ServiceLogger.Log("Service Connection Reader has paused!");
        }

        /// \brief  ServiceConnectionQ
        ///
        /// \details <b>Details</b>
        /// - Thread function that constantly looks for new messages in the queue which contain
        ///   service commands for editing and accessing data from the multiple choice game database
        ///   (mcdatabase).
        ///
        /// \param N/A - <b>N/A</b> - N/A
        /// 
        /// \return <b>N/A</b> - N/A
        public void ServiceConnectionQ()
        {
            ServiceLogger.Log("Service Connection Reader Created.");

            // Set message format to the message package object
            messageQ.Formatter = new XmlMessageFormatter(new Type[] { typeof(MultiChoiceService.CommandData) });

            int userCount = 0;  ///< Counter for amount of current users (creates user queue name)
            int adminCount = 0; ///< Counter for amount of current admin (Only 1 allowed);

            List<Thread> userThreadList = new List<Thread>();

            //ThreadRepository userThreadRepo = new ThreadRepository();   ///< Create User thread repository
            Thread adminThread;
            adminThread = new Thread(new ParameterizedThreadStart(AdminMessageQ));

            Thread manageUsersThread = new Thread(new ParameterizedThreadStart(ManageUsersThreadFunction));  // Create Service connection thread
            manageUsersThread.Start(userThreadList);

            // Loop while service is running (looking for connections)
            while (running)
            {
                try
                {
                    // Get new connection message from the queue
                    System.Messaging.Message connectionMessage = messageQ.Receive();

                    ServiceLogger.Log("Connection Message Received");

                    // Save to message package
                    CommandData comData = (CommandData)connectionMessage.Body;

                    if (comData != null)
                    {

                        if (comData.userType == "User")
                        {
                            ++userCount;
                            comData.userCount = userCount;
                            Thread t = new Thread(new ParameterizedThreadStart(UserMessageQ));
                            userThreadList.Add(t);
                            //Thread t = userThreadRepo.Add(new ParameterizedThreadStart(UserMessageQ));
                            t.Start(comData);
                        }
                        else if (comData.userType == "Admin")
                        {
                            if (adminCount == 0)
                            {
                                ServiceLogger.Log("Admin Message Received");
                                ++adminCount;
                                //adminThread = new Thread(new ParameterizedThreadStart(AdminMessageQ));
                                adminThread.Start(comData);
                            }
                            else if (adminThread.IsAlive != true)
                            {
                                ServiceLogger.Log("Admin Thread is NOT alive");
                                adminThread.Join();
                                Thread.Sleep(50);
                                --adminCount;
                                ServiceLogger.Log("Admin Thread has rejoined and decremented: " + adminCount.ToString());
                                adminThread = new Thread(new ParameterizedThreadStart(AdminMessageQ));
                            }
                            else
                            {
                                comData.systemMessage = 'N';
                                ServiceLogger.Log("2nd Admin connection attempted! (Only 1 allowed!)");
                            }
                        }
                        else
                        {
                            comData.systemMessage = 'N';
                            ServiceLogger.Log("The default user type has been unlawfully changed or hacked!!!");
                        }

                        Thread.Sleep(50);
                    }
                }
                catch (MessageQueueException e)
                {
                    ServiceLogger.Log("Message Queue Exception Occurred: " + e.Message);
                }
                catch (InvalidOperationException e)
                {
                    ServiceLogger.Log("Invalid Operation Exception Occurred: " + e.Message);
                }
            }

            manageUsersThread.Join(); // Join up with the manage users thread
        }

        public void ManageUsersThreadFunction(object userThreadListObj)
        {
            List<Thread> userThreadList = (List<Thread>)userThreadListObj; ///< Case object back into user thread list

            // Check if the Service Connection running or if there are threads still in the list                                             
            while (running || userThreadList != null)
            {
                // Sleep for 30 seconds
                System.Threading.Thread.Sleep(30000);

                ServiceLogger.Log("User Thread List Count = " + userThreadList.Count.ToString());

                // Check each user thread to see if it has exited/closed
                for (int i = 0; i < userThreadList.Count; ++i)
                {
                    if (userThreadList[i].IsAlive != true)
                    {
                        // Join ended user thread and remove from user thread list
                        userThreadList[i].Join();
                        userThreadList.Remove(userThreadList[i]);
                    }
                }
            }

            // End when user thread list is empty and service connection thread has stopped
        }

        /// \brief  UserMessageQ
        ///
        /// \details <b>Details</b>
        /// - Thread function that communicates with users through their message queue and executes
        ///   service commands for accessing data from the multiple choice game database (mcdatabase).
        ///
        /// \param comData - <b>Object</b> - CommandData message package object
        /// 
        /// \return <b>N/A</b> - N/A
        public void UserMessageQ(Object userComData)
        {
            // Set user queue name to proper format
            CommandData comData = (CommandData)userComData; ///< Convert user queue name into a string
            string userQname = "FormatName:DIRECT=OS:";             
            userQname += comData.qName;   ///< Create users queue name string
            MessageQueue usersQueue = new MessageQueue(userQname);  ///< Users queue for communication/messaging
            System.Messaging.Message userMessage;   ///< Users message (message queue properties)
                                                    
            ServiceLogger.Log("New User Queue Created: " + userQname.ToString());

            DAL dbQuery = new DAL();    ///< Database query object

            // Local service message queue path
            string serviceQueueName = System.Environment.MachineName + "\\private$\\serviceQforUser"
                            + comData.userCount.ToString(); /// path continued with unique user number for unique user queue
            // Check if message queue exists
            if (!MessageQueue.Exists(serviceQueueName))
            {
                MessageQueue.Create(serviceQueueName);
            }

            MessageQueue serviceQueue = new MessageQueue(serviceQueueName); ///< Local service message queue
            serviceQueue.Purge();   // Clear service message queue on first run

            // Set message format to the message package object
            serviceQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(MultiChoiceService.CommandData) });

            // Setup Service queue name for user
            comData.qName = serviceQueueName;

            ServiceLogger.Log("New Service Queue Created: " + comData.qName.ToString());

            // Loop while service is running (looking for connections)
            while (comData.isRunning)
            {
                try
                {
                    if (comData.newGame)
                    {
                        ServiceLogger.Log("New Game Started By: " + comData.userCount.ToString());

                        comData.systemMessage = CommandData.GAMETABLE;      // Set table for adding user to GameTable
                        comData = dbQuery.WriteToDatabase(comData);         // Setup user/game in GameTable

                        comData.systemMessage = CommandData.GAMEID;         // Set table for getting users game ID
                        comData = dbQuery.ReadFromDatabase(comData);        // Get users game ID

                        comData.systemMessage = CommandData.LEADERBOARD;    // Set table to get Leader Board

                        comData = dbQuery.ReadFromDatabase(comData);        // Get Leader Board table

                        comData.newGame = false;                            // Set game to NOT new (to not enter here until the end of game)
                        usersQueue.Send(comData);                           // Send Leader Board to user
                    }

                    userMessage = serviceQueue.Receive();
                    comData = (CommandData)userMessage.Body;

                    // Save to message package
                    comData.questionId = ++comData.questionId; // Increment to next question

                    if (comData != null)
                    {
                        // If user is still in the game
                        if (comData.isRunning)
                        {
                            // On first request there is nothing to write to the database (questionTable read)
                            if (comData.questionId == 1)
                            {
                                // Get first question and send to user
                                comData = dbQuery.ReadFromDatabase(comData);
                                
                                usersQueue.Send(comData);
                            }
                            else if (comData.questionId > 10)
                            {
                                // All questions already answered (Game is Over)
                                comData.questionId = --comData.questionId;
                                comData.systemMessage = CommandData.USERSCORETABLE;

                                if (comData.answerId != comData.correctAnswer)
                                {
                                    comData.timeTaken = 0;
                                }

                                comData = dbQuery.WriteToDatabase(comData);         // Write previous answer data

                                comData.questionId = 0;                             // Reset question ID number
                                comData.newGame = true;                             // Reset game status to start new game
                                comData.systemMessage = CommandData.USERSCORETABLE; // Set table to user total game score
                                comData = dbQuery.ReadFromDatabase(comData);        // Get users game score table

                                usersQueue.Send(comData);                           // Send users game score table

                                // Add users game data to Leaderboard
                                comData.totalScore = (int)comData.table.Rows[0][2]; // Set users total game score
                                comData.systemMessage = CommandData.LEADERBOARD;    // Set table to Leader Board
                                comData = dbQuery.WriteToDatabase(comData);         // Write user game score to Leader Board

                                ServiceLogger.Log("Final game score added to Leader Board");

                                userMessage = serviceQueue.Receive();
                                comData = (CommandData)userMessage.Body;
                            }
                            // Every other question requires a write of previous questions data to database
                            else
                            {
                                // Write previous questions data to database then send next question to user (scoreTable write)
                                comData.questionId = --comData.questionId;
                                comData.systemMessage = CommandData.USERSCORETABLE;

                                if(comData.answerId != comData.correctAnswer)
                                {
                                    comData.timeTaken = 0;
                                }
                                comData = dbQuery.WriteToDatabase(comData);         // Write previous answer data

                                comData.questionId = ++comData.questionId;          // Increment to next question
                                comData.systemMessage = CommandData.QUESTIONTABLE;  // Set table type for next question
                                comData = dbQuery.ReadFromDatabase(comData);        // Read next question
                                usersQueue.Send(comData);                           // Send next question
                            }
                        }
                        else
                        {
                            ServiceLogger.Log("User: " + comData.userCount.ToString() + " has left the game.");
                        }

                        Thread.Sleep(50);
                    }
                }
                catch (MessageQueueException e)
                {
                    ServiceLogger.Log("Message Queue Exception Occurred: " + e.Message);
                }
                catch (InvalidOperationException e)
                {
                    ServiceLogger.Log("Invalid Operation Exception Occurred: " + e.Message);
                }
            }
        }

        /// \brief  AdminMessageQ
        ///
        /// \details <b>Details</b>
        /// - Thread function that communicates with users through their message queue and executes
        ///   service commands for accessing data from the multiple choice game database
        ///   (mcdatabase).
        ///
        /// \param N/A - <b>N/A</b> - N/A
        /// 
        /// \return <b>N/A</b> - N/A
        public void AdminMessageQ(Object adminComData)
        {
            ServiceLogger.Log("Admin Logged In!");
            // Set user queue name to proper format
            CommandData comData = (CommandData)adminComData; ///< Convert user queue name into a string
            string userQname = "FormatName:DIRECT=OS:";                                               
            userQname += comData.qName;   ///< Create users queue name string
            
            MessageQueue usersQueue = new MessageQueue(userQname);  ///< Users queue for communication/messaging
            System.Messaging.Message userMessage;   ///< Users message (message queue properties)

            ServiceLogger.Log("New Admin Queue Created");

            DAL dbQuery = new DAL();    ///< Database query object

            // Create Service message queue for communication with user
            string serviceQueueName = System.Environment.MachineName + "\\private$\\serviceQforAdmin"; /// path continued with unique user number for unique user queue
            // Check if message queue exists
            if (!MessageQueue.Exists(serviceQueueName))
            {
                MessageQueue.Create(serviceQueueName);
            }

            MessageQueue serviceQueue = new MessageQueue(serviceQueueName); ///< Local service message queue
            serviceQueue.Purge();   // Clear service message queue on first run

            ServiceLogger.Log("Admin-Service Queue created");

            // Set message format to the message package object
            serviceQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(MultiChoiceService.CommandData) });

            // Setup Service queue name for user
            comData.qName = serviceQueueName;                   // Send Service queue name for Admin
            comData.isRunning = true;                           // Set current service status
            comData.systemMessage = CommandData.ACCEPTED;       // Set current connection status
            usersQueue.Send(comData);                           // Send users game score table

            // Loop while Admin is connected
            while (comData.systemMessage != CommandData.DISCONNECT)
            {
                try
                {
                    // Get new connection message from the queue
                    userMessage = serviceQueue.Receive();
                    // Save to message package
                    comData = (CommandData)userMessage.Body;

                    if (comData.systemMessage != CommandData.DISCONNECT) // NewlyAdded
                    {
                        if (comData != null)
                        {

                            // On first request there is nothing to write to the database (questionTable read)
                            if (comData.systemMessage == CommandData.UPDATEQTABLE)
                            {
                                // Admin wants to update the question answer table
                                comData = dbQuery.WriteToDatabase(comData);         // Write new question to Question Table
                                comData.systemMessage = CommandData.UPDATEATABLE;   // Set table for updating Answer Table
                                comData = dbQuery.WriteToDatabase(comData);         // Write new answers to Answer Table
                                usersQueue.Send(comData);
                            }
                            else
                            {
                                // Admin wants to read data from the database
                                comData = dbQuery.ReadFromDatabase(comData);        // Get requested data from database for Admin
                                usersQueue.Send(comData);                           // Send requested data to Admin
                            }

                            Thread.Sleep(50);
                        }
                        else
                        {
                            ServiceLogger.Log("comData was NULL and skipped loop");
                        }
                    }
                }
                catch (MessageQueueException e)
                {
                    ServiceLogger.Log("Message Queue Exception Occurred: " + e.Message);
                }
                catch (InvalidOperationException e)
                {
                    ServiceLogger.Log("Invalid Operation Exception Occurred: " + e.Message);
                }
            }
        }
    }
}
