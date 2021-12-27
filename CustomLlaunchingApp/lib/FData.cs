using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLlaunchingApp.lib
{
    public class FData
    {
        List<string> data = new List<string>();
        public void add(string name, string path, string path_ico)
            => data.Add($"\"{name}\":\"{path}\":\"{path_ico}\"");
        public void save(string path_file)
            => File.WriteAllText(path_file, string.Join("\n", data));
        public void open(string path_file)
        {
            if (!File.Exists(path_file))
                return;
            string[] lines_ = File.ReadAllLines(path_file);
            data.Clear();
            foreach (string line in lines_)
            {
                data.Add(line);
            }
        }
           
    }
}
