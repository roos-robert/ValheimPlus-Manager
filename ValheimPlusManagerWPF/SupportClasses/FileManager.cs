using System;

namespace ValheimPlusManager.SupportClasses
{
    public sealed class FileManager
    {
        public static bool CopyFromTo(string fromPath, string toPath)
        {
            // Create subdirectory structure in destination    
            foreach (string dir in System.IO.Directory.GetDirectories(fromPath, "*", System.IO.SearchOption.AllDirectories))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(toPath, dir.Substring(fromPath.Length + 1)));
            }

            // Copying files from ValheimPlus package to server directory
            foreach (string file_name in System.IO.Directory.GetFiles(fromPath, "*", System.IO.SearchOption.AllDirectories))
            {
                System.IO.File.Copy(file_name, System.IO.Path.Combine(toPath, file_name.Substring(fromPath.Length + 1)), true);
            }

            return true;
        }

        public static bool OldConfigBackup(string installationPath)
        {
            System.IO.File.Exists(String.Format("{0}{1}", installationPath, "BepInEx/config/valheim_plus.cfg"));

            return true;
        }

        private FileManager()
        {
        }
        private static FileManager instance = null;
        public static FileManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FileManager();
                }
                return instance;
            }
        }
    }
}
