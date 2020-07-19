using BigJacob.MVVM;
using Messaging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DemoUI.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region Properties

        private string _recipient;
        public string Recipient
        {
            get => _recipient;
            set
            {
                if (_recipient != value)
                {
                    _recipient = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _sender;
        public string Sender
        {
            get => _sender;
            set
            {
                if (_sender != value)
                {
                    _sender = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _subject;
        public string Subject
        {
            get => _subject;
            set
            {
                if (_subject != value)
                {
                    _subject = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _body;
        public string Body
        {
            get => _body;
            set
            {
                if (_body != value)
                {
                    _body = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Commands

        public ICommand Send => new RelayCommand<object>(async x => await SendMessage());

        #endregion

        #region Methods

        private async Task SendMessage()
        {
            var email = new SMTPEmail();
            await email.SendAsync(Sender, Password, new List<string>() { Recipient }, Subject, Body);
        }

        #endregion
    }
}