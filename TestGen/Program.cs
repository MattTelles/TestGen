using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGen
{
    class Program
    {
        static void Main(string[] args)
        {
            Generator realGenerator = new Generator("Real");
            Generator intGenerator = new Generator("Integer");
            Generator strGenerator = new Generator("String");

            GenType age = new GenType("age", intGenerator);
            GenType name = new GenType("name", strGenerator);
            GenType salary = new GenType("salary", realGenerator);
            GenType employee = new GenType("employee", null);
            employee.Children.Add(age);
            employee.Children.Add(name);
            employee.Children.Add(salary);
            employee.Generate();

        }
    }

    public class GenType
    {
        string name = String.Empty;
        List<GenType> children = new List<GenType>();
        Generator myGenerator;

        public List<GenType> Children
        {
            get { return children; }
        }

        public GenType(string n, Generator g)
        {
            name = n;
            myGenerator = g;
        }

        public void Generate()
        {
            System.Console.WriteLine("Generating {0}: ", name);
            if (myGenerator != null)
                myGenerator.Generate();
            foreach ( GenType g in children )
                g.Generate();
        }
    }

    public class Generator
    {
        private string genName;

        public Generator(string name)
        {
            genName = name;
        }

        public void Generate()
        {
            Console.Out.WriteLine("Generate called for {0}", genName);
        }
    }
}
