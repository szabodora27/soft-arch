using System.Collections.Generic;
using DrawingTable.Dal;
using DrawingTable.Model.Entitites;
using Microsoft.AspNetCore.Mvc;

namespace DrawingTableApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrawingTableController : ControllerBase
    {
        private readonly DrawingTableContext _context;

        [HttpGet]
        public ActionResult<List<DemoItem>> GetAll()
        {
            //return _context.DemoItems.ToList();ű
            return null;
        }

        [HttpGet("{id}", Name = "GetDemo")]
        public ActionResult<DemoItem> GetById(long id)
        {
            var item = _context.DemoItems.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public IActionResult Create(DemoItem item)
        {
            _context.DemoItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetDemo", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, DemoItem item)
        {
            var demo = _context.DemoItems.Find(id);

            if (demo == null)
            {
                return NotFound();
            }

            demo.IsComplete = item.IsComplete;
            demo.Name = item.Name;

            _context.DemoItems.Update(demo);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var demo = _context.DemoItems.Find(id);

            if (demo == null)
            {
                return NotFound();
            }

            _context.DemoItems.Remove(demo);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
