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
    public partial class frmEditQA : Form
    {
        private MsgQueControl mqc;
 
        public frmEditQA(MsgQueControl mqc)
        {
            InitializeComponent();
            this.mqc = mqc;
        }

        private int ValidateInteger(string num)
        {
            if(!String.IsNullOrWhiteSpace(num))
            {
                int retVal = -1;
                if(int.TryParse(num, out retVal))
                {
                    return retVal;
                }
            }
            return -1;
        }

        private void btnSubQA_MouseClick(object sender, MouseEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.tbQuestion.Text) ||
               String.IsNullOrWhiteSpace(this.tbAns1.Text) ||
                String.IsNullOrWhiteSpace(this.tbAns2.Text) ||
                String.IsNullOrWhiteSpace(this.tbAns3.Text) ||
                String.IsNullOrWhiteSpace(this.tbAns4.Text) ||
                (ValidateInteger(this.tbQnum.Text) < 1) ||
                (ValidateInteger(this.tbCorrectAnswer.Text) < 1))
            {
                MessageBox.Show("All entities should be filled!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    // send message to server to updata Q&A
                    CommandData sendMsg = new CommandData();
                    sendMsg.systemMessage = CommandData.UPDATEQTABLE;
                    sendMsg.answerId = sendMsg.questionId = Convert.ToInt32(this.tbQnum.Text);
                    sendMsg.question = this.tbQuestion.Text;
                    sendMsg.answer1 = this.tbAns1.Text;
                    sendMsg.answer2 = this.tbAns2.Text;
                    sendMsg.answer3 = this.tbAns3.Text;
                    sendMsg.answer4 = this.tbAns4.Text;
                    sendMsg.correctAnswer = Convert.ToInt32(this.tbCorrectAnswer.Text);
                    this.mqc.DeleteAllMsgInMQueue();    // clean message queue
                    this.mqc.Send(sendMsg); // Request Average and Percentage board

                    CommandData RevMsg = this.mqc.Receive(CommandData.UPDATEQTABLE);
                    if (RevMsg != null)
                    {
                        MessageBox.Show(RevMsg.numberOfRows.ToString() + " Rows were affected", "Important Note",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void btnGetQA_Click(object sender, EventArgs e)
        {
            if (this.ValidateInteger(this.tbQnum.Text) > 0)
            {
                try
                {
                    CommandData SendMsg = new CommandData();
                    SendMsg.systemMessage = CommandData.QABOARD;
                    SendMsg.questionId = Convert.ToInt32(this.tbQnum.Text);
                    this.mqc.DeleteAllMsgInMQueue();    // clean message queue
                    this.mqc.Send(SendMsg); // Request Question and Answer board

                    CommandData RevMsg = this.mqc.Receive(CommandData.QABOARD);
                    if (RevMsg != null)
                    {
                        this.tbQnum.Text = RevMsg.questionId.ToString();
                        this.tbQuestion.Text = RevMsg.question;
                        this.tbAns1.Text = RevMsg.answer1;
                        this.tbAns2.Text = RevMsg.answer2;
                        this.tbAns3.Text = RevMsg.answer3;
                        this.tbAns4.Text = RevMsg.answer4;
                        this.tbCorrectAnswer.Text = RevMsg.correctAnswer.ToString();
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
            else
            {
                MessageBox.Show("the number only (greater than 0)!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}
