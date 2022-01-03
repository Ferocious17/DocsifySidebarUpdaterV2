using System;
using System.IO;

namespace DocsifySidebarUpdaterV2
{
    public class Updater
    {
        public string Folderpath { get; set; }
        public int Week { get; set; }

        public Updater(string folderpath, int week)
        {
            Folderpath = folderpath;
            Week = week;
        }

        public void Update()
        {
            if (!Directory.Exists(Folderpath))
                throw new DirectoryNotFoundException("Could not find specified directory!");

            if (Folderpath.EndsWith(Path.DirectorySeparatorChar))
                Folderpath = Folderpath.Substring(0, Folderpath.Length - 1);

            _update(Folderpath);
        }

        private void _update(string path)
        {
            string sidebarPath = path + Path.DirectorySeparatorChar + "_sidebar.md";

            if (File.Exists(sidebarPath))
            {
                string[] lines = File.ReadAllLines(sidebarPath);
                lines[lines.Length - 3] = $"{lines[lines.Length - 3]}{Environment.NewLine}    * [Woche {Week}](Wochen/Woche{Week}/)";
                File.WriteAllLines(sidebarPath, lines);
            }

            foreach (var subDir in Directory.GetDirectories(path))
                _update(subDir);
        }
    }
}
