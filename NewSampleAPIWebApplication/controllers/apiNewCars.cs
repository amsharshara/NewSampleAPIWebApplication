using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication16.DB;

namespace WebApplication16.controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class apiNewCars : ControllerBase {
        ICarsRespoitory _carsRespoitory;
        public apiNewCars(ICarsRespoitory carsRespoitory) {
            _carsRespoitory = carsRespoitory;
        }
        //
        [HttpGet]
        public IActionResult GetAll() {
            var res=_carsRespoitory.GetAll();

            return Ok(res);

        }

        [HttpGet("{id}")]
        public IActionResult GetCar(int id) { 

            var res=_carsRespoitory.GetById(id);
            if(res == null) { return NotFound(); }
            return Ok(res);
        }
    }
}
