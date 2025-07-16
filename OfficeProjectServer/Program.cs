using System.Threading.Tasks;

namespace OfficeProjectServer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            TcpServer server = new TcpServer();
            await server.StartAsync(1103);
        }
    }
}
