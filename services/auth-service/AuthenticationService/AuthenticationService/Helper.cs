using Newtonsoft.Json;


namespace AuthenticationService
{
    public static class Helper
    {

        public static T? TryReadJsonFile<T>(string path) where T : notnull
        {
            if(!File.Exists(path))
            {
                Console.WriteLine("Couldn't find Config Json File");
                return default(T);
            }

            string fileAsText = File.ReadAllText(path);
            try
            {
                var result = JsonConvert.DeserializeObject<T>(fileAsText);
                return result;
            }
            catch(JsonSerializationException ex)
            {
                Console.WriteLine(ex.Message);
                return default(T);
            }
            catch(Exception e)
            {
                Console.WriteLine("Cannot convert json file because of unknown reasons");
                return default(T);
            }


        }


    }
}

