using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TdoApi.Models;

namespace TdoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TdoController : ControllerBase
    {
        private readonly TdoContext _context;

        public TdoController(TdoContext context)
        {
            _context = context;

            if (_context.TdoItems.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.TdoItems.Add(new TdoItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<TdoItem>> GetAll()
        {
            return _context.TdoItems.ToList();
        }

        [HttpGet("{id}", Name = "GetTdo")]
        public ActionResult<TdoItem> GetById(long id)
        {
            var item = _context.TdoItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(TdoItem item)
        {
            _context.TdoItems.Add(item);
            _context.SaveChanges();
            return CreatedAtRoute("GetTdo", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, TdoItem item)
        {
            var tdo = _context.TdoItems.Find(id);
            if(tdo == null)
            {
                return NotFound();
            }

            tdo.isComplete = item.isComplete;
            tdo.Name = item.Name;

            _context.TdoItems.Update(tdo);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var tdo = _context.TdoItems.Find(id);
            if(tdo == null)
            {
                return NotFound();
            }

            _context.TdoItems.Remove(tdo);
            _context.SaveChanges();
            return NoContent();
        }

        //[HttpGet("{id}", Name = "GetTdo")]
        //public ActionResult<TdoItem> GetById(long id)
        //{
        //    var item = _context.TdoItems.Find(id);
        //    if(item == null)
        //    {
        //        return NotFound();
        //    }
        //    return item;
        //}
    }
}