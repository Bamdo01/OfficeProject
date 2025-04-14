using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Threading;

namespace WPFOfficeProject
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        private readonly DispatcherTimer _chatTimer;
        private readonly Random _rand = new Random();

        public ObservableCollection<ChatMessage> Messages { get; set; } = new ObservableCollection<ChatMessage>();

        private string _newMessage;
        public string NewMessage
        {
            get => _newMessage;
            set
            {
                _newMessage = value;
                OnPropertyChanged(nameof(NewMessage));
            }
        }

        public ICommand SendCommand { get; }

        public ChatViewModel()
        {
            SendCommand = new RelayCommand(SendMessage);

            _chatTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(10)
            };
            _chatTimer.Tick += (s, e) => GenerateFakeMessage();
            _chatTimer.Start();

            GenerateFakeMessage(); // 시작하자마자 한 번 실행
        }

        private void SendMessage(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(NewMessage))
            {
                Messages.Add(new ChatMessage
                {
                    Content = "[나] " + NewMessage,
                    Timestamp = DateTime.Now,
                    IsMine = true //내꺼니까 참
                });

                NewMessage = "";
            }
        }

        private void GenerateFakeMessage()
        {
            string[] fakeMessages = {
                "안녕~", "뭐해?", "ㅋㅋㅋㅋ", "그게 진짜야?", "대박이네", "나 지금 쉬는 중이야",
                "나중에 보자", "밥 먹었어?", "헐 그건 좀", "지금 채팅하는 중이야"
            };

            Messages.Add(new ChatMessage
            {
                Content = "[상대방] " + fakeMessages[_rand.Next(fakeMessages.Length)],
                Timestamp = DateTime.Now,
                IsMine = false //상대방이니까 거짓
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
