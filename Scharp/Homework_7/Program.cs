using System.Reflection;
using System.Runtime.Remoting;
using System.Text;

namespace Homework_7
{
    internal class Program
    {
        /*
         * Напишите 2 метода использующие рефлексию
1 - сохраняет информацию о классе в строку
2- позволяет восстановить класс из строки с информацией о классе
В качестве примере класса используйте класс TestClass.
        */
        static void Main(string[] args)
        {
            TestClass t = new TestClass(10, "ten", 10, new char[] { 't', 'e', 'n' });


            string InfoClassConstructor = GetInfoConstructor(t);
            string InfoClassPropetry = GetInfoPropetry(t);

            Console.WriteLine("Конструкторы:\n" + InfoClassConstructor);
            Console.WriteLine("Свойства:\n" + InfoClassPropetry);

            string InfoClass = InfoClassConstructor + InfoClassPropetry;

            Console.WriteLine("_________________________________");

            TestClass t1 = RestoreClass(InfoClass) as TestClass;

            Console.WriteLine(t1.ToString());

        }

        // Получить свойства класса
        public static string GetInfoPropetry(TestClass testClass)
        {
            StringBuilder sb = new StringBuilder();
            string s = "";
            Type type = typeof(TestClass);
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property != null)
                {
                    if (property.PropertyType == typeof(char[]))
                    {
                        char[] symbols = property.GetValue(testClass) as char[];

                        s = $"{property.Name} = ";
                        foreach (char c in symbols) { s += $"{c} "; }
                    }
                    else
                    {
                        s = $"{property.Name} = {property?.GetValue(testClass)}";
                    }
                    if (property.CanRead) { s += " (get) "; }
                    if (property.CanWrite) { s += " (set) "; }
                    sb.Append(s + "\n");
                }
            }
            return sb.ToString();
        }

        // Получить конструкторы класса
        public static string GetInfoConstructor(TestClass testClass)
        {
            Type type = typeof(TestClass);
            StringBuilder sb = new StringBuilder();
            string s = "";
            ConstructorInfo[] constructorInfos = type.GetConstructors
                (BindingFlags.Instance |
                BindingFlags.NonPublic |
                BindingFlags.Public);

            foreach (ConstructorInfo ctor in constructorInfos)
            {
                if (ctor != null)
                {
                    ParameterInfo[] parameters = ctor.GetParameters();

                    if (ctor.IsPublic) { s = $"public {type.Name} "; }
                    else if (ctor.IsPrivate) { s = $"private {type.Name} "; }

                    for (int i = 0; i < parameters.Length; i++)
                    {
                        var param = parameters[i];
                        s += $"{param.ParameterType.Name} {param.Name} ";
                    }
                    sb.Append(s + "\n");
                }
            }
            return sb.ToString();
        }

        // Получить объект из строки
        public static object? RestoreClass(string stringInfo)
        {
            string[] arrayClassInfo = stringInfo.Split(' ');
            ObjectHandle? obj = null;
            //object obj1 = null;

            foreach (string s in arrayClassInfo)
            {
                if (s == "TestClass")
                {
                    obj = Activator.CreateInstance("Homework_7", s,
                    new Object[] { 10, "ten", 10, new char[] { 't', 'e', 'n' } });
                    //obj1 = Activator.CreateInstance(typeof(TestClass));
                }
            }
            //return obj1;
            return obj?.Unwrap();
        }
    }
}
