using DataRepository.Services.DataBaseService;

namespace StrategyServices.News
{
    public class NewService : INewService
    {
        public NewService()
        {
            _newsService = new NewsService();
        }

        private NewsService _newsService;
    }
}
