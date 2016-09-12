/// \file mainMenuForm
///
/// \class mainMenuForm
/// 
/// \brief 
/// - This source file contains all the methods for the client application.
///   It takes care of all the interaction between the Client and the program, it then
///   communicates with the server in order to produce and carry on the program.
///   
/// \author
/// - Ibrahim Naamani
/// 
/// \reference
/// - Norbert Mika: SET - Windows Mobile Programming - Modules 07 and Modules 08.
/// 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Messaging;

namespace WinJointDBAssignment_Client
{
    public partial class mainForm : Form
    {
        public const int MAX_NUM_ROUND = 10;    ///< The Maximum number of rounds in a game

        private int theTime;                    ///< The time to be sent to the server for score keeping
        private int theChosenAnswer;            ///< The user's chosen answer indicated by 1, 2, 3, or 4
        MsgQueControl mqc;                      ///< message queue connection controller

        CommandData comData;                    ///< The Command Data object that will be passed around between Client and server.

        /// \brief  mainForm
        ///
        /// \details <b>Details</b>
        /// - The constructor for the client's mainMenuForm.
        ///
        /// \param <b>N/A</b> - N/A
        ///  
        /// \return <b>N/A</b> - N/A
        public mainForm()
        {
            InitializeComponent();

            //Variable initialization
            comData = new CommandData();
            mqc = new MsgQueControl();

            theTime = 20;
            theChosenAnswer = 0;
        }

        /// \brief  btnSubmit_Click
        ///
        /// \details <b>Details</b>
        /// - When the submit button is clicked on the mainMenu this function gets executed.
        ///   This piece of code initalizes the information the user entered and then prepares them to 
        ///   be sent to the message queue.
        ///
        /// \param sender - <b>object</b> - The object being passed in
        /// \param e - <b>EventArgs</b> - The arguments for the event
        /// 
        /// \return <b>N/A</b> - N/A
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //When the submit button is clicked, we try to conncet to the server.
            try
            {
                comData =this.mqc.Connect(txtServerName.Text, "User", txtBoxUserName.Text);
                if (comData != null  )
                {
                    //If its successful then we disable the MainMenu panel & display the leaderboards panel
                    displayMainMenuPanel(false);
                    displayLeaderboardsPanel(true);
                }
            }
            catch (Exception ex)
            {
                //Otherwise we show an error box.
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK);
            }
        }



        /// \brief  displayMainMenuPanel
        ///
        /// \details <b>Details</b>
        /// - Enables and Makes the main menu panel visible
        ///
        /// \param status - <b>bool</b> - Whether to display or not (True / False)
        /// 
        /// \return <b>N/A</b> - N/A
        private void displayMainMenuPanel(bool status)
        {
            if (status == true)
            {
                pnlMainMenu.Enabled = true;
                pnlMainMenu.Visible = true;
            }
            else
            {
                pnlMainMenu.Enabled = false;
                pnlMainMenu.Visible = false;
            }
        }


        /// \brief  displayLeaderboardsPanel
        ///
        /// \details <b>Details</b>
        /// - Enables and Makes the leaderboards panel visible
        ///
        /// \param status - <b>bool</b> - Whether to display or not (True / False)
        /// 
        /// \return <b>N/A</b> - N/A
        private void displayLeaderboardsPanel(bool status)
        {
            if (status == true)
            {
                //Sets the dataGrid for the leaderboards from the Command data object's properties.
                this.dataGridLeaderBoards.DataSource = comData.table;
                pnlLeaderBoardsStartGame.Enabled = true;
                pnlLeaderBoardsStartGame.Visible = true;
            }
            else
            {
                pnlLeaderBoardsStartGame.Enabled = false;
                pnlLeaderBoardsStartGame.Visible = false;
            }
        }

        /// \brief  displayGamePanel
        ///
        /// \details <b>Details</b>
        /// - Enables and Makes the game panel visible
        ///
        /// \param status - <b>bool</b> - Whether to display or not (True / False)
        /// 
        /// \return <b>N/A</b> - N/A
        private void displayGamePanel(bool status)
        {
            if (status == true)
            {
                pnlTheGame.Enabled = true;
                pnlTheGame.Visible = true;
            }
            else
            {
                pnlTheGame.Enabled = false;
                pnlTheGame.Visible = false;
            }
        }

        /// \brief  displayEndScreen
        ///
        /// \details <b>Details</b>
        /// - Enables and Makes the End Screen panel visible
        ///
        /// \param status - <b>bool</b> - Whether to display or not (True / False)
        /// 
        /// \return <b>N/A</b> - N/A
        private void displayEndScreen(bool status)
        {
            if (status == true)
            {
                //Sets the dataGrid for the score from the Command data object's properties.
                this.dataGridScore.DataSource = comData.table;
                pnlEndGameScreen.Enabled = true;
                pnlEndGameScreen.Visible = true;
            }
            else
            {
                pnlEndGameScreen.Enabled = false;
                pnlEndGameScreen.Visible = false;
            }
        }


        /// \brief  timerCheckUserInput_Tick
        ///
        /// \details <b>Details</b>
        /// - When the timer is running, it constantly checks to see if all the fields on the 
        ///   main menu panel are not empty. If they aren't empty, then the submit button is enabled.
        ///   Otherwise, the submit button is disabled.
        /// 
        /// \param sender - <b>object</b> - The object being passed in
        /// \param e - <b>EventArgs</b> - The arguments for the event
        /// 
        /// \return <b>N/A</b> - N/A
        private void timerCheckUserInput_Tick(object sender, EventArgs e)
        {
            //Checks to make sure the textboxes have text within them.
            if ( !String.IsNullOrWhiteSpace(txtServerName.Text)  && !String.IsNullOrWhiteSpace(txtBoxUserName.Text))
            {
                //If they do then the button is enabled.
                btnSubmit.Enabled = true;
            }
            else
            {
                //Otherwise the button is disabled.
                btnSubmit.Enabled = false;
            }
        }

        /// \brief  startTheGame
        ///
        /// \details <b>Details</b>
        /// - The logic behind the game sits here. It also takes care of recieving the information from the server
        ///   in order to populate the game to display the information to the user accoridngly.
        ///
        /// \param  <b>N/A</b> - N/A
        /// 
        /// \return <b>N/A</b> - N/A
        private void startTheGame()
        {
            //Starts the timer to check if the user selected an answer.
            timerCheckIfAnswered.Enabled = true;

            //Set the contents of the question number from the comdata object.
            lblQuestionNumber.Text = comData.questionId.ToString();

            //As long as we're on a round bigger than 0 or less than or equal to 10 then we are playing the game
            if (comData.questionId <= mainForm.MAX_NUM_ROUND && comData.questionId > 0)
            {
                //Enabling the timer to score the user.
                timerPointsRemaining.Enabled = true;

                //Settings the text for the question and answers from the comdata object.
                lblTheQuestion.Text = comData.question;
                radioAnswer1.Text = comData.answer1;
                radioAnswer2.Text = comData.answer2;
                radioAnswer3.Text = comData.answer3;
                radioAnswer4.Text = comData.answer4;
            }
                //Otherwise we're not playing the game anymore. The game is finished
            else
            {
                //Turn off the timers
                timerCheckIfAnswered.Enabled = false;
                timerPointsRemaining.Enabled = false;
                timerCheckUserInput.Enabled = false;
                
                //Switch panels
                displayGamePanel(false);
                displayEndScreen(true);
            }
        }

        /// \brief  timerPointsRemaining_Tick
        ///
        /// \details <b>Details</b>
        /// - Counts down from 20 to score the user. If the timer hits 0, then the user ran out of time.
        ///
        /// \param sender - <b>object</b> - The object being passed in
        /// \param e - <b>EventArgs</b> - The arguments for the event
        /// 
        /// \return <b>N/A</b> - N/A
        private void timerPointsRemaining_Tick(object sender, EventArgs e)
        {
            //The timer for counting down for the score
            theTime--;
            lblTimeRemaining.Text = theTime.ToString();

            if (theTime <= 0)
            {
                theChosenAnswer = 0;
                //If the timer reaches 0 we just send the info to the server
                sendInfoToServer();
            }
        }

        /// \brief  btnSubmitAnswer_Click
        ///
        /// \details <b>Details</b>
        /// - When the submit answer button is clicked on theGame panel this function gets executed.
        ///   This function calls another function to submit the data to the server.
        ///
        /// \param sender - <b>object</b> - The object being passed in
        /// \param e - <b>EventArgs</b> - The arguments for the event
        /// 
        /// \return <b>N/A</b> - N/A
        private void btnSubmitAnswer_Click(object sender, EventArgs e)
        {
            //Disable the submitAnswer button
            btnSubmitAnswer.Enabled = false;
            sendInfoToServer();
        }

        /// \brief  sendInfoToServer
        ///
        /// \details <b>Details</b>
        /// - Packages the users answer into a comData object and sends it to the server
        ///   where it will be parsed and score the user accordingly. It also resets the score
        ///   for the next question
        ///
        /// \param <b>N/A</b> - N/A
        /// 
        /// \return <b>N/A</b> - N/A
        private void sendInfoToServer()
        {
            try
            {
                //Turn off timer, Reset the timer, Send the point.
                timerPointsRemaining.Enabled = false;
                timerCheckIfAnswered.Enabled = false;

                //Determine which radio answer was selected.
                if (radioAnswer1.Checked == true)
                {
                    theChosenAnswer = 1;
                }
                else if (radioAnswer2.Checked == true)
                {
                    theChosenAnswer = 2;
                }
                else if (radioAnswer3.Checked == true)
                {
                    theChosenAnswer = 3;
                }
                else if (radioAnswer4.Checked == true)
                {
                    theChosenAnswer = 4;
                }
                else
                {
                    theChosenAnswer = 0;
                }

                //Turn off all the radio buttons
                radioAnswer1.Checked = false;
                radioAnswer2.Checked = false;
                radioAnswer3.Checked = false;
                radioAnswer4.Checked = false;

                //Set the comData answer id to the chosen answer
                comData.answerId = theChosenAnswer;
                //Set the comdata time taken to the time remaining
                comData.timeTaken = theTime;

                //Sends the comData to the message queue for the server
                mqc.Send(comData);
                //Expect a response 'Z' meaning anything
                comData = mqc.Receive('Z');

                //Reset the lbl for the time back to 20
                theTime = 20;
                lblTimeRemaining.Text = theTime.ToString();
                //Enable the timer and start the game
                timerPointsRemaining.Enabled = true;
                startTheGame();
            }
            catch (Exception ex)
            {
                //Otherwise display the Message Box
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        /// \brief  btnPlayAgain_Click
        ///
        /// \details <b>Details</b>
        /// - When the submit button is clicked on the gameover screen this function gets executed.
        ///   This piece of code resets the variables and presents the user with the mainmenu screen again.
        ///
        /// \param sender - <b>object</b> - The object being passed in
        /// \param e - <b>EventArgs</b> - The arguments for the event
        /// 
        /// \return <b>N/A</b> - N/A
        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            //Reset the timer back to 20
            theTime = 20;

            //Send the data to the server
            mqc.Send(comData);
            //Wait for response
            comData = mqc.Receive('Z');

            //Switch panels
            displayEndScreen(false);
            displayLeaderboardsPanel(true);
        }


        /// \brief  checkIfAnswered_Tick
        ///
        /// \details <b>Details</b>
        /// - A timer constantly checking to see if the user selected an answer. If they did the submit answer is enabled
        ///   otherwise, it remains disabled.
        ///
        /// \param sender - <b>object</b> - The object being passed in
        /// \param e - <b>EventArgs</b> - The arguments for the event
        /// 
        /// \return <b>N/A</b> - N/A
        private void checkIfAnswered_Tick(object sender, EventArgs e)
        {
            //If one of the radio buttons is answered enable the submit button
            if (radioAnswer1.Checked == true || radioAnswer2.Checked == true || radioAnswer3.Checked == true || radioAnswer4.Checked == true)
            {
                btnSubmitAnswer.Enabled = true;
            }
            else
            {
                //otherwise don't enable to submit button
                btnSubmitAnswer.Enabled = false;
            }
        }

        /// \brief  mainMenuForm_FormClosing
        ///
        /// \details <b>Details</b>
        /// - When the user decides to close the aplication this will get fired clearing the message queues accordingly.
        ///
        /// \param sender - <b>object</b> - The object being passed in
        /// \param e - <b>EventArgs</b> - The arguments for the event
        /// 
        /// \return <b>N/A</b> - N/A
        private void mainMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //When the form is trying to close
            //Send one final message to the server telling it we're no longer running the game
            //This way they end gracefully.

            //Also, delete all the messages in the queue and disconnect it.
            try
            {
                if (comData.isRunning == true)
                {
                    comData.isRunning = false;
                    mqc.Send(comData);
                }

                mqc.DeleteAllMsgInMQueue();
                mqc.Disconnect();
                mqc.Exit();

            }
                //If an error occurs display the error in a message box.
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK);
            }
        }

        /// \brief  btnPlay_Click
        ///
        /// \details <b>Details</b>
        /// - When the play button is clicked on the leaderboard screen this function gets executed.
        ///   This piece of code retrives the information from the server and does its job accordingly.
        ///
        /// \param sender - <b>object</b> - The object being passed in
        /// \param e - <b>EventArgs</b> - The arguments for the event
        /// 
        /// \return <b>N/A</b> - N/A
        private void btnPlay_Click(object sender, EventArgs e)
        {
            try
            {
                //Request the questions
                comData.systemMessage = 'Q';
                mqc.Send(comData);

                //Expecting the question and answers
                comData = mqc.Receive('Z');

                //Change panels.
                displayLeaderboardsPanel(false);
                displayGamePanel(true);
                startTheGame();
            }
            catch (Exception ex)
            {
                //Display an error message
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}