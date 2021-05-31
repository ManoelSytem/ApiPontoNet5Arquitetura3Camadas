using Microsoft.EntityFrameworkCore;
using Model.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Config
{
    public class ContextBase : DbContext
    {

        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetStringConectionConfig());
                base.OnConfiguring(optionsBuilder);
            }
        }

        public DbSet<ProdutoViewModel> ProdutoViewModel { get; set; }

        private string GetStringConectionConfig()
        {
            string strCon = "Data Source=DESKTOP-HVNTI80\\DESENVOLVIMENTO;Initial Catalog=API_CORE_AULA;Integrated Security=False;User ID=sa;Password=1234;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            return strCon;
        }



    }
}
