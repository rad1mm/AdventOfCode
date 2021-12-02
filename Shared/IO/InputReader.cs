using System.Collections.Generic;
using System.IO;

namespace Shared.IO
{
    public static class InputReader
    {

        public static string[] Read(string pathToFile)
        {
            List<string> inputList = new List<string>();
            using (StreamReader reader = new StreamReader(pathToFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    inputList.Add(line);
                }
            }

            return inputList.ToArray();
        }
    }
}
