using System.Data.Entity;
using DataRepository.Models;

namespace DataRepository.DataAccess
{
    public class ServerContext : DbContext
    {
        public IDbSet<User> Users { get; set; }
        public IDbSet<Version> Versions { get; set; }
        public IDbSet<State> States { get; set; }
        public IDbSet<Region> Regions { get; set; }
        public IDbSet<Business> Businesses { get; set; }
        public IDbSet<Action> Actions { get; set; }
        public IDbSet<Event> Events { get; set; }

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
