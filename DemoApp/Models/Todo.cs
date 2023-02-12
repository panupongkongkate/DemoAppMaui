using System.ComponentModel;

namespace DemoApp.Models
{
    public class Todo : INotifyPropertyChanged
    {
        string __id;

        public string _id
        {
            get => __id;
            set
            {
                if (__id == value)
                {
                    return;
                }
                __id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_id)));
            }
        }

        string _todoname;

        public string TodoName
        {
            get => _todoname;
            set
            {
                if (_todoname == value)
                {
                    return;
                }
                _todoname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TodoName)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }

}