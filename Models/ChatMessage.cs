using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFOfficeProject
{
    public class ChatMessage
    {
        public string Content { get; set; }    // 채팅 내용
        public DateTime Timestamp { get; set; } // 보낸 시간 (옵션)
        public bool IsMine { get; set; }//누가 보낸건지 확인
    }
}
