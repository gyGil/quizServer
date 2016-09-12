namespace QuizGameAdim
{
    partial class frmLBoard
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
            this.dgvLBoard = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLBoard
            // 
            this.dgvLBoard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLBoard.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLBoard.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvLBoard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLBoard.Location = new System.Drawing.Point(13, 13);
            this.dgvLBoard.Name = "dgvLBoard";
            this.dgvLBoard.ReadOnly = true;
            this.dgvLBoard.Size = new System.Drawing.Size(331, 358);
            this.dgvLBoard.TabIndex = 0;
            // 
            // frmLBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(356, 383);
            this.Controls.Add(this.dgvLBoard);
            this.Name = "frmLBoard";
            this.Text = "Leader Board";
            this.Load += new System.EventHandler(this.frmLBoard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLBoard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLBoard;
    }
}