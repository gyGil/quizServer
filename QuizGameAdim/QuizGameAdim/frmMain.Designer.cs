namespace QuizGameAdim
{
    partial class FrmMain
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnEditQA = new System.Windows.Forms.Button();
            this.btnCur = new System.Windows.Forms.Button();
            this.btnLeaderBoard = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbServerName = new System.Windows.Forms.Label();
            this.tbServerName = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.ForeColor = System.Drawing.Color.Blue;
            this.btnConnect.Location = new System.Drawing.Point(35, 68);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(200, 71);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnConnect_MouseClick);
            // 
            // btnEditQA
            // 
            this.btnEditQA.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditQA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnEditQA.Location = new System.Drawing.Point(10, 21);
            this.btnEditQA.Name = "btnEditQA";
            this.btnEditQA.Size = new System.Drawing.Size(200, 40);
            this.btnEditQA.TabIndex = 1;
            this.btnEditQA.Text = "Edit Q && A";
            this.btnEditQA.UseVisualStyleBackColor = true;
            this.btnEditQA.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnEditQA_MouseClick);
            // 
            // btnCur
            // 
            this.btnCur.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCur.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCur.Location = new System.Drawing.Point(10, 92);
            this.btnCur.Name = "btnCur";
            this.btnCur.Size = new System.Drawing.Size(200, 40);
            this.btnCur.TabIndex = 2;
            this.btnCur.Text = "Current Status";
            this.btnCur.UseVisualStyleBackColor = true;
            this.btnCur.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnCur_MouseClick);
            // 
            // btnLeaderBoard
            // 
            this.btnLeaderBoard.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeaderBoard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLeaderBoard.Location = new System.Drawing.Point(10, 165);
            this.btnLeaderBoard.Name = "btnLeaderBoard";
            this.btnLeaderBoard.Size = new System.Drawing.Size(200, 40);
            this.btnLeaderBoard.TabIndex = 3;
            this.btnLeaderBoard.Text = "Leader Board";
            this.btnLeaderBoard.UseVisualStyleBackColor = true;
            this.btnLeaderBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnLeaderBoard_MouseClick);
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnExcel.Location = new System.Drawing.Point(10, 236);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(200, 40);
            this.btnExcel.TabIndex = 5;
            this.btnExcel.Text = "Produce Excel Document";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnExcel_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExcel);
            this.groupBox1.Controls.Add(this.btnLeaderBoard);
            this.groupBox1.Controls.Add(this.btnCur);
            this.groupBox1.Controls.Add(this.btnEditQA);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(25, 167);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 287);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // lbServerName
            // 
            this.lbServerName.AutoSize = true;
            this.lbServerName.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbServerName.Location = new System.Drawing.Point(12, 24);
            this.lbServerName.Name = "lbServerName";
            this.lbServerName.Size = new System.Drawing.Size(115, 19);
            this.lbServerName.TabIndex = 7;
            this.lbServerName.Text = "Server Name: ";
            // 
            // tbServerName
            // 
            this.tbServerName.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbServerName.Location = new System.Drawing.Point(133, 21);
            this.tbServerName.Name = "tbServerName";
            this.tbServerName.Size = new System.Drawing.Size(102, 27);
            this.tbServerName.TabIndex = 8;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(268, 466);
            this.Controls.Add(this.tbServerName);
            this.Controls.Add(this.lbServerName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmMain";
            this.Text = "Quiz Game Admin App ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnEditQA;
        private System.Windows.Forms.Button btnCur;
        private System.Windows.Forms.Button btnLeaderBoard;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbServerName;
        private System.Windows.Forms.TextBox tbServerName;
    }
}

