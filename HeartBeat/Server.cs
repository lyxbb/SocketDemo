using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HeartBeat
{
    /// <summary>  
    /// 服务端  
    /// </summary>  
    public class Server
    {
        /// <summary>
        /// Occurs when [on client offline].
        /// </summary>
        public event ClientOfflineHandler OnClientOffline;
        public event ClientOnlineHandler OnClientOnline;

        private Dictionary<Int32, ClientInfo> _DicClient;

        /// <summary>  
        /// 构造函数  
        /// </summary>  
        public Server()
        {
            _DicClient = new Dictionary<Int32, ClientInfo>(100);
        }

        /// <summary>  
        /// 开启服务端  
        /// </summary>  
        public void Start()
        {
            // 开启扫描离线线程  
            Thread t = new Thread(new ThreadStart(ScanOffline));
            t.IsBackground = true;
            t.Start();
        }

        /// <summary>  
        /// 扫描离线  
        /// </summary>  
        private void ScanOffline()
        {
            while (true)
            {
                // 一秒扫描一次  
                System.Threading.Thread.Sleep(1000);

                lock (_DicClient)
                {
                    foreach (Int32 clientID in _DicClient.Keys)
                    {
                        ClientInfo clientInfo = _DicClient[clientID];

                        // 如果已经离线则不用管  
                        if (!clientInfo.State)
                        {
                            continue;
                        }

                        // 判断最后心跳时间是否大于3秒  
                        TimeSpan sp = System.DateTime.Now - clientInfo.LastHeartbeatTime;
                        if (sp.Seconds >= 3)
                        {
                            // 离线，触发离线事件  
                            if (OnClientOffline != null)
                            {
                                OnClientOffline(clientInfo);
                            }

                            // 修改状态  
                            clientInfo.State = false;
                        }
                    }
                }
            }
        }

        /// <summary>  
        /// 接收心跳包  
        /// </summary>  
        /// <param name="clientID">客户端ID</param>  
        public void ReceiveHeartbeat(Int32 clientID)
        {
            lock (_DicClient)
            {
                ClientInfo clientInfo;
                if (_DicClient.TryGetValue(clientID, out clientInfo))
                {
                    // 如果客户端已经上线，则更新最后心跳时间  
                    clientInfo.LastHeartbeatTime = System.DateTime.Now;
                }
                else
                {
                    // 客户端不存在，则认为是新上线的  
                    clientInfo = new ClientInfo();
                    clientInfo.ClientID = clientID;
                    clientInfo.LastHeartbeatTime = System.DateTime.Now;
                    clientInfo.State = true;

                    _DicClient.Add(clientID, clientInfo);

                    // 触发上线事件  
                    if (OnClientOnline != null)
                    {
                        OnClientOnline(clientInfo);
                    }
                }
            }
        }
    }


}
