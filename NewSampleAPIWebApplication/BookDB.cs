using System.ComponentModel.DataAnnotations;

namespace WebApplication16
{
    public interface IBookDB
    {
        public IEnumerable<BookDB> GetAll();
        public BookDB AddBook(BookDB bookDB);
        public BookDB EditBook(BookDB bookDB); 
        public bool DeleteBook(BookDB bookDB);

        public BookDB FindBook(int Id);
    }
    public class RepostoryBookDB : IBookDB
    {
        private List<BookDB> bookDBs =new List<BookDB>()
        {
            new BookDB()
            {
                 ID = 1,
                 Author="Ammar",
                 Description="test ammr",
                 Title="Go Ammar"
            },
            new BookDB()
            {
                 ID = 2,
                 Author="Alaa",
                 Description="test ammar",
                 Title="Go Alaa"
            },
            new BookDB()
            {
                 ID = 3,
                 Author="samer",
                 Description="test samer",
                 Title="Go samer"
            }
        };   
        
        public BookDB AddBook(BookDB bookDB)
        {
            bookDBs.Add(bookDB);
            return bookDB;
        }

        public bool DeleteBook(BookDB bookDB)
        {
            bookDBs.Remove(bookDB); 
            return true;
        }

        public BookDB EditBook(BookDB bookDB)
        {
            var s=FindBook(bookDB.ID);
            if (s == null) return null;
            s.Author = bookDB.Author;
            s.Description = bookDB.Description;
            s.Title = bookDB.Title;
            return bookDB;
        }

        public BookDB FindBook(int Id)
        {
            var b=bookDBs.FirstOrDefault(s=>s.ID.Equals(Id));
            return b;
        }

        public IEnumerable<BookDB> GetAll()
        {
            return bookDBs ;
        }
    }

    public class BookDB
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; } 
        
    }
}
