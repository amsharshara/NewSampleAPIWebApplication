using Microsoft.AspNetCore.Mvc;
using WebApplication16.DB;

namespace WebApplication16.controllers
{
    [Route("/[Controller]")]
    [ApiController]
    public class apiCars:ControllerBase
    {
        private ICarsRespoitory _carsRespoitory;
        public apiCars(ICarsRespoitory carsRespoitory) { 
        _carsRespoitory = carsRespoitory;   
        }

        [HttpGet]
        public IActionResult  GetAll()
        {
            var lst=_carsRespoitory.GetAll();
            return Ok(lst);
        }

        [HttpPost]
        public IActionResult InsertCar(dbCars car)
        {
            _carsRespoitory.Insert(car);
            return Ok();
        }
        [HttpPut]
        public IActionResult EditCar(dbCars car) {
            var res=_carsRespoitory.Edit(car);
            if(res)return Ok();
            else
                return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var res=_carsRespoitory.Delete(id);
            if (res) return Ok();
            else
                return BadRequest();
        }

    }
}
