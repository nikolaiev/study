using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyControl
{
    public class MyEventArgs : EventArgs
    {
        private readonly bool rnd;
        // Метод доступу
        public bool Rnd { get { return rnd; } }
        // Конструктор
        public MyEventArgs(bool round) { rnd = round; }
    }
}
