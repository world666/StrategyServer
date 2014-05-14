using System;
using System.Data.Entity.Validation;
using DataRepository.DataAccess;

namespace DataRepository.Models.GenericRepository
{
    public class RepoUnit : IDisposable
    {
        private ServerContext _context;
        private IDataRepository<Users> _Users;
        private IDataRepository<Versions> _Versions;
        private IDataRepository<State> _States;
        private IDataRepository<Region> _Regions;
        private IDataRepository<Business> _Businesses;

        private ServerContext getContext()
        {
            return _context ?? (_context = new ServerContext());
        }


        public IDataRepository<Users> Users
        {
            get { return _Users ?? (_Users = getRepository<Users>()); }
        }

        public IDataRepository<Versions> Versions
        {
            get { return _Versions ?? (_Versions = getRepository<Versions>()); }
        }

        public IDataRepository<State> States
        {
            get { return _States ?? (_States = getRepository<State>()); }
        }

        public IDataRepository<Region> Regions
        {
            get { return _Regions ?? (_Regions = getRepository<Region>()); }
        }

        public IDataRepository<Business> Businesses
        {
            get { return _Businesses ?? (_Businesses = getRepository<Business>()); }
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
