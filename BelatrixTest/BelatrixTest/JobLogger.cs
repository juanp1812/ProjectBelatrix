using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BelatrixTest
{
    public class JobLogger
    {
        public string SetLog(string message, TypeMessage typeMessage, List<Source> lstSource)
        {

            var lstErrors = new List<string>();
            var flg = false;
            if (string.IsNullOrEmpty(message))
            {
                return "A message must be specified";
            }

            if(!lstSource.Any())
            {
                return "Invalid configuration";
            }

            if (lstSource.Contains(Source.Console))
            {
                SetColor(typeMessage);
                Console.WriteLine(Log(message, typeMessage));
                flg = true;
            }
            if (lstSource.Contains(Source.Database))
            {
                var log = new LogDatabase();
                flg =  log.AddLogDataBase(message, typeMessage);
                if (flg == false) lstErrors.Add("An error has occurred saving to the database");
            }
            if (lstSource.Contains(Source.File))
            {
                flg = SetLogFile(message, typeMessage);
                if (flg == false) lstErrors.Add("An error has occurred saving the file.");
            }
            return string.Join("." + Environment.NewLine, lstErrors.ToArray());
        }

        private static string Log(string message, TypeMessage type)
        {
            return Date() + " - (" + type.ToString().ToUpper() + "): " + message;
        }

        private static string Date()
        {
            return DateTime.Now.ToShortDateString();
        }

        private static void SetColor(TypeMessage typeMessage)
        {
            switch (typeMessage)
            {
                case TypeMessage.Info:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case TypeMessage.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case TypeMessage.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
        }

        private bool SetLogFile(string message, TypeMessage type)
        {
            try
            {
                string path = System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + Date().Replace("/", "-") + ".txt";
                File.AppendAllText(path, Log(message + Environment.NewLine, type));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //public static void LogMessage(string message, bool resultMessage, bool resultWarning, bool resultError)
        //{
        //    message.Trim();
        //    if (message == null || message.Length == 0)
        //    {
        //        return;
        //    }
        //    if (!_logToConsole && !_logToFile && !_logToDatabase)
        //    {
        //        throw new Exception("Invalid configuration");
        //    }
        //    if ((!_logError && !_logMessage && !_logWarning) || (!resultMessage && !resultWarning && !error))
        //    {
        //        throw new Exception("Error or Warning or Message must be specified");
        //    }
        //    System.Data.SqlClient.SqlConnection connection =
        //        new System.Data.SqlClient.SqlConnection(
        //            System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
        //    connection.Open();
        //    int t = 0;
        //    if (resultMessage && _logMessage)
        //    {
        //        t = 1;
        //    }
        //    if (resultError && _logError)
        //    {
        //        t = 2;
        //    }
        //    if (resultWarning && _logWarning)
        //    {
        //        t = 3;
        //    }
        //    System.Data.SqlClient.SqlCommand command =
        //        new System.Data.SqlClient.SqlCommand("Insert into Log Values('" + message + "', " + t.ToString() + ")");
        //    command.ExecuteNonQuery();
        //    string l = null;
        //    if
        //        (
        //        !System.IO.File.Exists(System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"] +
        //                               "LogFile" + DateTime.Now.ToShortDateString() + ".txt"))
        //    {
        //        l =
        //            System.IO.File.ReadAllText(
        //                System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" +
        //                DateTime.Now.ToShortDateString() + ".txt");
        //    }
        //    if (resultError && _logError)
        //    {
        //        l = l + DateTime.Now.ToShortDateString() + message;
        //    }
        //    if (resultWarning && _logWarning)
        //    {
        //        l = l + DateTime.Now.ToShortDateString() + message;
        //    }
        //    if (resultMessage && _logMessage)
        //    {
        //        l = l + DateTime.Now.ToShortDateString() + message;
        //    }

        //    System.IO.File.WriteAllText(
        //        System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" +
        //        DateTime.Now.ToShortDateString() + ".txt", l);
        //    if (resultError && _logError)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //    }
        //    if (resultWarning && _logWarning)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Yellow;
        //    }
        //    if (resultMessage && _logMessage)
        //    {
        //        Console.ForegroundColor = ConsoleColor.White;
        //    }
        //    Console.WriteLine(DateTime.Now.ToShortDateString() + message);
        //}

    }
}
