using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;
using DataRepository.Services.DataBaseService;

namespace StrategyServices.States
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class StateService : IStateService
    {
        public StateService()
        {
            _statesService = new StatesService();
        }
        public List<StateData> GetStates(int languageId)
        {
            var states = _statesService.GetStates(languageId);
            var retState = states.Select(st => new StateData
            {
                Id = st.Id,
                StatesNames = st.StatesNames,
                StatesNamesList = st.StatesNamesList,
                 CountryDevelopmentCoef = st.CountryDevelopmentCoef,
                CountryCurrencyUnit = st.CountryCurrencyUnit,
                NewsInfluenceCoef = st.NewsInfluenceCoef,
                LicensesExcises = st.LicensesExcises
            }).ToList();
            return retState;
        }
        public List<StateData> GetStates()
        {
            var states = _statesService.GetStates();
            var retState = states.Select(st => new StateData
            {
                Id = st.Id,
                StatesNames = st.StatesNames,
                StatesNamesList = st.StatesNamesList,
                CountryDevelopmentCoef = st.CountryDevelopmentCoef,
                CountryCurrencyUnit = st.CountryCurrencyUnit,
                NewsInfluenceCoef = st.NewsInfluenceCoef,
                LicensesExcises = st.LicensesExcises
            }).ToList();
            return retState;
        }
        public void AddStates(List<StateData> statesList)
        {
            var states = statesList.Select(st => new State
            {
                Id = st.Id,
                StatesNames = st.StatesNames,
                CountryDevelopmentCoef = st.CountryDevelopmentCoef,
                CountryCurrencyUnit = st.CountryCurrencyUnit,
                NewsInfluenceCoef = st.NewsInfluenceCoef,
                LicensesExcises = st.LicensesExcises
            }).ToList();
            _statesService.AddStates(states);
        }
        public void EditStates(List<StateData> statesList)
        {
            var states = statesList.Select(st => new State
            {
                Id = st.Id,
                StatesNames = st.StatesNames,
                CountryDevelopmentCoef = st.CountryDevelopmentCoef,
                CountryCurrencyUnit = st.CountryCurrencyUnit,
                NewsInfluenceCoef = st.NewsInfluenceCoef,
                LicensesExcises = st.LicensesExcises
            }).ToList();
            _statesService.EditStates(states);
        }
        public void DeleteStates(List<int> stateIds)
        {
            _statesService.DeleteStates(stateIds);
        }
        private StatesService _statesService;
    }
}
