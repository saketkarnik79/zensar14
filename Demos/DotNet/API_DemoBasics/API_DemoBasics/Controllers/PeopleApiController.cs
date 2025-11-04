using API_DemoBasics.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_DemoBasics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class PeopleApiController : ControllerBase
    {
        private static List<Person> people;

        static PeopleApiController()
        {
            people = new List<Person>()
            {
                new Person() { Id = 101, Name = "James", DateOfBirth = DateOnly.Parse("16-Jul-1975")},
                new Person() { Id = 102, Name = "Sophia", DateOfBirth = DateOnly.Parse("05-Mar-1982") },
                new Person() { Id = 103, Name = "Michael", DateOfBirth = DateOnly.Parse("22-Nov-1990") },
                new Person() { Id = 104, Name = "Olivia", DateOfBirth = DateOnly.Parse("14-Jan-1978") },
                new Person() { Id = 105, Name = "Ethan", DateOfBirth = DateOnly.Parse("30-Sep-1985") },
                new Person() { Id = 106, Name = "Ava", DateOfBirth = DateOnly.Parse("09-Jun-1993") }
            };
        }

        // GET: api/<PeopleApiController>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(people);
        }

        // GET api/<PeopleApiController>/5
        //[HttpGet("{id}")]
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var person = people.SingleOrDefault<Person>(p => p.Id == id);
            if (person != null)
            {
                return Ok(person);
            }
            else
            {
                return NotFound("Person not found.");
            }    
        }

        // POST api/<PeopleApiController>
        [HttpPost]
        public IActionResult Post(Person person)
        {
            if (ModelState.IsValid)
            {
                people.Add(person);
                return CreatedAtAction(nameof(Get), new { id = person.Id }, person);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        
        // PUT api/<PeopleController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Person person)
        {
            if(id != person.Id)
            {
                return BadRequest("Id can't be updated.");
            }
            if (ModelState.IsValid)
            {
                var existingPerson = people.SingleOrDefault(p => p.Id == id);
                if (existingPerson != null)
                {
                    existingPerson.Name = person.Name;
                    existingPerson.DateOfBirth = person.DateOfBirth;
                    return NoContent();
                }
                else
                {
                    return NotFound("Person not found.");
                }
            }
            return BadRequest(ModelState);
        }

        // DELETE api/<PeopleApiController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingPerson = people.SingleOrDefault(p => p.Id == id);
            if (existingPerson != null)
            {
                people.Remove(existingPerson);
                return NoContent();
            }
            else
            {
                return NotFound("Person not found.");
            }
        }
    }
}
