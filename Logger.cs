using System;
using System.IO;

class Logger
{
    public static void LogYaz(string mesaj)
    {
        File.AppendAllText("log.txt",
            DateTime.Now + " - " + mesaj + Environment.NewLine);
    }
}
