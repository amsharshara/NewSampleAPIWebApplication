using Microsoft.AspNetCore.Mvc;

namespace WebApplication16.controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class apiBook:Controller 
    {
        IBookDB _bookDB;
        public apiBook(IBookDB bookDB ) { _bookDB = bookDB; }

        [HttpGet]
        public async Task<IActionResult> GetAll() { 
            
            return Ok( _bookDB.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = _bookDB.FindBook(id);
            if(res == null)
            {
                return NotFound();
            }
            return Ok(res);

        }
        [HttpPost]
        public async Task<IActionResult> AddBook(BookDB bookDB)
        {
            if(!ModelState.IsValid) { return BadRequest(ModelState); }

            var b=_bookDB.AddBook(bookDB);
            return CreatedAtAction("Get", new { id = b.ID }, b);
            //return Ok( b );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditBook(BookDB bookDB)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var b = _bookDB.EditBook(bookDB);
            if(b == null) return BadRequest(bookDB);
            return Ok(b);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int Id)
        {
            var res=_bookDB.FindBook(Id);
            if (res == null)
            {
                return NotFound();
            }
             

            var b = _bookDB.DeleteBook(res);
            return Ok(b);
        }




    }
}
