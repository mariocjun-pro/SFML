using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SFML
{
    static class Program
    {
        static void Main()
        {
            Console.WriteLine("Press ESC key to close window");
            MyWindow window = new MyWindow();
            window.Show();
            Console.WriteLine("All done");
        }
    }

    class MyWindow
    {
        public void Show()
        {
            VideoMode mode = new VideoMode(800, 600);
            RenderWindow window = new RenderWindow(mode, "Tio Biko Survivors!");

            window.Closed += (_, _) => { window.Close(); };
            window.KeyPressed +=
                (sender, e) =>
                {
                    Window.Window window1 = (Window.Window)sender!;
                    if (e.Code == Keyboard.Key.Escape)
                    {
                        window1.Close();
                    }
                };

            Font font = new Font("/home/mariocj/Projects/SFML/font/Roboto-Bold.ttf");
            Text text = new Text("To Be Cool Survivors!", font);
            text.CharacterSize = 40;
            float textWidth = text.GetLocalBounds().Width;
            float textHeight = text.GetLocalBounds().Height;
            float xOffset = text.GetLocalBounds().Left;
            float yOffset = text.GetLocalBounds().Top;
            text.Origin = new Vector2f(textWidth / 2f + xOffset, textHeight / 2f + yOffset);
            text.Position = new Vector2f(window.Size.X / 2f, window.Size.Y / 2f);

            Clock clock = new Clock();
            float angle = 0f;
            float angleSpeed = 90f;
            
            while (window.IsOpen)
            {
                var delta = clock.Restart().AsSeconds();
                angle += angleSpeed * delta;
                window.DispatchEvents();
                window.Clear();
                text.Rotation = angle;
                window.Draw(text);
                window.Display();
            }
        }
    }
}