using LatinoNetOnline.GenericRepository.Demo.Entities;
using LatinoNetOnline.GenericRepository.Repositories;

using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LatinoNetOnline.GenericRepository.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IRepository<Book> _repository;

        public BooksController(IRepository<Book> repository)
        {
            _repository = repository;
        }


        // GET: api/<BooksController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _repository.GetAllAsync(false);
            return Ok(result);
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _repository.FirstOrDefaultAsync(x => x.Id == id, false);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Book book)
        {
            await _repository.AddAsync(book);
            return Ok(book);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Book book)
        {
            var result = await _repository.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                return BadRequest();

            result.Title = book.Title;
            result.Author = book.Author;

            await _repository.UpdateAsync(result);

            return Ok(result);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _repository.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                return BadRequest();

            await _repository.RemoveAsync(result);

            return Ok();
        }
    }
}
