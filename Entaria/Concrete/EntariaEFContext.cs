using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Entaria.Models;

namespace Entaria.Concrete
{
    public class EntariaEFContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Card> Cards { get; set; }

        public DbSet<Reader> Readers { get; set; }

        public DbSet<LoyaltyCardHolder> LoyaltyCardHolders { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<ClientCardBalance> ClientCardBalances { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<TransactionType> TransactionTypes { get; set; }

        // add other tables here later
    }
}