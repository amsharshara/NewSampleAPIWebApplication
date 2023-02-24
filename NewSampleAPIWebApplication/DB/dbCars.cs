namespace WebApplication16.DB
{
    public class dbCars
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string NO { get; set; }    
        public bool IsNew { get; set; }

    }
    //
    public interface ICarsRespoitory
    {
        public List<dbCars> GetAll();
        public dbCars GetById(int id);
        public bool Edit(dbCars car);
        public bool Delete(int id);
        public bool Insert(dbCars car); 
    }
    //
    public class CarRespoitory : ICarsRespoitory
    {
        private static List<dbCars> lstCars = new List<dbCars>()
        {
            new dbCars() { Id=1, Model="Taxi",NO="123421", IsNew=true},
            new dbCars() { Id=2,Model="Taxi",NO="323123",IsNew=false},
            new dbCars() { Id=3,Model="Truck",NO="234123",IsNew=true}
        };
        public CarRespoitory() { 
            
        
        }

        public bool Delete(int id)
        {
            var res = lstCars.FirstOrDefault(s => s.Id.Equals(id));
            if (res == null) return false;
            else
             lstCars.Remove(res);

            return true; 

        }

        public bool Edit(dbCars car)
        {
            var res =lstCars.FirstOrDefault(s=>s.Id.Equals(car.Id)); 
            if(res == null)
                return false;
            else
            {
                res.NO = car.NO;
                return true;
            }
        }

        public List<dbCars> GetAll()
        {
            return lstCars;
        }

        public dbCars GetById(int id)
        {
            var res=lstCars.FirstOrDefault(s=>s.Id.Equals(id));

            return res;
        }

        public bool Insert(dbCars car)
        {
            lstCars.Add(car);
            return true;

         }
    }
}
