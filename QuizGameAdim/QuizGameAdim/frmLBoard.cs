using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizGameAdim
{
    public partial class frmLBoard : Form
    {
        private MsgQueControl mqc;
        public frmLBoard(MsgQueControl mqc)
        {
            InitializeComponent();
            this.mqc = mqc;
        }

        private void frmLBoard_Load(object sender, EventArgs e)
        {
            try
            {
                CommandData SendMsg = new CommandData();
                SendMsg.systemMessage = CommandData.LEADERBOARD;
                this.mqc.DeleteAllMsgInMQueue();    // clean message queue
                this.mqc.Send(SendMsg); // Request Average and Percentage board

                CommandData RevMsg = this.mqc.Receive(CommandData.LEADERBOARD);
                if (RevMsg != null)
                {
                    if (RevMsg.table != null)
                    {
                        this.dgvLBoard.DataSource = RevMsg.table;
                    }
                    else
                    {
                        MessageBox.Show("Missing Table to be requested.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("No Data for current request.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
