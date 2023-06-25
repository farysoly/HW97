using Newtonsoft.Json;
namespace HW97.Models
{
    public static class Repository
    {
        static string usersDbPath = @"D:\.Net\MyProject\HW9\HW97\HW97\DataBase\UsersDb.json";
        
        public static void SetUsersDb(UserModel user)
        {
            var users = GetContent<UserModel>();
            users.Add(user);
            SetContent(users);
        }

        public static List<UserModel> GetUsers()
        {
            try
            {
                return GetContent<UserModel>();
            }
            catch (Exception)
            {
                return new List<UserModel>();
            }
        }

        static List<T> GetContent<T>()
        {
            var content = File.ReadAllText(usersDbPath);
            var list = JsonConvert.DeserializeObject<List<T>>(content);
            return list;
        }

        static void SetContent<T>(List<T> list)
        {
            var content = JsonConvert.SerializeObject(list);
            File.WriteAllText(usersDbPath, content);
        }
    }
}
