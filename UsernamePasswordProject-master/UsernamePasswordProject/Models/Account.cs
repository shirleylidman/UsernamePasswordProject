﻿using SQLite;

namespace LocalDatabaseTutorial.Models
{
    public class Account
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}