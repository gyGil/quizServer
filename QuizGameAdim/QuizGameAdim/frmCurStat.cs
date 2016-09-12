using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace QuizGameAdim
{
    public partial class frmCurStat : Form
    {
        const int MAX_DISCONNECTION_MSGBOX_ALLOWED = 2; // allowed the errors not to get msg from server
        private MsgQueControl mqc;
        DataTable basetable;
        int cntMsgBox;

        public frmCurStat(MsgQueControl mqc)
        {
            InitializeComponent();
            this.mqc = mqc;
            basetable = null;
            this.cntMsgBox = 0;
            this.KeepCurStatus();
        }


        private void KeepCurStatus()
        {
            CommandData RevMsg;
            CommandData SendMsg = new CommandData();
            SendMsg.systemMessage = CommandData.SCORETABLE;

            try
            {
                this.mqc.Send(SendMsg); // Request Average and Percentage board
                RevMsg = null;
                RevMsg = this.mqc.Receive(CommandData.SCORETABLE);
                if (RevMsg != null)
                {
                    if (RevMsg.table != null)
                    {
                                                  
                        if (basetable == null)
                        {
                            basetable = RevMsg.table;   // assign table from server
                            this.dgvCurStat.DataSource = basetable;   // print table
                        }
                        else
                        {
                            basetable.Clear();  // delete all values in basetable
                            foreach (DataRow r in RevMsg.table.Rows)
                            {
                                basetable.ImportRow(r); // add new rows
                            }
                        }

                        this.dgvCurStat.Update();   // update with new values from server                           
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
                ++this.cntMsgBox;
             //   MessageBox.Show(cntMsgBox.ToString() + " time(s) " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }
        }

        private void trAskCurStat_Tick(object sender, EventArgs e)
        {
            if(this.cntMsgBox < frmCurStat.MAX_DISCONNECTION_MSGBOX_ALLOWED)
            {
                this.KeepCurStatus();
            }
            else if(this.cntMsgBox == frmCurStat.MAX_DISCONNECTION_MSGBOX_ALLOWED)
            {
                MessageBox.Show("Stop to ask crruent status by no reponse from server.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.trAskCurStat.Enabled = false;
                ++this.cntMsgBox;
            }        
        }
    }
}
