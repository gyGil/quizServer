using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace QuizGameAdim
{
    /// \class MsgQueControl
    ///
    /// \brief 
    /// - This class contols Message Queue with connection, disconnection, send, receive.
    public class MsgQueControl
    {
        const string PREFIX_TARGET_MACHINE_PATH = @"FormatName:Direct=OS:"; ///< FIRST STRING FOR TARTGET MACHINE
        const string SHARED_MQ_PATH = @"\private$\";    ///< private queue path
        const string MY_QUEUE_NAME = "Admin";           ///< my queue name (predetermined)
        const string SERVER_CONN_QUEUE_NAME = "ServiceQ";    ///< server queue name (predetermined)

        public bool IsConnected { get; set; }   ///<  inidcate connected or not
        private MessageQueue myMessageQ;   ///< My MessageQueue object
        private MessageQueue serverMessageQ;    ///< Server MessageQueue object
        TimeSpan timeSpanRev;

        /// \brief  MsgQueControl()
        ///
        /// \details <b>Details</b>
        /// - Create My message queue or reused my message queue to receive data from remote server
        ///
        /// \param <b>nothing</b>
        ///
        /// \return <b>Nothing</b>
        public MsgQueControl()
        {
            this.IsConnected = false;
            this.timeSpanRev = new TimeSpan(0, 0, 4);   // time span is 2 seconds when receive 

            string tmpMyMessageQpath = System.Environment.MachineName + MsgQueControl.SHARED_MQ_PATH + MsgQueControl.MY_QUEUE_NAME;
            if (!MessageQueue.Exists(tmpMyMessageQpath))
            {
                // Creates a non-transactional Message Queuing queue at the specified path.
                this.myMessageQ = MessageQueue.Create(tmpMyMessageQpath);
            }
            else
            {
                // Initializes a new instance that references the Message Queuing queue at the specified path.
                this.myMessageQ = new MessageQueue(tmpMyMessageQpath);
                this.myMessageQ.Purge();    // delete all messages
            }

            //XmlMessageFormatter: Serializes and deserializes objects to or from the body of a message, 
            //using the XML format based on the XSD schema definition.
            this.myMessageQ.Formatter = new XmlMessageFormatter(new Type[] { typeof(CommandData) });
        }

        /// \brief  Connect
        ///
        /// \details <b>Details</b>
        /// - Prints main menu by the level
        ///
        /// \param serverMachineName - <b>string</b> - server's machine name
        /// \param userType - <b>string</b> - user type (User or Admin)
        ///
        /// \return <b>bool</b> - success or not for connection
        public bool Connect(string serverMachineName, string userType)  // userType: "User" or "Admin"
        {
            MessageQueue tmpMQ = new MessageQueue(MsgQueControl.PREFIX_TARGET_MACHINE_PATH + serverMachineName + MsgQueControl.SHARED_MQ_PATH + MsgQueControl.SERVER_CONN_QUEUE_NAME);

            // create data to connect to server
            CommandData connMsg = new CommandData();
            connMsg.systemMessage = CommandData.CONNECT;
            connMsg.userType = userType;
            connMsg.qName = this.myMessageQ.Path;
           
            tmpMQ.Send(connMsg); // send connect request to server
            CommandData serverMsg = null;
            serverMsg = this.Receive(CommandData.ACCEPTED);   // wait to get acceptace from server

            if(serverMsg != null)   // success for connection
            {
                this.serverMessageQ = new MessageQueue(MsgQueControl.PREFIX_TARGET_MACHINE_PATH + serverMsg.qName);
                this.IsConnected = true;
                return true;
            }

            return false;
        }

        /// \brief  Send
        ///
        /// \details <b>Details</b>
        /// - send data to server
        ///
        /// \param data - <b>CommandData</b> - server's machine name
        ///
        /// \return <b>void</b>
        public void Send(CommandData data)
        {        
            this.serverMessageQ.Send(data);
        }

        /// \brief  DeleteAllMsgInMQueue
        ///
        /// \details <b>Details</b>
        /// - Delete all messages in message queue
        ///
        /// \param <b>void</b>
        ///
        /// \return <b>void</b>
        public void DeleteAllMsgInMQueue()
        {
            if(myMessageQ != null)  this.myMessageQ.Purge();
        }

        /// \brief  Receive
        ///
        /// \details <b>Details</b>
        /// - Receive for specified time (timeSpanRev) 
        ///
        /// \param SystemMsgType - <b>char</b> - system message type
        ///
        /// \return <b>void</b>
        public CommandData Receive(char SystemMsgType)
        {
            CommandData retVal = null;
            
            retVal = (CommandData)this.myMessageQ.Receive(this.timeSpanRev).Body;
            if(retVal != null)
            {
                if((SystemMsgType == retVal.systemMessage) || (SystemMsgType == 'Z'))   // Z = all
                {
                    return retVal;
                }
            }

            return retVal;
        }

        /// \brief  Disconnect
        ///
        /// \details <b>Details</b>
        /// - disconnect with server
        ///
        /// \param <b>void</b>
        ///
        /// \return <b>void</b>
        public void Disconnect()
        {
            if(this.IsConnected == true)
            {
                CommandData disconnMsg = new CommandData();
                disconnMsg.systemMessage = CommandData.DISCONNECT;
                this.Send(disconnMsg);
                this.IsConnected = false;
                this.serverMessageQ = null;   
            }                 
        }

        /// \brief  Exit
        ///
        /// \details <b>Details</b>
        /// - disconnect with server and delete my queue
        ///
        /// \param <b>void</b>
        ///
        /// \return <b>void</b>
        public void Exit()
        {
            if (this.IsConnected == true)
            {
                this.Disconnect();
            }
      
            if(this.myMessageQ != null)
            {
                MessageQueue.Delete(this.myMessageQ.Path);  // delete my MessageQueue in my machine
            }        
            this.myMessageQ = null;
        }   
    }
}
