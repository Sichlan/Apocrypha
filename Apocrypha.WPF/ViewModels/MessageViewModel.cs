namespace Apocrypha.WPF.ViewModels
{
    public enum MessageType
    {
        Information,
        Warning,
        Error,
        Success
    }
    
    public class MessageViewModel : BaseViewModel
    {
        private string _message = string.Empty;

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HasMessage));
            }
        }

        private MessageType _messageType;

        public MessageType MessageType
        {
            get => _messageType;
            set
            {
                _messageType = value;
                OnPropertyChanged();
            }
        }

        public bool HasMessage => !string.IsNullOrEmpty(Message);
    }
}