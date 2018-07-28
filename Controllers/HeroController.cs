using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CSharpTourOfHeroes.Models;

namespace CSharpTourOfHeroes.COntrollers
{
    [Route("api/hero")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly HeroContext _context;

        public HeroController(HeroContext context)
        {
            _context = context;

            if (_context.Hero.Count() == 0)
            {
                _context.Hero.Add(new Hero { Name = "DefaultHero" });
                _context.SaveChanges();
            }
        }

		[HttpGet]
		public ActionResult<List<Hero>> GetAll()
		{
			return _context.Hero.ToList();
		}

		[HttpGet("{id}", Name = "GetHero")]
		public ActionResult<Hero> GetById(long id)
		{
			var item = _context.Hero.Find(id);
			if (item == null)
			{
				return NotFound();
			}
			return item;
		}

		[HttpPost]
		public IActionResult Create(Hero item)
		{
			_context.Hero.Add(item);
			_context.SaveChanges();

			return CreatedAtRoute("GetHero", new { id = item.Id }, item);
		}

		[HttpPut("{id}")]
		public IActionResult Update(long id, Hero item)
		{
			var todo = _context.Hero.Find(id);
			if (todo == null)
			{
				return NotFound();
			}

			todo.Name = item.Name;

			_context.Hero.Update(todo);
			_context.SaveChanges();
			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			var todo = _context.Hero.Find(id);
			if (todo == null)
			{
				return NotFound();
			}

			_context.Hero.Remove(todo);
			_context.SaveChanges();
			return NoContent();
		}
    }
}