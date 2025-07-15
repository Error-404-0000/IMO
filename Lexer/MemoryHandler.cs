namespace Lexer
{
    // MemoryHandler keeps track of allocated variables in SimpleScript. It can
    // watch memory changes during execution and roll them back if needed.
    public static unsafe class MemoryHandler
    {

        public static Dictionary<string, dynamic> Memorys = [];
        private static readonly object obj = new();
        public static bool StopWatcher;
        private static List<string>? keys;
        // Begin monitoring the dictionary for new entries. Any variables added
        // while the watcher is active can later be removed via
        // `RemoveLastChangesFromMemory`.
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
        // Stop the watcher started with `WatchForChanges`.
        public static void StopWatching()
        {
            lock (obj)
            {
                StopWatcher = true;
            }
        }
        // Remove variables that were captured by the watcher since the last
        // call to `WatchForChanges`. Throws if the watcher is still running.
        // Undo any variable declarations that occurred while the watcher was
        // active. This is primarily used when evaluating conditional blocks so
        // that temporary variables do not leak into the outer scope.
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
