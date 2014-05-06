using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;

namespace DataRepository.DataAccess
{
    public class ServerDbInitializer : DropCreateDatabaseIfModelChanges<ServerContext>
    {
        protected override void Seed(ServerContext context)
        {
            if (context == null)
                context = new ServerContext();

            //Init Versions table
            var versions = new List<Versions>
                {
                    new Versions {VersionName = "BusinessStartegy v1.0"},
                };

            versions.ForEach(v => context.Versions.Add(v));

            context.SaveChanges();
        }
    }
}
