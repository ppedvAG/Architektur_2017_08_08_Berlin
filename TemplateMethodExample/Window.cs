using System;

namespace TemplateMethodExample
{
    public class Window : UiElement
    {
        protected override void ZeichneInhalt()
        {
            Console.WriteLine("Zeichne Window Inhalt.");
        }

        protected override void ZeichneRahmen()
        {
            Console.WriteLine("Zeichne Window Rahmen.");
        }
    }
}
