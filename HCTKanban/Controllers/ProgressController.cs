using HCTKanban.Data;
using HCTKanban.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.ObjectModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HCTKanban.Controllers
{
	[Route("api/progress")]
	[ApiController]
	public class ProgressController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public ProgressController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: api/<ValuesController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<ValuesController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<ValuesController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<ValuesController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<ValuesController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}

		// POST api/<ValuesController>[FromBody] string value
		[HttpGet]
		public async void HelloWorld()
		{
		
				Locations newlocation = new Locations() { LocationName = "API Call" };

				_context.Locations.Add(newlocation);

				await _context.SaveChangesAsync();

		}

		
	}
}
