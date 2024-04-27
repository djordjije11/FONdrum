using System.Reflection;
using System.Text;

namespace FONdrum.Seeding.Helper
{
    public class CsvDeserializer
    {
        /// <summary>
        /// Reads objects from csv file and returns them mapped.
        /// All values are mapped to object's PROPERTIES (not fields).
        /// </summary>
        /// <typeparam name="T">type of objects to read</typeparam>
        /// <param name="filePath">An absolute path to a csv file.</param>
        /// <returns>List of objects mapped from csv file.</returns>
        public List<T> Read<T>(string filePath) where T : class
        {
            var objs = new List<T>();
            using (StreamReader file = new StreamReader(filePath, encoding: Encoding.Unicode))
            {
                string[]? propertyNames = file.ReadLine()?.Split(',');
                if (propertyNames == null)
                {
                    file.Close();
                    return [];
                }

                string? line;
                while ((line = file.ReadLine()) != null)
                {
                    T obj = MapLine<T>(line, propertyNames);
                    objs.Add(obj);
                }

                file.Close();
            }
            return objs;
        }

        private static T MapLine<T>(string line, string[] propertyNames) where T : class
        {
            T obj = Activator.CreateInstance(typeof(T), true) as T
                        ?? throw new Exception("Creating an instance of specified type not successful");

            string[] propertyValues = line.Split(',');

            for (int i = 0; i < propertyNames.Length; i++)
            {
                PropertyInfo propertyInfo = obj.GetType().GetProperty(propertyNames[i])
                    ?? throw new Exception($"The specified type doesn't have field {propertyNames[i]}.");
                
                object convertedValue = Convert.ChangeType(propertyValues[i], propertyInfo.PropertyType);
                propertyInfo.SetValue(obj, convertedValue);
            }

            return obj;
        }
    }
}
