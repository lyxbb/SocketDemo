using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HeartBeat
{
    // 客户端离线委托  
    public delegate void ClientOfflineHandler(ClientInfo client);

    // 客户端上线委托  
    public delegate void ClientOnlineHandler(ClientInfo client);
    class Program
    {
        /// <summary>  
        /// 客户端离线提示  
        /// </summary>  
        /// <param name="clientInfo"></param>  
        private static void ClientOffline(ClientInfo clientInfo)
        {
            Console.WriteLine(String.Format("客户端{0}离线，离线时间：\t{1}", clientInfo.ClientID, clientInfo.LastHeartbeatTime));
        }

        /// <summary>  
        /// 客户端上线提示  
        /// </summary>  
        /// <param name="clientInfo"></param>  
        private static void ClientOnline(ClientInfo clientInfo)
        {
            Console.WriteLine(String.Format("客户端{0}上线，上线时间：\t{1}", clientInfo.ClientID, clientInfo.LastHeartbeatTime));
        }

        static void Main(string[] args)
        {
            // 服务端  
            Server server = new Server();

            // 服务端离线事件  
            server.OnClientOffline += ClientOffline;

            // 服务器上线事件  
            server.OnClientOnline += ClientOnline;

            // 开启服务器  
            server.Start();

            // 模拟100个客户端  
            Dictionary<Int32, Client> dicClient = new Dictionary<Int32, Client>();
            for (Int32 i = 0; i < 100; i++)
            {
                // 这里传入server只是为了方便而已  
                Client client = new Client(i + 1, server);
                dicClient.Add(i + 1, client);

                // 开启客户端  
                client.Start();
            }

            System.Threading.Thread.Sleep(1000);

            while (true)
            {
                Console.WriteLine("请输入要离线的ClientID,输入0则退出程序:");
                String clientID = Console.ReadLine();
                if (!String.IsNullOrEmpty(clientID))
                {
                    Int32 iClientID = 0;
                    Int32.TryParse(clientID, out iClientID);
                    if (iClientID > 0)
                    {
                        Client client;
                        if (dicClient.TryGetValue(iClientID, out client))
                        {
                            // 客户端离线  
                            client.Offline = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
    }
}
