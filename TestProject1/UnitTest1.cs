using WebApplication16;
using WebApplication16.controllers;
 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication16.DB;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        apiAllCars _apiAllcars;
        ICarsRespoitory carsRespoitory;

        apiBook _apiBook;
        IBookDB _bookDB;
        public UnitTest1()
        {
            _bookDB = new RepostoryBookDB();
            _apiBook = new apiBook(_bookDB);
            //
            carsRespoitory=new CarRespoitory();
            _apiAllcars = new apiAllCars(carsRespoitory);

        }

        [TestMethod]
        public async Task GetAllCars_Test() {
            //arrange
            var res=_apiAllcars.GetCars();
            //act
            var ok = res as OkObjectResult;
            //assert
            Assert.IsInstanceOfType(ok, typeof(OkObjectResult));
        }


        [TestMethod]
        public async Task  GetAllTest()
        {
            //arrange
            //act
            var result = await _apiBook.GetAll();
            //assert
            Assert.IsInstanceOfType (result, typeof(OkObjectResult));

            var valResult = result as OkObjectResult;

            Assert.IsInstanceOfType(valResult.Value, typeof(List<BookDB>));
           
            var lstbook= valResult.Value as List<BookDB>;

            Assert.AreEqual(3 , lstbook.Count);
        }

        [TestMethod]
        public async Task Get_UnknownTest() {
            //arrange
            var res = await _apiBook.Get(10);
            //act 
            var not= res as NotFoundResult;
            //
            Assert.IsInstanceOfType(res,typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task Get_Test()
        {
            //arrange
            var res=await _apiBook.Get(1);
            //act
            var Ok=res as OkObjectResult;
            //
            Assert.IsInstanceOfType(Ok, typeof(OkObjectResult));
        }


        [TestMethod]
        public async Task AddBook_Error_Test()
        {
            //arrange
            var bookDB = new BookDB()
            {
                 ID = 112,
                  Author="amaar",
                   Description="aa"
            };

            //act
            _apiBook.ModelState.AddModelError("Title","Required");
            var res=await _apiBook.AddBook(bookDB);

            //assert
            var bad=res as BadRequestObjectResult;
            Assert.IsInstanceOfType(bad, typeof(BadRequestObjectResult));    

        }

        [TestMethod]
        public async Task AddBook_OK_Test()
        {
            //arrange
            var book = new BookDB()
            {
                ID = 112,
                Author = "Test",
                Description = "Test",
                Title = "Test",
            };

            //act
            var res=await _apiBook.AddBook(book);

            var ok=res as CreatedAtActionResult;

            //assert
            Assert.IsInstanceOfType(ok,typeof(CreatedAtActionResult));  
        }


        [TestMethod]
        public async Task DeleteBook_NotFound_Test()
        {
            //arrange
            var res = await _apiBook.DeleteBook(12);
            //act
            var notfound = res as NotFoundResult;
            //assert
            Assert.IsInstanceOfType(notfound, typeof(NotFoundResult));

        }

        [TestMethod]
        public async Task DeleteBook_Test()
        {
            //arrange
            var res=await _apiBook.DeleteBook(1);
            //act 
            var book=res as OkObjectResult;
            //assert
            Assert.IsInstanceOfType(book, typeof(OkObjectResult));
           
        }

        [TestMethod]
        public async Task EditBook_OkTest()
        {
            //arrange
            var b = new BookDB() { ID = 1, Author = "Test", Description = "Test", Title = "Test" };
            //act
            var res=await _apiBook.EditBook(b);

            var ok=res as OkObjectResult;   
            //assert 
            Assert.IsInstanceOfType(res, typeof(OkObjectResult));   

        }


        [TestMethod]
        public async Task EditBook_UnkonwnTest()
        {
            //arrange
            var b = new BookDB() { ID = 134, Author = "Test", Description = "Test", Title = "Test" };
            //act
            var res = await _apiBook.EditBook(b);

            var ok = res as BadRequestObjectResult;
            //assert 
            Assert.IsInstanceOfType(res, typeof(BadRequestObjectResult));

        }

    }
}