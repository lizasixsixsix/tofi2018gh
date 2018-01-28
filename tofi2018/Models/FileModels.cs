using System.Collections.Generic;
using System.IO;

namespace tofi2018.Models
{
    public class FileUploadModel
    {
    }

    public class DirectoryModel
    {
        public string Parent { get; private set; }

        public Dictionary<string, List<string>> Folders { get; private set; }

        public DirectoryModel(string parent)
        {
            this.Parent = parent;

            this.Folders = new Dictionary<string, List<string>>();

            foreach (string dir in Directory.GetDirectories(
                         parent, "*", SearchOption.TopDirectoryOnly))
            {
                if (Directory.GetFiles(dir, "*").Length > 0)
                {
                    this.Folders.Add(dir, new List<string>());

                    foreach (string file in Directory.GetFiles(
                                 dir, "*", SearchOption.AllDirectories))
                    {
                        this.Folders[dir].Add(file);
                    }
                }
            }
        }
    }
}
