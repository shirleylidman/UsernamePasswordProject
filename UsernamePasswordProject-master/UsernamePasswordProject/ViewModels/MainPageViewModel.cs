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
        public ObservableCollection<string> NotesCollection { get; set; }

        /*public ObservableCollection<User> userListView { get; set; }
         
        public class User
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }*/

        public event PropertyChangedEventHandler PropertyChanged;

        private string Username_;
        private string Password_;
        private string usernameListView_;
        private string paswordListView_;

        public MainPageViewModel()
        {

            NotesCollection = new ObservableCollection<string>();

            SaveCommand = new Command(() =>
            {
                /*var _user = new Account
                {
                    Username = _user.Name,
                    Password = _user.Password

                };*/

                NotesCollection.Add(Username);
                NotesCollection.Add(Password);
                NotesCollection.Add(usernameListView);
                NotesCollection.Add(paswordListView);

                Username = string.Empty;
                Password = string.Empty;
                usernameListView = string.Empty;
                paswordListView = string.Empty;


                /*userListView = new ObservableCollection<User>();

                userListView.Add(new User() { Username = "Alyssa", Password = "abc" });
                userListView.Add(new User() { Username = "Brennan", Password = "123" });*/

            });

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

        public string usernameListView
        {
            get => usernameListView_;
            set
            {
                if (usernameListView_ != value)
                {
                    usernameListView_ = value;
                    var args = new PropertyChangedEventArgs(nameof(usernameListView));
                    PropertyChanged?.Invoke(this, args);
                }
            }
        }

        public string paswordListView
        {
            get => paswordListView_;
            set
            {
                if (paswordListView_ != value)
                {
                    paswordListView_ = value;
                    var args = new PropertyChangedEventArgs(nameof(paswordListView));
                    PropertyChanged?.Invoke(this, args);
                }
            }
        }


    }
}
