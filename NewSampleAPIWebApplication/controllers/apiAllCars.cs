using Microsoft.AspNetCore.Mvc;
using WebApplication16.DB;

namespace WebApplication16.controllers {

    [ApiController]
    [Route("/[Controller]")]
    public class apiAllCars:ControllerBase {

        ICarsRespoitory _carsRespoitory;
        public apiAllCars(ICarsRespoitory carsRespoitory) {
           _carsRespoitory = carsRespoitory;
        }

        [HttpGet]
        public IActionResult GetCars() {

            return Ok(_carsRespoitory.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindCar(int id) { 
            var res=_carsRespoitory.GetById(id);
            if(res == null) { NotFound(); }
            return Ok(res);
        }
    }
}
