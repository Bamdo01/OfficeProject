using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WPFOfficeProject
{
    public class NUPServerConnector
    {
        // 콜백 함수 간 인자를 넘기기 위한 구조체 역할 클래스
        class StateObject
        {
            public TcpClient Client { get; set; }
            public string Message { get; set; }
            public byte[] RecvBuffer { get; set; }
            public Action<string> OnReceiveOK { get; set; }
            public Action<string> OnReceiveNG { get; set; }
        }

        // SHA256 해싱 함수 - 중복 제거 목적
        private string ComputeSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hashBytes).Replace("-", "");
            }
        }

        /// <summary>
        /// 서버로 사용자 로그인 요청 쿼리를 보내는 함수
        /// </summary>
        public void SendUserLogin(string id, string pw, Action<string> OnReceiveOK, Action<string> OnReceiveNG)
        {
            string hashPW = ComputeSHA256Hash(pw);

            StringBuilder query = new StringBuilder();
            query.Append($"COMMAND:USER_LOGIN{Environment.NewLine}");
            query.Append($"USERID:{id}{Environment.NewLine}");
            query.Append($"USERPW:{hashPW}{Environment.NewLine}");

            this.SendMessage(query.ToString(), OnReceiveOK, OnReceiveNG);
        }

        public void SendUserRegister(string id, string pw, string email, string addr, DateTime birthDay, int gender, string phone, Action<string> OnReceiveOK, Action<string> OnReceiveNG)
        {
            string hashPW = ComputeSHA256Hash(pw);

            StringBuilder query = new StringBuilder();
            query.Append($"COMMAND:USER_REGISTER{Environment.NewLine}");
            query.Append($"USERID:{id}{Environment.NewLine}");
            query.Append($"USERPW:{hashPW}{Environment.NewLine}");
            query.Append($"EMAIL:{email}{Environment.NewLine}");
            query.Append($"ADDRESS:{addr}{Environment.NewLine}");
            query.Append($"BIRTHDAY:{birthDay.ToString("yyyy-MM-dd")}{Environment.NewLine}");
            query.Append($"GENDER:{gender}{Environment.NewLine}");
            query.Append($"PHONE:{phone}{Environment.NewLine}");

            this.SendMessage(query.ToString(), OnReceiveOK, OnReceiveNG);
        }

        public void SendUserAddFriend(string id, string friendid, Action<string> OnReceiveOK, Action<string> OnReceiveNG)
        {
            StringBuilder query = new StringBuilder();
            query.Append($"COMMAND:USER_ADDFRIEND{Environment.NewLine}");
            query.Append($"USERID:{id}{Environment.NewLine}");
            query.Append($"FRIENDID:{friendid}{Environment.NewLine}");

            this.SendMessage(query.ToString(), OnReceiveOK, OnReceiveNG);
        }

        public void SendUserGetPendingFriends(string id, Action<string> OnReceiveOK, Action<string> OnReceiveNG)
        {
            StringBuilder query = new StringBuilder();
            query.Append($"COMMAND:USER_LISTPENDINGFRIEND{Environment.NewLine}");
            query.Append($"USERID:{id}{Environment.NewLine}");

            this.SendMessage(query.ToString(), OnReceiveOK, OnReceiveNG);
        }

        public void SendUserGetFriends(string id, Action<string> OnReceiveOK, Action<string> OnReceiveNG)
        {
            StringBuilder query = new StringBuilder();
            query.Append($"COMMAND:USER_LISTFRIEND{Environment.NewLine}");
            query.Append($"USERID:{id}{Environment.NewLine}");

            this.SendMessage(query.ToString(), OnReceiveOK, OnReceiveNG);
        }

        public void SendCreateRoom(string id, Action<string> OnReceiveOK, Action<string> OnReceiveNG)
        {
            StringBuilder query = new StringBuilder();
            query.Append($"COMMAND:CREATE_ROOM{Environment.NewLine}");
            query.Append($"CREATOR_USERID:{id}{Environment.NewLine}");

            this.SendMessage(query.ToString(), OnReceiveOK, OnReceiveNG);
        }

        public void SendJoinRoom(string id, string roomid, Action<string> OnReceiveOK, Action<string> OnReceiveNG)
        {
            StringBuilder query = new StringBuilder();
            query.Append($"COMMAND:JOIN_ROOM{Environment.NewLine}");
            query.Append($"USERID:{id}{Environment.NewLine}");
            query.Append($"ROOMID:{roomid}{Environment.NewLine}");

            this.SendMessage(query.ToString(), OnReceiveOK, OnReceiveNG);
        }

        public void SendGetUsers(Action<string> OnReceiveOK, Action<string> OnReceiveNG)
        {
            StringBuilder query = new StringBuilder();
            query.Append($"COMMAND:GET_USERLIST{Environment.NewLine}");

            this.SendMessage(query.ToString(), OnReceiveOK, OnReceiveNG);
        }

        public void SendGetUser(string id, Action<string> OnReceiveOK, Action<string> OnReceiveNG)
        {
            StringBuilder query = new StringBuilder();
            query.Append($"COMMAND:GET_USER{Environment.NewLine}");
            query.Append($"USERID:{id}{Environment.NewLine}");

            this.SendMessage(query.ToString(), OnReceiveOK, OnReceiveNG);
        }

        public void SendUserResetPassword(string id, string newPw, Action<string> OnReceiveOK, Action<string> OnReceiveNG)
        {
            string hashPW = ComputeSHA256Hash(newPw);

            StringBuilder query = new StringBuilder();
            query.Append($"COMMAND:USER_RESETPASSWORD{Environment.NewLine}");
            query.Append($"USERID:{id}{Environment.NewLine}");
            query.Append($"USERPW:{hashPW}{Environment.NewLine}");

            this.SendMessage(query.ToString(), OnReceiveOK, OnReceiveNG);
        }

        // 서버와 연결 후 메시지 전송 시작
        private void SendMessage(string msg, Action<string> OnReceiveOK, Action<string> OnReceiveNG)
        {
            string serverIp = "localhost";
            int port = 1103;
            TcpClient client = new TcpClient();

            client.BeginConnect(serverIp, port, new AsyncCallback(ConnectCallback), new StateObject { Client = client, Message = msg, OnReceiveOK = OnReceiveOK, OnReceiveNG = OnReceiveNG });
        }

        // 서버 연결 완료 시 호출되는 콜백
        private static void ConnectCallback(IAsyncResult ar)
        {
            StateObject state = (StateObject)ar.AsyncState;
            TcpClient client = state.Client;

            try
            {
                client.EndConnect(ar);

                NetworkStream stream = client.GetStream();
                byte[] data = Encoding.ASCII.GetBytes(state.Message);
                stream.BeginWrite(data, 0, data.Length, new AsyncCallback(WriteCallback), state);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }
        }

        // 메시지 전송 완료 후 호출되는 콜백
        private static void WriteCallback(IAsyncResult ar)
        {
            StateObject state = (StateObject)ar.AsyncState;
            TcpClient client = state.Client;

            try
            {
                NetworkStream stream = client.GetStream();
                stream.EndWrite(ar);

                // 서버로부터 응답 읽기 시작
                byte[] buffer = new byte[256];
                stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(ReadCallback), new StateObject { Client = client, OnReceiveOK = state.OnReceiveOK, OnReceiveNG = state.OnReceiveNG, RecvBuffer = buffer });
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }
        }

        // 서버 응답 처리 콜백
        private static void ReadCallback(IAsyncResult ar)
        {
            StateObject state = (StateObject)ar.AsyncState;
            TcpClient client = state.Client;

            try
            {
                NetworkStream stream = client.GetStream();
                int bytesRead = stream.EndRead(ar);

                if (bytesRead > 0)
                {
                    string response = Encoding.ASCII.GetString(state.RecvBuffer, 0, bytesRead);

                    System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        if (response.Contains("RESULT:NG"))
                        {
                            state.OnReceiveNG(response);
                        }
                        else
                        {
                            state.OnReceiveOK(response);
                        }
                    }));
                }

                stream.Close();
                client.Close();
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }
        }
    }
}
