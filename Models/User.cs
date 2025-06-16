// Models/User.cs
using System;

namespace WPFOfficeProject.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDate { get; set; } // DatePicker는 Nullable DateTime을 사용하면 편리
        public string Gender { get; set; }
        public string Phone { get; set; }

        // 필요하다면 추가 생성자나 메서드를 여기에 정의할 수 있습니다.
    }
}