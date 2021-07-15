using Microsoft.AspNetCore.Mvc;
using MongoRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        public IRepo<Item> _Repo;

        public ItemController(IRepo<Item> repo)
        {
            _Repo = repo;
        }

        [HttpGet]
        public async Task<List<Item>> GetItem()
        {
            List<Item> item = await _Repo.GetAll();
            return item;
        }

        [HttpGet("{id}", Name = "GetItem")]
        public async Task<Item> GetItemById(string id)
        {
            Item item = await _Repo.GetById(id);
            return item;
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(Item item)
        {
            await _Repo.InsertOne(item);
            return CreatedAtRoute("GetItem", new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(string id)
        {
            await _Repo.DeleteOne(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(string id, Item item)
        {
            await _Repo.UpdateOne(item.Id, item);
            return NoContent();
        }
    }
}
