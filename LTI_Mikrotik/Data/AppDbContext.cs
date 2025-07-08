using Microsoft.EntityFrameworkCore;

namespace LTI_Mikrotik.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ALTERAR O CAMINHO DA BASE DE DADOS AQUI
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\joaom\\Documents\\GitHub\\LTI-TL1\\LTI_Mikrotik\\Data\\Mikrotik.mdf;Integrated Security=True");
        }
    }
}
