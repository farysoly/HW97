using Newtonsoft.Json;
namespace HW97.Models
{
    public abstract class Repository
    {
        string filePath = "";
        
        public Repository(string filePath) => this.filePath = filePath;
        public void SetDb<T>(T user) where T : class
        {
            var users = GetContent<T>();
            users.Add(user);
            SetContent(users);
        }

        public List<T> GetDb<T>() where T : class
        {
            try
            {
                return GetContent<T>();
            }
            catch (Exception)
            {
                return new List<T>();
            }
        }

        List<T> GetContent<T>()
        {
            var content = File.ReadAllText(filePath);
            var list = JsonConvert.DeserializeObject<List<T>>(content);
            return list;
        }

        void SetContent<T>(List<T> list)
        {
            var content = JsonConvert.SerializeObject(list);
            File.WriteAllText(filePath, content);
        }
    }
}
