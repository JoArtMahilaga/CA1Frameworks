﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    internal abstract class User
    {
        private string userName;
        private string role;

        public User(string userName, string role)
        {
            this.userName = userName;
            this.role = role;
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Role
        {
            get { return role; }
            set { role = value; }
        }

        public abstract void DisplayMenu();

    }
}