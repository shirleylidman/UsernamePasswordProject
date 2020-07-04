using LocalDatabaseTutorial.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace UsernamePasswordProject.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public Command SaveCommand { get; }

        private ObservableCollection<Account> _userListView;

        public event PropertyChangedEventHandler PropertyChanged;

        private string Username_;
        private string Password_;

        private bool _userCreated;

        public bool UserCreated
        {
            get { return _userCreated; }
        }

        public MainPageViewModel()
        {

            _userListView = new ObservableCollection<Account>();

            SaveCommand = new Command(async () =>
            {

                var _user = new Account
                {
                    Username = Username_,
                    Password = Password_

                };

                //call the save to database

                //if the save returns an Account, then user already exists

                //if the save returns null, then the user doesn't exist

                _userCreated = false; //what the result of the save to database returns
                var ar = new PropertyChangedEventArgs(nameof(UserCreated));
                PropertyChanged?.Invoke(this, ar);

                if (_userCreated)
                {
                    _userListView.Add(_user);
                    Username = string.Empty;
                    Password = string.Empty;
                }

                if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))

                    await App.Database.SaveAccountAsync(new Account
                    {
                        Username = Username_,
                        Password = Password_
                    });

                Username = Password = string.Empty;
                _userListView.ItemsSource = await App.Database.GetAccountAsync();


            });

        }

        public ObservableCollection<Account> userListView
        {
            get { return _userListView; }
            set
            {
                if (_userListView != value)
                {
                    _userListView = value;
                    var args = new PropertyChangedEventArgs(nameof(userListView));
                    PropertyChanged?.Invoke(this, args);
                }
            }
        }

        public string Username
        {
            get => Username_;
            set
            {
                if (Username_ != value)
                {
                    Username_ = value;
                    var args = new PropertyChangedEventArgs(nameof(Username));
                    PropertyChanged?.Invoke(this, args);
                }
            }
        }

        public string Password
        {
            get => Password_;
            set
            {
                if (Password_ != value)
                {
                    Password_ = value;
                    var args = new PropertyChangedEventArgs(nameof(Password));
                    PropertyChanged?.Invoke(this, args);
                }
            }
        }


    }
}