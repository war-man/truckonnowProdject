﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDispacher.Dao.Models;

namespace WebDispacher.Dao
{
    public class SqlEntityFramworke
    {
        private Context context = null;
       
        public SqlEntityFramworke()
        {
            context = new Context();
        }

        public bool ExistsDataUser(string login, string password)
        {
            return context.User.FirstOrDefault(u => u.Login == login && u.Password == password) != null;
        }

        public async void SaveKeyDatabays(string login, string password, int key)
        {
            try
            {
                Users users = context.User.FirstOrDefault(u => u.Login == login && u.Password == password);
                users.KeyAuthorized = key.ToString();
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
               
            }
        }

        public bool CheckKeyDb(string key)
        {
            return context.User.FirstOrDefault(u => u.KeyAuthorized == key) != null;
        }
    }
}
