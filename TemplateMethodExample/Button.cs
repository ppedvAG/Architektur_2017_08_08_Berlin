using System;

namespace TemplateMethodExample
{
    public class Button : UiElement
    {
        protected override void ZeichneInhalt()
        {
            Console.WriteLine("Zeichne Button Inhalt.");
        }

        // Hook
        protected override void ZeichneSchatten()
        {
            Console.WriteLine("Zeichne Button Schatten.");
        }
    }
}
