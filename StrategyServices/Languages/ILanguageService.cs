using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace StrategyServices.Languages
{
    [ServiceContract]
    public interface ILanguageService
    {
        [OperationContract]
        List<string> GetLanguages();

        [OperationContract]
        int GetLanguagesCount();

        [OperationContract]
        List<LanguageData> GetLanguagesList();

        [OperationContract]
        void AddLanguages(List<LanguageData> newLanguages);

        [OperationContract]
        void EditLanguages(List<LanguageData> languagesList);

        [OperationContract]
        void DeleteLanguages(List<int> languageIds);
    }

    [DataContract]
    public class LanguageData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string LanguageName { get; set; }
    }
}
