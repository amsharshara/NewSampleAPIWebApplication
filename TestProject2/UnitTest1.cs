using Microsoft.AspNetCore.Mvc;
using WebApplication16.controllers;
using WebApplication16.DB;

namespace TestProject2 {
    public class UnitTest1 {
        apiAllCars _apiAllCars;
        ICarsRespoitory _ICarsRespoitory;

        public UnitTest1 () { 
            _ICarsRespoitory=new CarRespoitory();
            _apiAllCars = new apiAllCars(_ICarsRespoitory);
        }

        [Fact]
        public void Test1() {
            //arrange
            var res = _apiAllCars.GetCars();
            //act 
            var obj = res as OkObjectResult;
            //assert
           Assert.IsType<OkObjectResult>(obj); 
            //assert
          // Assert.Equal<OkObjectResult>(typeof(OkObjectResult), obj);
        }

        [Fact]
        public void Test2() {
            //arrange
            var res= _apiAllCars.FindCar(1);
            //ACT
            var obj = res as OkObjectResult;
            //assert
            Assert.IsType<OkObjectResult>(obj);

            


        }
    }
}


