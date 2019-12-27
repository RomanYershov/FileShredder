using System;
using System.IO;



namespace FShredder.Bll.Utils
{
    public class Logger
    {
        public static void Error(string message)
        {
            Write(message);
        }
        public static void Error(Exception e)
        {
            Write(e);
        }
        public static void Error(string message,Exception e)
        {
            Write(message, e);
        }
        public static void Info(string message)
        {
            Write(message);
        }





        private static void Write(string message)
        {
            WriteToFile($"[{DateTime.Now}] {message}");
            Console.WriteLine(message);
        }
        private static void Write(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        private static void Write(string message, Exception e)
        {
            Console.WriteLine(message);
        }

        private static void WriteToFile(string message)
        {
            var dateTimeNow = DateTime.Now;
           var dirLog =  System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"FileShredder.Logs");
            if (!Directory.Exists(dirLog))
            {
                Directory.CreateDirectory(dirLog);
            }
            var path = System.IO.Path.Combine(dirLog, $"Log_{dateTimeNow.Year}_{dateTimeNow.Month}.txt");
            File.AppendAllLines(path, new [] { message });
        }
    }
}
