using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPFOfficeProject
{
    public class NotepadViewModel : INotifyPropertyChanged
    {
        // ✅ 메모 항목 클래스
        public class NoteItem : INotifyPropertyChanged
        {
            private string _title;
            private string _content;

            public string Title
            {
                get => _title;
                set { _title = value; OnPropertyChanged(nameof(Title)); }
            }

            public string Content
            {
                get => _content;
                set { _content = value; OnPropertyChanged(nameof(Content)); }
            }

            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // ✅ 메모 리스트
        private ObservableCollection<NoteItem> _notes;
        public ObservableCollection<NoteItem> Notes
        {
            get => _notes;
            set
            {
                _notes = value;
                OnPropertyChanged(nameof(Notes));
            }
        }

        // ✅ 현재 선택된 메모
        private NoteItem _selectedNote;
        public NoteItem SelectedNote
        {
            get => _selectedNote;
            set
            {
                _selectedNote = value;
                OnPropertyChanged(nameof(SelectedNote));
            }
        }

        // ✅ 버튼에 바인딩할 커맨드들
        public ICommand NewNoteCommand { get; }
        public ICommand DeleteNoteCommand { get; }

        // ✅ 생성자
        public NotepadViewModel()
        {
            // 리스트 초기화
            Notes = new ObservableCollection<NoteItem>();

            // 커맨드 연결
            NewNoteCommand = new RelayCommand(NewNote);
            DeleteNoteCommand = new RelayCommand(DeleteNote);// 메모관련된 기능이라 일단 스킵할게요

            // 기본 메모 추가
            Notes.Add(new NoteItem { Title = "첫 메모", Content = "내용을 입력하세요." });
            SelectedNote = Notes[0];
        }

        // ✅ 새 메모 생성 (현재는 메시지 출력만)
        private void NewNote()
        {
            // TODO: 새 메모 추가 기능 구현 예정
            MessageBox.Show("새 메모 버튼 클릭됨");
        }

        // ✅ 메모 삭제 (현재는 메시지 출력만)
        private void DeleteNote()
        {
            // TODO: 메모 삭제 기능 구현 예정
            MessageBox.Show("삭제 버튼 클릭됨");
        }

        // ✅ INotifyPropertyChanged 구현
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
