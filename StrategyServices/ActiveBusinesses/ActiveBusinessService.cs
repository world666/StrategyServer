using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;
using DataRepository.Services.DataBaseService;

namespace StrategyServices.ActiveBusinesses
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class ActiveBusinessService : IActiveBusinessService
    {
        public ActiveBusinessService()
        {
            _activeBusinessesService = new ActiveBusinessesService();
        }

        public ActiveBusinessAddedState AddBusiness(ActiveBusinessData newActiveBusiness)
        {
            var activeBusinesses = new ActiveBusiness
            {
                Id = newActiveBusiness.Id,
                UserId = newActiveBusiness.UserId,
                BusinessId = newActiveBusiness.BusinessId,
                StartDate = newActiveBusiness.StartDate,
                LastUpdate = newActiveBusiness.LastUpdate,
                LeasePurchase = newActiveBusiness.LeasePurchase
            };
            var addedState = _activeBusinessesService.AddBusiness(activeBusinesses);
            return addedState;
        }

        public void DeleteBusiness(int activeBusinessId)
        {
            _activeBusinessesService.DeleteBusiness(activeBusinessId);
        }

        public List<ActiveBusinessData> GetActiveBusinesses(int userId)
        {
            var activeBusinesses = _activeBusinessesService.GetActiveBusinesses(userId);
            var retActiveBusiness = activeBusinesses.Select(st => new ActiveBusinessData
            {
                Id = st.Id,
                UserId = st.UserId,
                BusinessId = st.BusinessId,
                StartDate = st.StartDate,
                LastUpdate = st.LastUpdate,
                LeasePurchase = st.LeasePurchase
            }).ToList();
            return retActiveBusiness;
        }

        public List<BusinessData> GetBusinesses(int userId)
        {
            var businesses = _activeBusinessesService.GetBusinesses(userId);
            var retBusiness = businesses.Select(st => new BusinessData
            {
                Id = st.Id,
                BusinessesNames = st.BusinessesNames,
                BusinessesNamesList = st.BusinessesNamesList,
                Descriptions = st.Descriptions,
                DescriptionsList = st.DescriptionsList,
                Addresses = st.Addresses,
                AddressesList = st.AddressesList,
                RegionId = st.RegionId
            }).ToList();
            return retBusiness;
        }

        private ActiveBusinessesService _activeBusinessesService;
    }
}
