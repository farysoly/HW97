using Newtonsoft.Json;
namespace HW97.Models
{
    public abstract class Repository
    {
        string filePath = @"D:\.Net\MyProject\HW9\HW97\HW97\DataBase\";
        
        public void SetDb<T>(T model) where T : class
        {
            var models = GetContent<T>();
            models.Add(model);
            SetContent(models);
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
            var content = File.ReadAllText($@"{filePath}{nameof(T)}Db.json");
            var list = JsonConvert.DeserializeObject<List<T>>(content);
            return list;
        }

        void SetContent<T>(List<T> list)
        {
            var content = JsonConvert.SerializeObject(list);
            File.WriteAllText($@"{filePath}{nameof(T)}Db.json", content);
        }
    }
}
