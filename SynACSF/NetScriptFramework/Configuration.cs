
using System.Collections.Generic;
using System.IO;

namespace SynACSF.NetScriptFramework
{
    public class ConfigFile
    {
        public ConfigFile(string Path)
        {
            this.Path = Path;
        }
        public string Path;
        public void Load() {
            foreach(var line in File.ReadAllLines(this.Path)) {
                string kwd = "";
                string entry = "";
                var vline = line.Trim();
                vline = vline.Replace(",", "");
                vline = vline.Replace("\"", "");
                vline = vline.Trim();
                if (vline.Length == 0) {
                    continue;
                }
                if(vline.StartsWith("#")) {
                    continue;
                }
                for(int i = 0; i<vline.Length; i++) {
                    if(char.IsWhiteSpace(vline[i])) {
                        kwd = vline.Substring(0,i);
                        vline = vline.Substring(i).Trim();
                        break;
                    }
                }
                vline = vline.Substring(1).Trim();
                entry = vline;
                Entries[kwd ?? ""] = entry;
            }
        }
        public Dictionary<string, string> Entries = new Dictionary<string, string>();
    }
}