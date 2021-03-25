using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DatingApp.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

// Make our end to end communication between API and clients app work
namespace DatingApp.API.Controllers
{
    // Routing Info
    // Attribute bait based routing - when we specifiy a route inside our controller class
    // This is what's going to be mapped as our endpoint so that when we navigate or make request to this controller, our app knows where to route that request
    // [controller] in square bracket is a placeholder for what's inside the class name ValueController - public class ValuesController
    // when we browse to http: localhost:5000/api/values

    public class ValuesController : BaseApiController
    {
        // instead of returning static values, we want to go into our db retrieve values made in db and return to client
        // client we'll use to retreive is postman for now for testing
        // set up - inject dataContext into this class - add constructor
        // ctor - Name (ValuesController) 
        // parameters is where we inject our dataContext - bring in DatingApp.API.Data to get access to DataContext
        // by bringing in DataContext namespace, we can refer to the class directly that DataContext from DatingApp.API.Data
        // we want to enable 'context' to be accessed throughout our class
        // cmd . - initialize field from parameter - will create a private read only field we can use in our class
        // 
        private readonly DataContext _context;

        public ValuesController(DataContext context)
        {
            _context = context;

        }
        // GET api/values
        // HTTPGet method is used to call each individual method
        // IActionResult returns HTTP responses to the client instead of just returning strings we can return an OK 200

        // **When a request comes in to api/values 
        // - GetValues method 
        // - goes out to our DB(_context) 
        // - get the Values - as a list ToList() 
        //- store it in values var(object) 
        //- return to client w/ http 200 OK response

        [AllowAnonymous]
        [HttpGet]
        // turning to async returning a Task(represents async op that returns a value) with IActionResult
        // anything we're waiting for inside our method, it will keep the thread open and not block any of our request while waiting for response
        public async Task<IActionResult> GetValues()
        {
            // check exception
            // throw new Exception("Test Exception");

            // create database use model first in entity framework
            // – create class represents value then use entity framework
            // allows us to scaffold our db and it's gonna create a table to store our values
            // it's going to have two columns 1. represent the id of the value 2. represent the name
            // return new string[] { "value1", "value3" };

            // get values from db
            // var to store values in and set it to _context.Values(. gives access to our DBSET 'Values')
            // we want to get our values as a list with ToList() method

            // async for scalability
            // our method that goes our to our db, need to tell our method to wait for this response with 'await'
            // need to use async version of our ToList - ToListAsync
            // need to bring in MEF to get access to this ToListAsync() method
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }

        // GET api/values/5
        // Has a route parameter which we pass into our method as part of the HTTP get route 

        // Authentication authorized attribute
        [Authorize]
        [HttpGet("{id}")]
        // pass route param{id} to GetValue(id) as a param
        public async Task<IActionResult> GetValue(int id)
        {
            // return "value";
            // get value referenced by its id with FirstOrDefault
            // FirstOrDefault - returns default value for the type that's returning, if no value - returns null
            // takes in lambda expression - x represents the value we're returning
            // match the value.Id to id we're passing in
            // value will contain the value that matches the int id in our param
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            // return Http OK repsonse with our value
            return Ok(value);
        }

        // POST api/values
        // Used to get when we create a record
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        // Used when we edit a record
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        // Used when we want to delete a record from API
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}