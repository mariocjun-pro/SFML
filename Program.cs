using System;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace RotatingHelloWorldSfmlDotNetCoreCSharp
{
    class Program
    {
        static void Main(string[] args)
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
            VideoMode mode = new VideoMode(250, 250);
            RenderWindow window = new RenderWindow(mode, "SFML.NET");

            window.Closed += (obj, e) => { window.Close(); };
            window.KeyPressed +=
                (sender, e) =>
                {
                    Window window = (Window)sender;
                    if (e.Code == Keyboard.Key.Escape)
                    {
                        window.Close();
                    }
                };

            Font font = new Font("font/Roboto-Bold.ttf");
            Text text = new Text("Hello World!", font);
            text.CharacterSize = 40;
            float textWidth = text.GetLocalBounds().Width;
            float textHeight = text.GetLocalBounds().Height;
            float xOffset = text.GetLocalBounds().Left;
            float yOffset = text.GetLocalBounds().Top;
            text.Origin = new Vector2f(textWidth / 2f + xOffset, textHeight / 2f + yOffset);
            text.Position = new Vector2f(window.Size.X / 2f, window.Size.Y / 2f);

            Clock clock = new Clock();
            float delta = 0f;
            float angle = 0f;
            float angleSpeed = 90f;
            
            while (window.IsOpen)
            {
                delta = clock.Restart().AsSeconds();
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