using GamesMania.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesMania.Data
{
    public class DataContext : DbContext
    {
        #region Constructors
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        #endregion

        #region Properties
        public DbSet<Jogo> Jogo { get; set; }
        public DbSet<Fabricante> Fabricante { get; set; }
        #endregion
    }
}
