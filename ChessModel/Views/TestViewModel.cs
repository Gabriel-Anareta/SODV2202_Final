using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel.Views
{
    public class TestViewModel : INotifyPropertyChanged
    {
        private TestCommand _testCommand;
        public TestCommand TestCommand
        {
            get { return _testCommand; }
            set
            {
                if (_testCommand == value)
                    return;
                _testCommand = value;
                OnPropertyChanged(); // notify form elements
            }
        }

        public TestViewModel() 
        {
            TestCommand = new TestCommand(obj => TestFunc(obj));
        }

        private void TestFunc(object obj)
        {
            return;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
