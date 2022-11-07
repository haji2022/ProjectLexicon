using ProjectLexicon.Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectLexicon.Services
{
    public class CommunityImpl : ICommunity
    {
        private readonly ApplicationDbContext _context;

        //public List<Event> Events { get; set; } = new List<Event>();
        public CommunityImpl(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateCommunity(Event @event)
        {
            try
            {
                if (@event == null)
                {
                    throw new ArgumentNullException(nameof(@event));
                }
                _context.Events.Add(@event);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"There has occured an exeception ${ex.Message} on CreateCommunity");
            }
        }



        public IEnumerable<Event> GetAllCommunityEvents()
        {
            var events = _context.Events.ToList();
            if (events != null)
            {
                return events;
            }

            return null;
        }

        public Event GetCommunityById(int id)
        {
            //_context.Events.Id();

            Event eventExist = _context.Events.FirstOrDefault(e => e.Id == id);
            if (eventExist != null)
            {
                return eventExist;
            }

            else
            {
                return null;
            }

        }

        public Event UpdateAnEvent(Event updatedEvent)
        {
            //First we need the existing item 
            //then we want to update it with the updatedEvent 
            if (updatedEvent == null)
            {
                return null;
            }
            var itemToUpdate = _context.Events.FirstOrDefault(item => item.Id == updatedEvent.Id);
            itemToUpdate.Content = updatedEvent.Content;
            itemToUpdate.StartDate = updatedEvent.StartDate;
            itemToUpdate.UserName = updatedEvent.UserName;
            itemToUpdate.Subject = updatedEvent.Subject;

            _context.SaveChanges();

            return itemToUpdate;


        }

        public void DeleteAnEvent(int id)
        {
            //1: wE NEED TO FIND IT.
            var itemToDelete = _context.Events.FirstOrDefault(item => item.Id == id);
            if (itemToDelete != null)
            {
                _context.Events.Remove(itemToDelete);
                _context.SaveChanges();
            }
        }
    }
}
