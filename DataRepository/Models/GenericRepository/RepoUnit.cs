using System;
using System.Data.Entity.Validation;
using DataRepository.DataAccess;

namespace DataRepository.Models.GenericRepository
{
    public class RepoUnit : IDisposable
    {
        private ServerContext _context;
        private IDataRepository<User> _Users;
        private IDataRepository<Version> _Versions;
        private IDataRepository<Language> _Languages;
        private IDataRepository<State> _States;
        private IDataRepository<Region> _Regions;
        private IDataRepository<Business> _Businesses;
        private IDataRepository<Action> _Actions;
        private IDataRepository<New> _News;
        private IDataRepository<ActiveBusiness> _ActiveBusinesses;

        private ServerContext getContext()
        {
            return _context ?? (_context = new ServerContext());
        }


        public IDataRepository<User> Users
        {
            get { return _Users ?? (_Users = getRepository<User>()); }
        }

        public IDataRepository<Version> Versions
        {
            get { return _Versions ?? (_Versions = getRepository<Version>()); }
        }

        public IDataRepository<Language> Languages
        {
            get { return _Languages ?? (_Languages = getRepository<Language>()); }
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

        public IDataRepository<Action> Actions
        {
            get { return _Actions ?? (_Actions = getRepository<Action>()); }
        }

        public IDataRepository<New> News
        {
            get { return _News ?? (_News = getRepository<New>()); }
        }

        public IDataRepository<ActiveBusiness> ActiveBusinesses
        {
            get { return _ActiveBusinesses ?? (_ActiveBusinesses = getRepository<ActiveBusiness>()); }
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
