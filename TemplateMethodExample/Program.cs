using System;

namespace TemplateMethodExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var window = new Window();

            window.Children.Add(new Button());
            window.Children.Add(new Button());
            window.Children.Add(new Button());

            window.Zeichnen();

            Console.ReadKey();
        }
    }
}
