namespace QuizGameAdim
{
    partial class frmCurStat
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
            this.dgvCurStat = new System.Windows.Forms.DataGridView();
            this.trAskCurStat = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurStat)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCurStat
            // 
            this.dgvCurStat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCurStat.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCurStat.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvCurStat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurStat.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCurStat.Location = new System.Drawing.Point(12, 12);
            this.dgvCurStat.Name = "dgvCurStat";
            this.dgvCurStat.ReadOnly = true;
            this.dgvCurStat.Size = new System.Drawing.Size(404, 431);
            this.dgvCurStat.TabIndex = 0;
            // 
            // trAskCurStat
            // 
            this.trAskCurStat.Enabled = true;
            this.trAskCurStat.Interval = 3000;
            this.trAskCurStat.Tick += new System.EventHandler(this.trAskCurStat_Tick);
            // 
            // frmCurStat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(425, 450);
            this.Controls.Add(this.dgvCurStat);
            this.Name = "frmCurStat";
            this.Text = "Current Status";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurStat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCurStat;
        private System.Windows.Forms.Timer trAskCurStat;
    }
}