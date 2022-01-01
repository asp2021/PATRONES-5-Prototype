using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Console;

namespace Prototype
{
    public static class ExtensionsMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            object copy = formatter.Deserialize(stream);
            stream.Close();
            return (T)copy;
        }
    }

    [Serializable]
    public class Product
    { 
        public string Name { get; set; }
        public Category Category { get; set; }

        public Product(string name, Category category)
        {
            Name = name;
            Category = category;
        }

        public override string ToString()
        {
            return $"Producto: {Name}, Categoría: {Category.Name}";
        }


    }

    [Serializable]
    public class Category
    {
        public string Name { get; set; }

        public Category(string name)
        {
            Name = name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("PROTOTYPE" + '\n');
            WriteLine("Su funcion principal es copiar objetos existentes. Es comunmente utilizado en objetos que requieren un proceso de creacion complejo." + '\n');
            WriteLine("Deep copy -  Shallow copy - ExtensionsMethods - Serializable" + Environment.NewLine);

            var notebook1 = new Product("Hp Probook", new Category("Notebooks"));
            var cellphone = notebook1.DeepCopy();
            cellphone.Category.Name = "CellPhone";
            cellphone.Name = "Iphone";

            WriteLine(notebook1);
            WriteLine(cellphone);
            ReadLine();
            
        }
    }
}
