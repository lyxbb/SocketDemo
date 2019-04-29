using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HeartBeat
{
    /// <summary>  
    /// 客户端  
    /// </summary>  
    public class Client
    {
        public Server Server;
        public Int32 ClientID;
        public Boolean Offline;

        /// <summary>  
        /// 构造函数  
        /// </summary>  
        /// <param name="clientID"></param>  
        /// <param name="server"></param>  
        public Client(Int32 clientID, Server server)
        {
            ClientID = clientID;
            Server = server;
            Offline = false;
        }

        /// <summary>  
        /// 开启客户端  
        /// </summary>  
        public void Start()
        {
            // 开启心跳线程  
            Thread t = new Thread(new ThreadStart(Heartbeat));
            t.IsBackground = true;
            t.Start();
        }

        /// <summary>  
        /// 向服务器发送心跳包  
        /// </summary>  
        private void Heartbeat()
        {
            while (!Offline)
            {
                // 向服务端发送心跳包  
                Server.ReceiveHeartbeat(ClientID);

                System.Threading.Thread.Sleep(1000);
            }
        }
    }

    /// <summary>  
    /// 客户端信息  
    /// </summary>  
    public class ClientInfo
    {
        // 客户端ID  
        public Int32 ClientID;

        // 最后心跳时间  
        public DateTime LastHeartbeatTime;

        // 状态  
        public Boolean State;
    }
}
