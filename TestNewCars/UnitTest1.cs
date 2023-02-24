using Microsoft.AspNetCore.Mvc;
using WebApplication16.controllers;
using WebApplication16.DB;

namespace TestNewCars {
    public class UnitTest1 {

        apiNewCars _apiNewCars;
        ICarsRespoitory _carsRespoitory;
        public UnitTest1() { 
            
            _carsRespoitory=new CarRespoitory();
            //
            _apiNewCars = new apiNewCars(_carsRespoitory);

        }

        [Fact]
        public void GetALL_Test() {
            //arrange
            var res = _apiNewCars.GetAll();
            //act
            var obj = res as OkObjectResult;
            //assert
            Assert.IsType<OkObjectResult>(obj);
        }
        [Fact]
        public void GetIdOk_Test() {
            //arrange
            var res=_apiNewCars.GetCar(1);
            //act
            var obj = res as OkObjectResult;
            //
            Assert.IsType<OkObjectResult>(obj);
        }

        [Fact]
        public void GetCarIdNotFound_Test() {
            //arrange
            var res = _apiNewCars.GetCar(123);
            //act
            var obj = res as NotFoundResult;
            //
            Assert.IsType<NotFoundResult>(obj);
        }
    }
}


