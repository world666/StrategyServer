using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;
using DataRepository.Services.DataBaseService;

namespace StrategyServices.Businesses
{
    public class BusinessService : IBusinessService
    {
        public BusinessService()
        {
            _businessesService = new BusinessesService();
        }
        public List<BusinessData> GetBusinesses(Language lang, int regionId)
        {
            var businesses = _businessesService.GetBusinesses(lang, regionId);
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
        public List<BusinessData> GetBusinesses(int regionId)
        {
            var businesses = _businessesService.GetBusinesses(regionId);
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
        public void AddBusinesses(List<BusinessData> businessesList)
        {
            var businesses = businessesList.Select(st => new Business
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
            _businessesService.AddBusinesses(businesses);
        }
        public void EditBusinesses(List<BusinessData> businessesList)
        {
            var businesses = businessesList.Select(st => new Business
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
            _businessesService.EditBusinesses(businesses);
        }
        public void DeleteBusinesses(List<int> businessIds)
        {
            _businessesService.DeleteBusinesses(businessIds);
        }
        private BusinessesService _businessesService;
    }
}
