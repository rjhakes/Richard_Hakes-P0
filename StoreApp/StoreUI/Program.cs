using System;
using StoreModels;
using StoreBL;
using StoreDL;
using StoreDL.Entities;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
namespace StoreUI
{
    class Program
    {

        static void Main(string[] args)
        {    
            //get the config file
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            //Setting up db connection
            string connectionString = configuration.GetConnectionString("StoreDB");
            DbContextOptions<StoreDBContext> options = new DbContextOptionsBuilder<StoreDBContext>().UseSqlServer(connectionString).Options;

            //using statement used to dispose of the context when its no longer used
            using var context = new StoreDBContext(options);

            IMenu menu = new StoreFrontMenu(context);
            menu.Start();
            
        }
    }
}
