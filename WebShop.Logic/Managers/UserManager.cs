﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebShop.Logic.DB;

namespace WebShop.Logic
{
    public class UserManager
    {
        public static Users GetByEmailAndPassword(string email, string password)
        {
            using (var db = new DbContext2())
            {
                return db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            }
        }
        public static Users GetByEmail(string email)
        {
            using (var db = new DbContext2())
            {
                return db.Users.FirstOrDefault(u => u.Email == email);
            }
        }
        public static void Create(string name, string email, string password)
        {
            using (var db = new DbContext2())
            {
                db.Users.Add(new Users()
                {
                    Email = email,
                    Name = name,
                    Password = password,
                });
                db.SaveChanges();
            }
        }

    }
}
