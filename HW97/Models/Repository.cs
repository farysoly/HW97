using Newtonsoft.Json;
namespace HW97.Models
{
    public abstract class Repository
    {
        string filePath = @"D:\C#\MaktabSharif\HW\week9\HW97\DataBase\";
        //D:\C#\MaktabSharif\HW\week9\HW97\DataBase\UserModelDb.json
        //"D:\\.Net\\MyProject\\HW9\\HW97\\HW97\\DataBase\\UserModelDb.json"
        public void SetDb<T>(T model) where T : class
        {
            var models = GetContent<T>(model);
            models.Add(model);
            SetContent(models);
        }

        public List<T> GetDb<T>(T model) where T : class
        {
            try
            {
                return GetContent<T>(model);
            }
            catch (Exception)
            {
                return new List<T>();
            }
        }

        List<T> GetContent<T>(T model)
        {
            var path = $@"{filePath}{typeof(T).Name}Db.json";
            var content = File.ReadAllText(path);
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
