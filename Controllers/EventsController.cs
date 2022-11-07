using Microsoft.AspNetCore.Mvc;
using ProjectLexicon.Models.Events;
using ProjectLexicon.Services;

namespace ProjectLexicon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {

        private readonly ICommunity _community;
        public EventController(ICommunity community)
        {
            _community = community;

        }
        [HttpGet]
        public ActionResult<Event> GetAllCommunity()
        {
            var events = _community.GetAllCommunityEvents();
            if (events != null)
            {
                return Ok(events);
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult CreateEvent(Event newEventFromUser)
        {
            if (newEventFromUser == null)
            {
                return BadRequest();
            }
            _community.CreateCommunity(newEventFromUser);
            return Ok();
        }




        [HttpPut]
        public ActionResult<Event> UpdateEvent(Event eventToBeUpdated)
        {
            if (eventToBeUpdated == null)
            {
                return BadRequest();
            }
            return Ok(_community.UpdateAnEvent(eventToBeUpdated));
        }



        [HttpDelete]

        public ActionResult DeleteAnEvent(int id)
        {
            _community.DeleteAnEvent(id);
            return Ok();
        }



    }
}
