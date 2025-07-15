namespace Lexer
{
    public static unsafe class MemoryHandler
    {
        // Stores all variables created during script execution. Provides
        // optional watcher logic that can revert changes when an operation
        // fails or is rolled back.

        public static Dictionary<string, dynamic> Memorys = [];
        private static readonly object obj = new();
        public static bool StopWatcher;
        private static List<string>? keys;
        public static void WatchForChanges()
        {
            StopWatcher = false;
            keys = [];
            int lastCount = Memorys.Count;
            new Thread(() =>
            {
                while (!StopWatcher)
                {
                    if (Memorys.Count > lastCount)
                    {
                        keys.Add(Memorys.ToList().Last().Key);
                        lastCount = Memorys.Count;
                    }
                }
            }).Start();
        }
        public static void StopWatching()
        {
            lock (obj)
            {
                StopWatcher = true;
            }
        }
        public static void RemoveLastChangesFromMemory()
        {
            if (!StopWatcher)
            {
                throw new Exception("Watcher must be stopped first");
            }
            else
            {

                foreach (string key in keys)
                {
                    if (Memorys.ContainsKey(key))
                    {
                        _ = Memorys.Remove(key);
                    }
                }


            }
        }

    }
}
