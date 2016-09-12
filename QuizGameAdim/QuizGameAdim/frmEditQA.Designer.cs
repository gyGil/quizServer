namespace QuizGameAdim
{
    partial class frmEditQA
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
            this.tbQnum = new System.Windows.Forms.TextBox();
            this.btnGetQA = new System.Windows.Forms.Button();
            this.lbQnum = new System.Windows.Forms.Label();
            this.lbQ = new System.Windows.Forms.Label();
            this.lbAns1 = new System.Windows.Forms.Label();
            this.lbAns4 = new System.Windows.Forms.Label();
            this.lbAns3 = new System.Windows.Forms.Label();
            this.lbAns2 = new System.Windows.Forms.Label();
            this.tbQuestion = new System.Windows.Forms.TextBox();
            this.tbAns1 = new System.Windows.Forms.TextBox();
            this.tbAns2 = new System.Windows.Forms.TextBox();
            this.tbAns3 = new System.Windows.Forms.TextBox();
            this.tbAns4 = new System.Windows.Forms.TextBox();
            this.btnSubQA = new System.Windows.Forms.Button();
            this.lbCA = new System.Windows.Forms.Label();
            this.tbCorrectAnswer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbQnum
            // 
            this.tbQnum.BackColor = System.Drawing.SystemColors.Info;
            this.tbQnum.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbQnum.Location = new System.Drawing.Point(161, 17);
            this.tbQnum.Name = "tbQnum";
            this.tbQnum.Size = new System.Drawing.Size(41, 27);
            this.tbQnum.TabIndex = 0;
            // 
            // btnGetQA
            // 
            this.btnGetQA.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetQA.ForeColor = System.Drawing.Color.Red;
            this.btnGetQA.Location = new System.Drawing.Point(230, 15);
            this.btnGetQA.Name = "btnGetQA";
            this.btnGetQA.Size = new System.Drawing.Size(108, 31);
            this.btnGetQA.TabIndex = 1;
            this.btnGetQA.Text = "Get Q&&A";
            this.btnGetQA.UseVisualStyleBackColor = true;
            this.btnGetQA.Click += new System.EventHandler(this.btnGetQA_Click);
            // 
            // lbQnum
            // 
            this.lbQnum.AutoSize = true;
            this.lbQnum.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQnum.Location = new System.Drawing.Point(12, 22);
            this.lbQnum.Name = "lbQnum";
            this.lbQnum.Size = new System.Drawing.Size(143, 19);
            this.lbQnum.TabIndex = 2;
            this.lbQnum.Text = "Question Number:";
            // 
            // lbQ
            // 
            this.lbQ.AutoSize = true;
            this.lbQ.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbQ.Location = new System.Drawing.Point(12, 65);
            this.lbQ.Name = "lbQ";
            this.lbQ.Size = new System.Drawing.Size(75, 19);
            this.lbQ.TabIndex = 3;
            this.lbQ.Text = "Question";
            // 
            // lbAns1
            // 
            this.lbAns1.AutoSize = true;
            this.lbAns1.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAns1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbAns1.Location = new System.Drawing.Point(12, 163);
            this.lbAns1.Name = "lbAns1";
            this.lbAns1.Size = new System.Drawing.Size(76, 19);
            this.lbAns1.TabIndex = 4;
            this.lbAns1.Text = "Answer 1";
            // 
            // lbAns4
            // 
            this.lbAns4.AutoSize = true;
            this.lbAns4.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAns4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbAns4.Location = new System.Drawing.Point(12, 397);
            this.lbAns4.Name = "lbAns4";
            this.lbAns4.Size = new System.Drawing.Size(76, 19);
            this.lbAns4.TabIndex = 5;
            this.lbAns4.Text = "Answer 4";
            // 
            // lbAns3
            // 
            this.lbAns3.AutoSize = true;
            this.lbAns3.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAns3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbAns3.Location = new System.Drawing.Point(12, 319);
            this.lbAns3.Name = "lbAns3";
            this.lbAns3.Size = new System.Drawing.Size(72, 19);
            this.lbAns3.TabIndex = 6;
            this.lbAns3.Text = "Answer3";
            // 
            // lbAns2
            // 
            this.lbAns2.AutoSize = true;
            this.lbAns2.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAns2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbAns2.Location = new System.Drawing.Point(12, 241);
            this.lbAns2.Name = "lbAns2";
            this.lbAns2.Size = new System.Drawing.Size(76, 19);
            this.lbAns2.TabIndex = 7;
            this.lbAns2.Text = "Answer 2";
            // 
            // tbQuestion
            // 
            this.tbQuestion.Location = new System.Drawing.Point(20, 87);
            this.tbQuestion.Multiline = true;
            this.tbQuestion.Name = "tbQuestion";
            this.tbQuestion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbQuestion.Size = new System.Drawing.Size(469, 73);
            this.tbQuestion.TabIndex = 8;
            // 
            // tbAns1
            // 
            this.tbAns1.Location = new System.Drawing.Point(20, 185);
            this.tbAns1.Multiline = true;
            this.tbAns1.Name = "tbAns1";
            this.tbAns1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbAns1.Size = new System.Drawing.Size(469, 53);
            this.tbAns1.TabIndex = 9;
            // 
            // tbAns2
            // 
            this.tbAns2.Location = new System.Drawing.Point(16, 263);
            this.tbAns2.Multiline = true;
            this.tbAns2.Name = "tbAns2";
            this.tbAns2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbAns2.Size = new System.Drawing.Size(473, 53);
            this.tbAns2.TabIndex = 10;
            // 
            // tbAns3
            // 
            this.tbAns3.Location = new System.Drawing.Point(16, 341);
            this.tbAns3.Multiline = true;
            this.tbAns3.Name = "tbAns3";
            this.tbAns3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbAns3.Size = new System.Drawing.Size(473, 53);
            this.tbAns3.TabIndex = 11;
            // 
            // tbAns4
            // 
            this.tbAns4.Location = new System.Drawing.Point(16, 419);
            this.tbAns4.Multiline = true;
            this.tbAns4.Name = "tbAns4";
            this.tbAns4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbAns4.Size = new System.Drawing.Size(473, 53);
            this.tbAns4.TabIndex = 12;
            // 
            // btnSubQA
            // 
            this.btnSubQA.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubQA.ForeColor = System.Drawing.Color.Blue;
            this.btnSubQA.Location = new System.Drawing.Point(347, 486);
            this.btnSubQA.Name = "btnSubQA";
            this.btnSubQA.Size = new System.Drawing.Size(142, 31);
            this.btnSubQA.TabIndex = 13;
            this.btnSubQA.Text = "Submit Q&&A";
            this.btnSubQA.UseVisualStyleBackColor = true;
            this.btnSubQA.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnSubQA_MouseClick);
            // 
            // lbCA
            // 
            this.lbCA.AutoSize = true;
            this.lbCA.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbCA.Location = new System.Drawing.Point(16, 491);
            this.lbCA.Name = "lbCA";
            this.lbCA.Size = new System.Drawing.Size(126, 19);
            this.lbCA.TabIndex = 14;
            this.lbCA.Text = "Correct Answer:";
            // 
            // tbCorrectAnswer
            // 
            this.tbCorrectAnswer.Location = new System.Drawing.Point(149, 491);
            this.tbCorrectAnswer.Name = "tbCorrectAnswer";
            this.tbCorrectAnswer.Size = new System.Drawing.Size(35, 20);
            this.tbCorrectAnswer.TabIndex = 15;
            // 
            // frmEditQA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(548, 534);
            this.Controls.Add(this.tbCorrectAnswer);
            this.Controls.Add(this.lbCA);
            this.Controls.Add(this.btnSubQA);
            this.Controls.Add(this.tbAns4);
            this.Controls.Add(this.tbAns3);
            this.Controls.Add(this.tbAns2);
            this.Controls.Add(this.tbAns1);
            this.Controls.Add(this.tbQuestion);
            this.Controls.Add(this.lbAns2);
            this.Controls.Add(this.lbAns3);
            this.Controls.Add(this.lbAns4);
            this.Controls.Add(this.lbAns1);
            this.Controls.Add(this.lbQ);
            this.Controls.Add(this.lbQnum);
            this.Controls.Add(this.btnGetQA);
            this.Controls.Add(this.tbQnum);
            this.Name = "frmEditQA";
            this.Text = "frmEditQA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbQnum;
        private System.Windows.Forms.Button btnGetQA;
        private System.Windows.Forms.Label lbQnum;
        private System.Windows.Forms.Label lbQ;
        private System.Windows.Forms.Label lbAns1;
        private System.Windows.Forms.Label lbAns4;
        private System.Windows.Forms.Label lbAns3;
        private System.Windows.Forms.Label lbAns2;
        private System.Windows.Forms.TextBox tbQuestion;
        private System.Windows.Forms.TextBox tbAns1;
        private System.Windows.Forms.TextBox tbAns2;
        private System.Windows.Forms.TextBox tbAns3;
        private System.Windows.Forms.TextBox tbAns4;
        private System.Windows.Forms.Button btnSubQA;
        private System.Windows.Forms.Label lbCA;
        private System.Windows.Forms.TextBox tbCorrectAnswer;
    }
}