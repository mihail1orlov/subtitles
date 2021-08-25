using System;
using System.Threading;

namespace SubtitlesApp
{
    internal class Tupilka : IDisposable
    {
        private bool _process;
        private const int Timeout = 400;
        private bool _pause;

        public void Start()
        {
            _process = true;
            var thread = new Thread(() =>
            {
                Thread.Sleep(Timeout);
                var symbols = new[] {"-", "\\", "|", "/"};
                for (var i = 0; _process; i++)
                {
                    if (_pause)
                    {
                        Console.CursorVisible = true;
                        Thread.Sleep(Timeout);
                        continue;
                    }

                    Console.CursorVisible = false;

                    var color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(symbols[i % symbols.Length]);
                    Console.ForegroundColor = color;
                    
                    Thread.Sleep(Timeout);

                    //Console.Write("\b");
                    if (Console.CursorTop > 0)
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    }
                }

                Console.CursorVisible = true;
            });
            thread.Start();
        }

        public void Pause()
        {
            _pause = true;
        }

        public void UnPause()
        {
            _pause = false;
        }

        public void End()
        {
            _process = false;
        }

        public void Dispose()
        {
            End();
        }
    }
}