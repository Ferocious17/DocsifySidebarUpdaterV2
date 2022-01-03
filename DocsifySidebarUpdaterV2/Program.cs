using System;

namespace DocsifySidebarUpdaterV2
{
    class Program
    {
        static void Main(string[] args)
        {
            Updater updater = new Updater(@"C:\M133\m133_lernportfolio-Ferocious17\docs\Wochen", 16);
            updater.Update();

            Console.WriteLine("Done.");
        }
    }
}
