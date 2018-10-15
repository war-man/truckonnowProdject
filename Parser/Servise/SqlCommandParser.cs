﻿using DaoModels.DAO;
using DaoModels.DAO.Models;
using Parser.Servise;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Parser.DAO
{
    public class SqlCommandParser
    {
        private Context context = null;

        public SqlCommandParser()
        {
            context = new Context();
        }

        public async Task AddOrder(Shipping shipping)
        {
            bool isCheckOrder = CheckOrder(shipping);
            if (!isCheckOrder)
            {
                LogEr.Logerr("Info", $"Order added to database, Load Id {shipping.Id}", "ParseDataInUrl", DateTime.Now.ToShortTimeString());
                await context.Shipping.AddAsync(shipping);
                await context.SaveChangesAsync();
            }
            else
            {
                LogEr.Logerr("Info", $"Order already exists in the database, Load Id {shipping.Id}", "AddOrder", DateTime.Now.ToShortTimeString());
            }
        }

        private bool CheckOrder(Shipping shipping)
        { 
            return context.Shipping.FirstOrDefault(s => s.Id == shipping.Id) != null; ;
        }
    }
}