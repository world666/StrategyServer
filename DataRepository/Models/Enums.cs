namespace DataRepository.Models
{
    public enum RegistrationState
    {
        Success, LoginExist
    }
    public enum AuthorizationState
    {
        Success, WrongLoginOrPassword
    }
    public enum VersionState
    {
        Actual, OutDated
    }
    /*public enum Language
    {
        English, Russian
    } */
}
