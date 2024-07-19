using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Security.RightsManagement;

namespace NUPROJECT_vcs
{
    public class Client
    {
        public Client() 
        {

        }

        public void SendMessege()
        {
            string serverIp = "100.100.100.5";
            int port = 1103;
            string message = "USERID:testid\nUSERPW:e9c0f8b575cbfcb42ab3b78ecc87efa3b011d9a5d10b09fa4e96f240bf6a82f5";

            try
            {
                // TcpClient 객체 생성 및 서버에 연결
                using (TcpClient client = new TcpClient(serverIp, port))
                {
                    // NetworkStream 가져오기
                    NetworkStream stream = client.GetStream();

                    // 메시지를 바이트 배열로 변환
                    byte[] data = Encoding.ASCII.GetBytes(message);

                    // 데이터 전송
                    stream.Write(data, 0, data.Length);
                    Console.WriteLine("Sent: {0}", message);

                    // 응답을 받을 때까지 대기 (옵션)
                    // byte[] responseData = new byte[256];
                    // int bytes = stream.Read(responseData, 0, responseData.Length);
                    // string response = Encoding.ASCII.GetString(responseData, 0, bytes);
                    // Console.WriteLine("Received: {0}", response);

                    // 스트림과 TcpClient 객체 닫기
                    stream.Close();
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }

            Console.WriteLine("\n Press Enter to continue...");
            Console.Read();
        }


    }
}
