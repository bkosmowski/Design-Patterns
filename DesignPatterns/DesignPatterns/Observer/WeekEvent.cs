using System;

namespace DesignPatterns.Observer
{
    public class Button
    {
        public event EventHandler Clicked;

        public void Fire()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Window
    {

        public Window(Button button)
        {
            button.Clicked += Button_Clicked;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Button clicked! - Window");
        }

        ~Window()
        {
            Console.WriteLine("Finalizer from window called");
        }
    }

    public class WeekEvent
    {
        public void Demo()
        {
            var button = new Button();
            var window = new Window(button);

            button.Fire();
            window = null;

            FireGC();
        }

        private void FireGC()
        {
            Console.WriteLine("GC is starting");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            Console.WriteLine("GC is done");
        }
    }
}
