using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataRepository.DataAccess
{
    public class ServerDbInitializer : DropCreateDatabaseIfModelChanges<ServerContext>
    {
        protected override void Seed(ServerContext context)
        {
            if (context == null)
                context = new ServerContext();

            

            context.SaveChanges();
        }
    }
}
