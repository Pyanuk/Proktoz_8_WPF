using System.Text.Json;

namespace LibraryJson
{
    public static class Json
    {
        public static void SerializeToFile<T>(T obj, string filePath)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(obj);
                File.WriteAllText(filePath, jsonString);
                Console.WriteLine($"Объект успешно сериализован и записан в файл: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сериализации и записи в файл: {ex.Message}");
            }
        }

        public static T DeserializeFromFile<T>(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string jsonString = File.ReadAllText(filePath);
                    T obj = JsonSerializer.Deserialize<T>(jsonString);
                    Console.WriteLine($"Объект успешно десериализован из файла: {filePath}");
                    return obj;
                }
                else
                {
                    Console.WriteLine($"Файл не найден: {filePath}");
                    return default;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при десериализации из файла: {ex.Message}");
                return default;
            }
        }
    }
}