using BigJacob.MVVM;
using BigJacob.Messaging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DemoUI.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region Properties

        private string _recipient;
        /// <summary>
        /// Address of the email recipient
        /// </summary>
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
        /// <summary>
        /// Address of the email sender
        /// </summary>
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
        /// <summary>
        /// Password of the email sender
        /// </summary>
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
        /// <summary>
        /// Email subject
        /// </summary>
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
        /// <summary>
        /// Email body
        /// </summary>
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

        /// <summary>
        /// Send the email
        /// </summary>
        public ICommand Send => new RelayCommand<object>(async x => await SendMessage());

        #endregion

        #region Methods

        /// <summary>
        /// Send a message via SMTP
        /// </summary>
        /// <returns> A task </returns>
        private async Task SendMessage()
        {
            using var email = new SMTPEmail(Sender, Password);
            await email.SendAsync(new List<string>() { Recipient }, Subject, Body);

            MessageBox.Show($"An email has been sent to {Recipient}", "Email sent!");
        }

        #endregion
    }
}