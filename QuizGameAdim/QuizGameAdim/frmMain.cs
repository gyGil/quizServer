using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;

namespace QuizGameAdim
{
    public partial class FrmMain : Form
    {
        private MsgQueControl mqc;  ///< message queue controller

        public FrmMain()
        {        
            InitializeComponent();
            this.mqc = new MsgQueControl(); // initially disconnected    
        }

        void FrmMain_Load(object sender, EventArgs e)
        {
            // all button make disabled
            this.btnEditQA.Enabled = false;
            this.btnCur.Enabled = false;
            this.btnLeaderBoard.Enabled = false;
            this.btnExcel.Enabled = false;          
        }

        void btnConnect_MouseClick(object sender, MouseEventArgs e)
        {

            if (this.mqc.IsConnected) // try to Disconnect 
            {
                try
                {
                    this.mqc.Disconnect();
                    this.btnConnect.Text = "Connect";
                    this.btnConnect.ForeColor = Color.Blue;
                    this.btnEditQA.Enabled = false;
                    this.btnCur.Enabled = false;
                    this.btnLeaderBoard.Enabled = false;
                    this.btnExcel.Enabled = false;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }
            else   // try to Connect
            {
                if(!String.IsNullOrWhiteSpace(this.tbServerName.Text))
                {
                    try
                    {
                        if (this.mqc.Connect(this.tbServerName.Text, "Admin"))
                        {
                            this.btnConnect.Text = "Connected \n (push to disconnect..)";
                            this.btnConnect.ForeColor = Color.Green;
                            this.btnEditQA.Enabled = true;
                            this.btnCur.Enabled = true;
                            this.btnLeaderBoard.Enabled = true;
                            this.btnExcel.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Connection Failed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }                               
                }
                else
                {
                    MessageBox.Show("Server name is empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }// end of if (this.mqc.IsConnected)
        }// end of void btnConnect_MouseClick(object sender, MouseEventArgs e)

        void btnEditQA_MouseClick(object sender, MouseEventArgs e)
        {
            frmEditQA popupForm = new frmEditQA(mqc);
            popupForm.ShowDialog(); // pop up the child form for edit Q&A
        }     

        void btnCur_MouseClick(object sender, MouseEventArgs e)
        {
            frmCurStat popupForm = new frmCurStat(mqc);
            popupForm.ShowDialog();
        }

        void btnLeaderBoard_MouseClick(object sender, MouseEventArgs e)
        {
            frmLBoard popupForm = new frmLBoard(this.mqc);
            popupForm.ShowDialog();
        }

        void btnExcel_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                CommandData SendMsg = new CommandData();
                SendMsg.systemMessage = CommandData.APBOARD;
                this.mqc.DeleteAllMsgInMQueue();    // clean message queue
                this.mqc.Send(SendMsg); // Request Average and Percentage board

                CommandData RevMsg = this.mqc.Receive(CommandData.APBOARD);
                if (RevMsg != null)
                {
                    if (RevMsg.table != null)
                    {
                        System.Data.DataTable table = RevMsg.table;
                        Excel.Application xlApp = new Excel.Application();  // start Excel 
                        xlApp.Visible = true;
                        Excel.Workbook wb = xlApp.Workbooks.Add(Type.Missing);  // add workbook 
                        Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1]; // add worksheet 1
                        ws.Name = "Questions' Information";
                        Excel.Worksheet wsChart = wb.Sheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);   // add worksheet 2 for histogram
                        wsChart.Name = "Histogram";

                        // write column name to worksheet 1
                        for (int i = 0; i < table.Columns.Count; ++i)
                        {
                            ws.Cells[1, (i + 1)] = table.Columns[i].ColumnName;
                        }

                        // write all values to worksheet 1
                        for (int i = 0; i < table.Rows.Count; ++i)
                        {
                            for (int j = 0; j < table.Columns.Count; ++j)
                            {
                                ws.Cells[(i + 2), (j + 1)] = table.Rows[i][j];

                            }
                        }

                        Excel.ChartObjects chartObjs = (Excel.ChartObjects)wsChart.ChartObjects(Type.Missing);
                        Excel.ChartObject chartObj = (Excel.ChartObject)chartObjs.Add(10, 10, 520, 250);    // make area to insert chart
                        Excel.Chart xlChart = chartObj.Chart;
                        xlChart.HasTitle = true;
                        xlChart.HasLegend = false;
                        xlChart.ChartTitle.Text = "Average length of Time";
                        Excel.Range rangeChart = wsChart.get_Range("B2", "K17");    // set range

                        // Gets an object that represents either a single axis or a collection of the axes on the chart.
                        Excel.Axis xAxis = xlChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary) as Excel.Axis;
                        Excel.Axis yAxis = xlChart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary) as Excel.Axis;
                        xAxis.HasTitle = true;
                        xAxis.AxisTitle.Text = "Question number";
                        yAxis.HasTitle = true;
                        yAxis.AxisTitle.Text = "Average time";

                        // make chart bars respond to average length time
                        for (int i = 0; i < table.Rows.Count; ++i)
                        {
                            double d = 0.00;
                            if(!double.TryParse(table.Rows[i][2].ToString(),out d)) rangeChart[i + 1, 1] = 0.0;
                            else
                                rangeChart[i + 1, 1] = d;
                        }

                        xlChart.SetSourceData(rangeChart, Type.Missing);
                    }// end of if(RevMsg.table != null)
                    else
                    {
                        MessageBox.Show("Missing Table to be requested.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }// end of if(revMsg == null)
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


/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.mqc.Exit();    // message queue destroy
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }// end of class def
}
