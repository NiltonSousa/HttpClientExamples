using Microsoft.EntityFrameworkCore;
using Padoca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Padoca.Data
{
    public class DataContext: DbContext
    {
        #region Constructor
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        #endregion

        #region Properties
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Prato> Prato { get; set; }
        public DbSet<Receita> Receita { get; set; }

        #endregion
    }
}
