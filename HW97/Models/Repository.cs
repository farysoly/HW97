using Newtonsoft.Json;
namespace HW97.Models
{
    public abstract class Repository<T>
    {
        string filePath = $@"DataBase\{typeof(T).Name}Db.json";
        public void SetDb(T model)
        {
            var models = GetContent();
            if(models is null)
                models = new List<T>();

            models.Add(model);
            SetContent(models);
        }

        public List<T> GetDb()
        {
            try
            {
                return GetContent();
            }
            catch (Exception)
            {
                return new List<T>();
            }
        }

        List<T> GetContent()
        {
            var content = File.ReadAllText(filePath);
            var list = JsonConvert.DeserializeObject<List<T>>(content);
            return list;
        }

        void SetContent(List<T> list)
        {
            var content = JsonConvert.SerializeObject(list);
            File.WriteAllText(filePath, content);
        }
    }
}
