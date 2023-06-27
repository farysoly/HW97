namespace HW97.Models
{
    public class UserRepository : Repository
    {
        public UserRepository() : base(@"D:\.Net\MyProject\HW9\HW97\HW97\DataBase\UsersDb.json")
        {
            
        }
    }
}
