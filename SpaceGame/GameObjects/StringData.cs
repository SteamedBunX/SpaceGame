using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class StringData
    {
        public List<DataString> gameTexts;

        public StringData(string path)
        {
            LoadStringData(path);
        }

        public void LoadStringData(string path)
        {
            StreamReader sr = new StreamReader(path);


            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                int index = int.Parse(line.Substring(0, 6));
                string content = line.Substring(8, line.Count() - 8);
                gameTexts.Add(new DataString(index, content));
            }
        }

        public string GetString(int index)
        {
            var content = gameTexts.FirstOrDefault(o => o.index == index);
            return content.text;

        }
    }


}
