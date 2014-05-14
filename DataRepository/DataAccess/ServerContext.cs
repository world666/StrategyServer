using System.Data.Entity;
using DataRepository.Models;

namespace DataRepository.DataAccess
{
    public class ServerContext : DbContext
    {
        public IDbSet<Users> Users { get; set; }
        public IDbSet<Versions> Versions { get; set; }
        public IDbSet<States> States { get; set; }
        public IDbSet<Regions> Regions { get; set; }
        public IDbSet<Businesses> Businesses { get; set; }

        public ServerContext()
            : base(GetConnectionName())
        {
            Configuration.LazyLoadingEnabled = true;
        }

        protected static string GetConnectionName() {
            return @"Data Source=.\SQLEXPRESS; Database=ServerDataBase;Integrated Security=True;";
            //return @"Data Source=.\SQLExpress;Database=MineDb3;Trusted_Connection=True;";
            //return @"Data Source=(localdb)\Projects;Database=MineDb;Trusted_Connection=True;";

        }
    }
}
