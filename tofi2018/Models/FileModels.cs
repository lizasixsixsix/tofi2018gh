using System.Collections.Generic;
using System.IO;
using System.Linq;
using tofi2018.DAL;

namespace tofi2018.Models
{
    public class FileUploadModel
    {
    }

    public class DocsUploadModel
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
                string dirUserName = string.Empty;

                var currDirName = new DirectoryInfo(dir).Name;

                using (var context = new CreditContext())
                {
                    dirUserName = context.Credits.Where(
                        c => c.DocsFolder == currDirName).First().UserName;
                }

                this.Folders.Add(dirUserName, new List<string>());

                foreach (string subdir in Directory.GetDirectories(
                         dir, "*", SearchOption.TopDirectoryOnly))
                {

                    foreach (string file in Directory.GetFiles(
                                 subdir, "*", SearchOption.AllDirectories))
                    {
                        this.Folders[dirUserName].Add(file);
                    }
                }
            }
        }
    }
}
