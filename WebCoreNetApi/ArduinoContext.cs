using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebCoreNetApi.Models;

namespace WebCoreNetApi
{
    public class ArduinoContext : DbContext
    {
        public ArduinoContext(DbContextOptions<ArduinoContext> options)
           : base(options)
        { }

        public DbSet<Dht> Dhts { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
