using System;
using System.Collections.Generic;
using System.Messaging;
using System.Text;

namespace MessageDemo
{
    class Program
    {
        const string queuePath = @"FormatName:DIRECT=TCP:192.168.15.104\Private$\test";
        static void Main(string[] args)
        {
            CreateQue();
            Sendmsg("发送消息！");
            Receivemsg();
        }

        /// <summary>
        /// Creates the 消息队列.
        /// </summary>
        private static void CreateQue()
        {
           // string path = ".\\private$\\" + "test";//设置消息队列路径
            if (!MessageQueue.Exists(path))//判断该路径是否存在
            {
                MessageQueue.Create(path);//如果不存在则创建
            }
            Console.WriteLine("创建消息队列test");
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg">The MSG.</param>
        private static void Sendmsg(string msg)
        {
            string path = ".\\private$\\" + "test";//设置消息队列路径
            MessageQueue msqs = new MessageQueue(path);//创建指定路径下的消息队列对象
            Message ms = new Message();//创建消息对象
            ms.Formatter = new System.Messaging.XmlMessageFormatter(new Type[] { typeof(string) });//设置消息的Formatter数据类型
          
            ms.Body = msg;
            msqs.Send(ms);
            Console.WriteLine("创建成功");
        }

        /// <summary>
        /// Receivemsgs this instance.
        /// </summary>
        private static void Receivemsg()
        {
            string path = ".\\private$\\" + "test";//设置消息队列路径
            MessageQueue msqs = new MessageQueue(path);//创建指定路径下的消息队列对象
            System.Messaging.Message mes = msqs.Receive();//获取单条数据（如果没有数据，当前进程会被阻塞）
            mes.Formatter = new System.Messaging.XmlMessageFormatter(new Type[] { typeof(string) });//设置消息的Formatter数据类型
            string message = mes.Body.ToString();//获取Message内的内容
            Console.WriteLine(message);
            Console.WriteLine("接收成功");
            Console.ReadKey();
        }
    }
}
