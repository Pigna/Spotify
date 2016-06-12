﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Models
{
    public abstract class Account
    {
        public string Username { get; set; }

        public Account(string username)
        {
            Username = username;
        }
    }
}
