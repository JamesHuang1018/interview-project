
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Demo.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Demo.DAL.DemoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    } 
}