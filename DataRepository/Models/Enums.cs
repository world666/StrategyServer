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
}
