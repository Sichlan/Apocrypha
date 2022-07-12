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

        private MessageType _messageType;

        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HasMessage));
            }
        }

        public MessageType MessageType
        {
            get
            {
                return _messageType;
            }
            set
            {
                _messageType = value;
                OnPropertyChanged();
            }
        }

        public bool HasMessage
        {
            get
            {
                return !string.IsNullOrEmpty(Message);
            }
        }
    }
}