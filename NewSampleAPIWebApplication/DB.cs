namespace WebApplication16
{
    public interface IDB
    {
        public Task<bool> Add(test val);
        public Task<bool> Edit(test val);
        public Task<bool> Delete(int id);
        public Task<List<test>> GetAll();
        public Task<test> Find(int id);
    }
    public  class TesDB:IDB
    {
        private static List<test> lst =
            new List<test>() {
            new test() { id = 1, name = "a" },
            new test() { id = 2, name = "b" },
            new test() { id = 3, name = "c" },
            new test() { id = 4, name = "d" }
        };

        public async Task<bool> Add(test val)
        {
            lst.Add(val);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            test res = lst.Where(s => s.id==id).FirstOrDefault();

            var te = Enumerable.Range(0, 20);
           
           
            return lst.Remove(res);
            
        }

        public async Task<bool> Edit(test val)
        {
            test res = lst.Where(s => s.id == val.id).FirstOrDefault();

            res.name=val.name;
            return true; 
         }

        public Task<test> Find(int id)
        {
            test res = lst.Where(s => s.id ==  id).FirstOrDefault();
            return    Task.Run( () =>   res);
        }

        public async Task<List<test>> GetAll()
        {
            return  lst;
        }
    }
    public class test
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
