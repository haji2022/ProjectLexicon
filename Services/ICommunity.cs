using ProjectLexicon.Models.Events;
using System.Collections.Generic;

namespace ProjectLexicon.Services
{
    public interface ICommunity
    {
        IEnumerable<Event> GetAllCommunityEvents();

        Event GetCommunityById(int id);
        void CreateCommunity(Event events);

        Event UpdateAnEvent(Event updatedEvent);

        void DeleteAnEvent(int id);
    }
}
