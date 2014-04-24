using System;
using System.Data.Entity.Validation;
using DataRepository.DataAccess;

namespace DataRepository.Models.GenericRepository
{
    public class RepoUnit : IDisposable
    {
        private ServerContext _context;
        private IDataRepository<Users> _Users;

        private ServerContext getContext()
        {
            return _context ?? (_context = new ServerContext());
        }


        public IDataRepository<Users> Users
        {
            get { return _Users ?? (_Users = getRepository<Users>()); }
        }

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Save failed", ex);
            }
        }

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();

            //GC.SuppressFinalize(this);
        }

        private IDataRepository<T> getRepository<T>()
            where T : class, IEntityId
        {
            return new DataRepository<T>(getContext());
        }
    }
}
