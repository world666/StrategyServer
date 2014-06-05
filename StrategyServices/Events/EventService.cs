using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Services.DataBaseService;

namespace StrategyServices.Events
{
    public class EventService : IEventService
    {
        public EventService()
        {
            _eventsService = new EventsService();
        }

        private EventsService _eventsService;
    }
}
