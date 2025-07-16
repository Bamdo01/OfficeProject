using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OfficeProjectServer
{
    public class TcpServer
    {
        private TcpListener _listener;

        public async Task StartAsync(int port = 1103)
        {
            _listener = new TcpListener(IPAddress.Any, port);
            _listener.Start();
            Console.WriteLine($"[TCP] 서버 시작됨: 포트 {port}");

            while (true)
            {
                var client = await _listener.AcceptTcpClientAsync();
                _ = HandleClientAsync(client); // 클라이언트 연결 처리
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            using var stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            string received = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            Console.WriteLine($"[TCP] 수신: {received}");

            // 프론트는 RESULT:OK 포함된 응답을 기대함
            string response = "RESULT:OK\nMESSAGE:서버 응답입니다\n";
            byte[] responseBytes = Encoding.UTF8.GetBytes(response);
            await stream.WriteAsync(responseBytes, 0, responseBytes.Length);
        }
    }
}
