using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace CodeLibrary
{
    public static partial class Lib
    {
        public static TimeSpan RunTimer(Action somethingToDo)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            somethingToDo();
            stopWatch.Stop();
            return stopWatch.Elapsed;
        }
    }
}
