﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Hero
    {
        private string _username;
        private int _level;
        public Hero(string username, int level)
        {
            this.Username = username;
            this.Level = level;
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }
        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }
    }
}
