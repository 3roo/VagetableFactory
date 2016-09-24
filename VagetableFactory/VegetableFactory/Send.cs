using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace VegetableFactory
{
    class Send
    {
        private static byte[] result = new byte[1024];
        public  void sendMessage(string sendMessage)
        {
            //设定服务器IP地址  
            IPAddress ip = IPAddress.Parse("192.168.100.2");
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientSocket.Connect(new IPEndPoint(ip, 40000)); //配置服务器IP与端口  
                Console.WriteLine("连接服务器成功");
            }
            catch
            {
                Console.WriteLine("连接服务器失败，请按回车键退出！");
                return;
            }
            //通过 clientSocket 发送数据
            try
            {
                clientSocket.Send((HexStringToBytes(sendMessage)));

                Console.WriteLine("向服务器发送消息：{0}" + sendMessage);
            }
            catch
            {
                Console.WriteLine("发送失败");
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
            Console.WriteLine("发送完毕，按回车键退出");
            Console.ReadLine();
        }

        //转成16进制
        public static byte[] HexStringToBytes(string code)
        {

            uint[] goal = new uint[6];
            string[] strArr1 = code.Trim().Split(' ');
            for (int i = 0; i < strArr1.Length; i++)
                goal[i] = Convert.ToUInt32(strArr1[i], 16);
            Change change = new Change();
            string CRC = change.check(goal, 6).ToString("X");
            code = code + " " + CRC[2] + CRC[3] + " " + CRC[0] + CRC[1];

            string[] strArr = code.Trim().Split(' '); 

            byte[] b = new byte[strArr.Length];
            //逐个字符变为16进制字节数据
            for (int i = 0; i < strArr.Length; i++)
            {
                b[i] = Convert.ToByte(strArr[i], 16);
            }
            //按照指定编码将字节数组变为字符串
            return b;
        }
    }
}
