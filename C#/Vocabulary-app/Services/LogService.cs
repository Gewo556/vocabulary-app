using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vocabulary_app.Services
{
    public static class LogService
    {
        private static string path = "logs.txt";
        public static void AddToLogs(string logText)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                // Zapisz log w pliku
                writer.WriteLine(DateTime.Now.ToString() + " - " + logText);
            }

        }
    }
}
