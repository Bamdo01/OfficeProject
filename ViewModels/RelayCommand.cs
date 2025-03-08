using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFOfficeProject
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute; // 명령을 실행하는 로직
        private readonly Predicate<object> _canExecute; // 명령이 실행 가능한지 판단하는 로직

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        // ICommand의 CanExecute 구현
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        // ICommand의 Execute 구현
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        // 명령이 실행 가능 여부가 변경될 때 호출
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }

}
