using System.Reflection;

namespace Reflection
{
    public class Program
    {
        static void CreateInstance()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyTypes = assembly.GetTypes();

            foreach (var type in assemblyTypes)
            {
                if (type == typeof(Student))
                {
                    var instanceOfStudent = (Student)Activator.CreateInstance(type)!;

                    foreach (var property in instanceOfStudent!.GetType().GetProperties())
                    {
                        Console.Write($"{property.Name}: ");
                        string? value = Console.ReadLine();

                        Type propertyType = property.PropertyType;
                        property.SetValue(instanceOfStudent, Convert.ChangeType(value, propertyType), null);
                    }

                    Console.WriteLine();

                    instanceOfStudent.DisplayInfo();
                }
            }
        }

        static void DisplayPublicProperties()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var assemblyTypes = assembly.GetTypes();

            foreach (var type in assemblyTypes)
            {
                if (type == typeof(Student))
                {
                    foreach (var property in typeof(Student).GetProperties())
                        Console.WriteLine(property.Name);
                }
            }
        }

        public static void Main()
        {
            CreateInstance();

            Console.WriteLine();

            DisplayPublicProperties();            
        }
    }
}