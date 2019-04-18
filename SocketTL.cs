﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace u2ec_example
{
    class SocketTL
    {        
        static Socket ReceiveSocket;
        public void connectwait(){
            int port = 8885;
            IPAddress ip = IPAddress.Any;  // 侦听所有网络客户接口的客活动
            ReceiveSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//使用指定的地址簇协议、套接字类型和通信协议   <br>            ReceiveSocket.SetSocketOption(SocketOptionLevel.Socket,SocketOptionName.ReuseAddress,true);  //有关套接字设置
            IPEndPoint endPoint = new IPEndPoint(ip,port);
            ReceiveSocket.Bind(new IPEndPoint(ip, port)); //绑定IP地址和端口号
            ReceiveSocket.Listen(10);  //设定最多有10个排队连接请求
            Console.WriteLine("建立连接");
            Socket socket = ReceiveSocket.Accept();
          
            byte[] receive = new byte[1024];
            socket.Receive(receive);
            Console.WriteLine("接收到消息：" + Encoding.ASCII.GetString(receive));
            byte[] send = Encoding.ASCII.GetBytes("Success receive the message,send the back the message");
            socket.Send(send);
            Console.WriteLine("发送消息为："+Encoding.ASCII.GetString(send));
        }

        static Socket ClientSocket;
        public void sent()
        {
            String IP = "127.0.0.1";
            int port = 8885;

            IPAddress ip = IPAddress.Parse(IP);  //将IP地址字符串转换成IPAddress实例
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//使用指定的地址簇协议、套接字类型和通信协议
            IPEndPoint endPoint = new IPEndPoint(ip, port); // 用指定的ip和端口号初始化IPEndPoint实例
            ClientSocket.Connect(endPoint);  //与远程主机建立连接


            Console.WriteLine("开始发送消息");
            byte[] message = Encoding.ASCII.GetBytes("Connect the Server");  //通信时实际发送的是字节数组，所以要将发送消息转换字节
            ClientSocket.Send(message);
            Console.WriteLine("发送消息为:" + Encoding.ASCII.GetString(message));
            byte[] receive = new byte[1024];
            int length = ClientSocket.Receive(receive);  // length 接收字节数组长度
            Console.WriteLine("接收消息为：" + Encoding.ASCII.GetString(receive));
            ClientSocket.Close();  //关闭连接
        }
    }
}
