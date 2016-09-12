namespace WinJointDBAssignment_Client
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlMainMenu = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtBoxUserName = new System.Windows.Forms.TextBox();
            this.lblServerName = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.lblAbout2 = new System.Windows.Forms.Label();
            this.lblAbout1 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.timerCheckUserInput = new System.Windows.Forms.Timer(this.components);
            this.pnlTheGame = new System.Windows.Forms.Panel();
            this.lblQuestionNumber = new System.Windows.Forms.Label();
            this.lblQuestionNumberTag = new System.Windows.Forms.Label();
            this.btnSubmitAnswer = new System.Windows.Forms.Button();
            this.lblTimeRemaining = new System.Windows.Forms.Label();
            this.lblTimeRemainingTag = new System.Windows.Forms.Label();
            this.radioAnswer4 = new System.Windows.Forms.RadioButton();
            this.radioAnswer3 = new System.Windows.Forms.RadioButton();
            this.radioAnswer2 = new System.Windows.Forms.RadioButton();
            this.radioAnswer1 = new System.Windows.Forms.RadioButton();
            this.lblTheQuestion = new System.Windows.Forms.Label();
            this.timerPointsRemaining = new System.Windows.Forms.Timer(this.components);
            this.pnlEndGameScreen = new System.Windows.Forms.Panel();
            this.dataGridScore = new System.Windows.Forms.DataGridView();
            this.btnPlayAgain = new System.Windows.Forms.Button();
            this.lblGameOver = new System.Windows.Forms.Label();
            this.timerCheckIfAnswered = new System.Windows.Forms.Timer(this.components);
            this.pnlLeaderBoardsStartGame = new System.Windows.Forms.Panel();
            this.lblLeaderboards = new System.Windows.Forms.Label();
            this.dataGridLeaderBoards = new System.Windows.Forms.DataGridView();
            this.btnPlay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMainMenu.SuspendLayout();
            this.pnlTheGame.SuspendLayout();
            this.pnlEndGameScreen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridScore)).BeginInit();
            this.pnlLeaderBoardsStartGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLeaderBoards)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMainMenu
            // 
            this.pnlMainMenu.Controls.Add(this.lblUserName);
            this.pnlMainMenu.Controls.Add(this.txtBoxUserName);
            this.pnlMainMenu.Controls.Add(this.lblServerName);
            this.pnlMainMenu.Controls.Add(this.txtServerName);
            this.pnlMainMenu.Controls.Add(this.lblAbout2);
            this.pnlMainMenu.Controls.Add(this.lblAbout1);
            this.pnlMainMenu.Controls.Add(this.btnSubmit);
            this.pnlMainMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMainMenu.Name = "pnlMainMenu";
            this.pnlMainMenu.Size = new System.Drawing.Size(424, 362);
            this.pnlMainMenu.TabIndex = 9;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(123, 96);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(63, 13);
            this.lblUserName.TabIndex = 10;
            this.lblUserName.Text = "User Name:";
            // 
            // txtBoxUserName
            // 
            this.txtBoxUserName.Location = new System.Drawing.Point(196, 92);
            this.txtBoxUserName.MaxLength = 40;
            this.txtBoxUserName.Name = "txtBoxUserName";
            this.txtBoxUserName.Size = new System.Drawing.Size(100, 20);
            this.txtBoxUserName.TabIndex = 1;
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(118, 135);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(72, 13);
            this.lblServerName.TabIndex = 11;
            this.lblServerName.Text = "Server Name:";
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(196, 131);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(100, 20);
            this.txtServerName.TabIndex = 2;
            // 
            // lblAbout2
            // 
            this.lblAbout2.AutoSize = true;
            this.lblAbout2.Location = new System.Drawing.Point(188, 260);
            this.lblAbout2.Name = "lblAbout2";
            this.lblAbout2.Size = new System.Drawing.Size(71, 13);
            this.lblAbout2.TabIndex = 16;
            this.lblAbout2.Text = "Team MiG-27";
            // 
            // lblAbout1
            // 
            this.lblAbout1.AutoSize = true;
            this.lblAbout1.Location = new System.Drawing.Point(192, 238);
            this.lblAbout1.Name = "lblAbout1";
            this.lblAbout1.Size = new System.Drawing.Size(62, 13);
            this.lblAbout1.TabIndex = 15;
            this.lblAbout1.Text = "Created By:";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Enabled = false;
            this.btnSubmit.Location = new System.Drawing.Point(186, 202);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // timerCheckUserInput
            // 
            this.timerCheckUserInput.Enabled = true;
            this.timerCheckUserInput.Tick += new System.EventHandler(this.timerCheckUserInput_Tick);
            // 
            // pnlTheGame
            // 
            this.pnlTheGame.Controls.Add(this.label1);
            this.pnlTheGame.Controls.Add(this.lblQuestionNumber);
            this.pnlTheGame.Controls.Add(this.lblQuestionNumberTag);
            this.pnlTheGame.Controls.Add(this.btnSubmitAnswer);
            this.pnlTheGame.Controls.Add(this.lblTimeRemaining);
            this.pnlTheGame.Controls.Add(this.lblTimeRemainingTag);
            this.pnlTheGame.Controls.Add(this.radioAnswer4);
            this.pnlTheGame.Controls.Add(this.radioAnswer3);
            this.pnlTheGame.Controls.Add(this.radioAnswer2);
            this.pnlTheGame.Controls.Add(this.radioAnswer1);
            this.pnlTheGame.Controls.Add(this.lblTheQuestion);
            this.pnlTheGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTheGame.Location = new System.Drawing.Point(0, 0);
            this.pnlTheGame.Name = "pnlTheGame";
            this.pnlTheGame.Size = new System.Drawing.Size(424, 362);
            this.pnlTheGame.TabIndex = 19;
            this.pnlTheGame.Visible = false;
            // 
            // lblQuestionNumber
            // 
            this.lblQuestionNumber.AutoSize = true;
            this.lblQuestionNumber.Location = new System.Drawing.Point(77, 47);
            this.lblQuestionNumber.Name = "lblQuestionNumber";
            this.lblQuestionNumber.Size = new System.Drawing.Size(13, 13);
            this.lblQuestionNumber.TabIndex = 0;
            this.lblQuestionNumber.Text = "?";
            // 
            // lblQuestionNumberTag
            // 
            this.lblQuestionNumberTag.AutoSize = true;
            this.lblQuestionNumberTag.Location = new System.Drawing.Point(12, 47);
            this.lblQuestionNumberTag.Name = "lblQuestionNumberTag";
            this.lblQuestionNumberTag.Size = new System.Drawing.Size(59, 13);
            this.lblQuestionNumberTag.TabIndex = 10;
            this.lblQuestionNumberTag.Text = "Question #";
            // 
            // btnSubmitAnswer
            // 
            this.btnSubmitAnswer.Enabled = false;
            this.btnSubmitAnswer.Location = new System.Drawing.Point(284, 238);
            this.btnSubmitAnswer.Name = "btnSubmitAnswer";
            this.btnSubmitAnswer.Size = new System.Drawing.Size(75, 23);
            this.btnSubmitAnswer.TabIndex = 8;
            this.btnSubmitAnswer.Text = "Submit";
            this.btnSubmitAnswer.UseVisualStyleBackColor = true;
            this.btnSubmitAnswer.Click += new System.EventHandler(this.btnSubmitAnswer_Click);
            // 
            // lblTimeRemaining
            // 
            this.lblTimeRemaining.AutoSize = true;
            this.lblTimeRemaining.Location = new System.Drawing.Point(310, 150);
            this.lblTimeRemaining.Name = "lblTimeRemaining";
            this.lblTimeRemaining.Size = new System.Drawing.Size(19, 13);
            this.lblTimeRemaining.TabIndex = 7;
            this.lblTimeRemaining.Text = "20";
            // 
            // lblTimeRemainingTag
            // 
            this.lblTimeRemainingTag.AutoSize = true;
            this.lblTimeRemainingTag.Location = new System.Drawing.Point(278, 131);
            this.lblTimeRemainingTag.Name = "lblTimeRemainingTag";
            this.lblTimeRemainingTag.Size = new System.Drawing.Size(86, 13);
            this.lblTimeRemainingTag.TabIndex = 6;
            this.lblTimeRemainingTag.Text = "Time Remaining:";
            // 
            // radioAnswer4
            // 
            this.radioAnswer4.AutoSize = true;
            this.radioAnswer4.Location = new System.Drawing.Point(58, 238);
            this.radioAnswer4.Name = "radioAnswer4";
            this.radioAnswer4.Size = new System.Drawing.Size(66, 17);
            this.radioAnswer4.TabIndex = 5;
            this.radioAnswer4.TabStop = true;
            this.radioAnswer4.Text = "Answer4";
            this.radioAnswer4.UseVisualStyleBackColor = true;
            // 
            // radioAnswer3
            // 
            this.radioAnswer3.AutoSize = true;
            this.radioAnswer3.Location = new System.Drawing.Point(58, 202);
            this.radioAnswer3.Name = "radioAnswer3";
            this.radioAnswer3.Size = new System.Drawing.Size(66, 17);
            this.radioAnswer3.TabIndex = 4;
            this.radioAnswer3.TabStop = true;
            this.radioAnswer3.Text = "Answer3";
            this.radioAnswer3.UseVisualStyleBackColor = true;
            // 
            // radioAnswer2
            // 
            this.radioAnswer2.AutoSize = true;
            this.radioAnswer2.Location = new System.Drawing.Point(58, 166);
            this.radioAnswer2.Name = "radioAnswer2";
            this.radioAnswer2.Size = new System.Drawing.Size(66, 17);
            this.radioAnswer2.TabIndex = 3;
            this.radioAnswer2.TabStop = true;
            this.radioAnswer2.Text = "Answer2";
            this.radioAnswer2.UseVisualStyleBackColor = true;
            // 
            // radioAnswer1
            // 
            this.radioAnswer1.AutoSize = true;
            this.radioAnswer1.Location = new System.Drawing.Point(58, 131);
            this.radioAnswer1.Name = "radioAnswer1";
            this.radioAnswer1.Size = new System.Drawing.Size(66, 17);
            this.radioAnswer1.TabIndex = 2;
            this.radioAnswer1.TabStop = true;
            this.radioAnswer1.Text = "Answer1";
            this.radioAnswer1.UseVisualStyleBackColor = true;
            // 
            // lblTheQuestion
            // 
            this.lblTheQuestion.AutoSize = true;
            this.lblTheQuestion.Location = new System.Drawing.Point(12, 71);
            this.lblTheQuestion.Name = "lblTheQuestion";
            this.lblTheQuestion.Size = new System.Drawing.Size(142, 13);
            this.lblTheQuestion.TabIndex = 1;
            this.lblTheQuestion.Text = "TheQuestionWillAppearHere";
            // 
            // timerPointsRemaining
            // 
            this.timerPointsRemaining.Interval = 1000;
            this.timerPointsRemaining.Tick += new System.EventHandler(this.timerPointsRemaining_Tick);
            // 
            // pnlEndGameScreen
            // 
            this.pnlEndGameScreen.Controls.Add(this.dataGridScore);
            this.pnlEndGameScreen.Controls.Add(this.btnPlayAgain);
            this.pnlEndGameScreen.Controls.Add(this.lblGameOver);
            this.pnlEndGameScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEndGameScreen.Enabled = false;
            this.pnlEndGameScreen.Location = new System.Drawing.Point(0, 0);
            this.pnlEndGameScreen.Name = "pnlEndGameScreen";
            this.pnlEndGameScreen.Size = new System.Drawing.Size(424, 362);
            this.pnlEndGameScreen.TabIndex = 10;
            this.pnlEndGameScreen.Visible = false;
            // 
            // dataGridScore
            // 
            this.dataGridScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridScore.Enabled = false;
            this.dataGridScore.Location = new System.Drawing.Point(15, 47);
            this.dataGridScore.Name = "dataGridScore";
            this.dataGridScore.Size = new System.Drawing.Size(397, 251);
            this.dataGridScore.TabIndex = 2;
            // 
            // btnPlayAgain
            // 
            this.btnPlayAgain.Location = new System.Drawing.Point(179, 304);
            this.btnPlayAgain.Name = "btnPlayAgain";
            this.btnPlayAgain.Size = new System.Drawing.Size(75, 23);
            this.btnPlayAgain.TabIndex = 1;
            this.btnPlayAgain.Text = "Play Again!";
            this.btnPlayAgain.UseVisualStyleBackColor = true;
            this.btnPlayAgain.Click += new System.EventHandler(this.btnPlayAgain_Click);
            // 
            // lblGameOver
            // 
            this.lblGameOver.AutoSize = true;
            this.lblGameOver.Location = new System.Drawing.Point(176, 14);
            this.lblGameOver.Name = "lblGameOver";
            this.lblGameOver.Size = new System.Drawing.Size(74, 13);
            this.lblGameOver.TabIndex = 0;
            this.lblGameOver.Text = "GAME OVER!";
            // 
            // timerCheckIfAnswered
            // 
            this.timerCheckIfAnswered.Tick += new System.EventHandler(this.checkIfAnswered_Tick);
            // 
            // pnlLeaderBoardsStartGame
            // 
            this.pnlLeaderBoardsStartGame.Controls.Add(this.lblLeaderboards);
            this.pnlLeaderBoardsStartGame.Controls.Add(this.btnPlay);
            this.pnlLeaderBoardsStartGame.Controls.Add(this.dataGridLeaderBoards);
            this.pnlLeaderBoardsStartGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeaderBoardsStartGame.Enabled = false;
            this.pnlLeaderBoardsStartGame.Location = new System.Drawing.Point(0, 0);
            this.pnlLeaderBoardsStartGame.Name = "pnlLeaderBoardsStartGame";
            this.pnlLeaderBoardsStartGame.Size = new System.Drawing.Size(424, 362);
            this.pnlLeaderBoardsStartGame.TabIndex = 17;
            this.pnlLeaderBoardsStartGame.Visible = false;
            // 
            // lblLeaderboards
            // 
            this.lblLeaderboards.AutoSize = true;
            this.lblLeaderboards.Location = new System.Drawing.Point(179, 14);
            this.lblLeaderboards.Name = "lblLeaderboards";
            this.lblLeaderboards.Size = new System.Drawing.Size(75, 13);
            this.lblLeaderboards.TabIndex = 2;
            this.lblLeaderboards.Text = "Leaderboards:";
            // 
            // dataGridLeaderBoards
            // 
            this.dataGridLeaderBoards.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridLeaderBoards.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridLeaderBoards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLeaderBoards.Location = new System.Drawing.Point(15, 47);
            this.dataGridLeaderBoards.Name = "dataGridLeaderBoards";
            this.dataGridLeaderBoards.Size = new System.Drawing.Size(397, 251);
            this.dataGridLeaderBoards.TabIndex = 1;
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(175, 327);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Play!";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "What Movie Are These Arnold Quotes From? ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 362);
            this.Controls.Add(this.pnlTheGame);
            this.Controls.Add(this.pnlLeaderBoardsStartGame);
            this.Controls.Add(this.pnlEndGameScreen);
            this.Controls.Add(this.pnlMainMenu);
            this.Name = "mainForm";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainMenuForm_FormClosing);
            this.pnlMainMenu.ResumeLayout(false);
            this.pnlMainMenu.PerformLayout();
            this.pnlTheGame.ResumeLayout(false);
            this.pnlTheGame.PerformLayout();
            this.pnlEndGameScreen.ResumeLayout(false);
            this.pnlEndGameScreen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridScore)).EndInit();
            this.pnlLeaderBoardsStartGame.ResumeLayout(false);
            this.pnlLeaderBoardsStartGame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLeaderBoards)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMainMenu;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblAbout2;
        private System.Windows.Forms.Label lblAbout1;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtBoxUserName;
        private System.Windows.Forms.Timer timerCheckUserInput;
        private System.Windows.Forms.Panel pnlTheGame;
        private System.Windows.Forms.Label lblTheQuestion;
        private System.Windows.Forms.Label lblQuestionNumber;
        private System.Windows.Forms.Button btnSubmitAnswer;
        private System.Windows.Forms.Label lblTimeRemaining;
        private System.Windows.Forms.Label lblTimeRemainingTag;
        private System.Windows.Forms.RadioButton radioAnswer4;
        private System.Windows.Forms.RadioButton radioAnswer3;
        private System.Windows.Forms.RadioButton radioAnswer2;
        private System.Windows.Forms.RadioButton radioAnswer1;
        private System.Windows.Forms.Timer timerPointsRemaining;
        private System.Windows.Forms.Panel pnlEndGameScreen;
        private System.Windows.Forms.Button btnPlayAgain;
        private System.Windows.Forms.Label lblGameOver;
        private System.Windows.Forms.Label lblQuestionNumberTag;
        private System.Windows.Forms.Timer timerCheckIfAnswered;
        private System.Windows.Forms.Panel pnlLeaderBoardsStartGame;
        private System.Windows.Forms.Label lblLeaderboards;
        private System.Windows.Forms.DataGridView dataGridLeaderBoards;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.DataGridView dataGridScore;
        private System.Windows.Forms.Label label1;
    }
}

