using System;

// Simple helper library used by the sample programs. Currently exposes only a
// single `Print` method that writes to the console.

namespace testlib
{
    public static class Code
    {
        public static void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
