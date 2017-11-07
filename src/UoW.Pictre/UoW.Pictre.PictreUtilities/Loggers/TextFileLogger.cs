using System;
using System.Diagnostics;
using System.IO;

namespace UoW.Pictre.PictreUtilities.Loggers
{
    /// <summary>
    /// This will log wanted text to the path of "c:\logs\[title]
    /// </summary>
    public class TextFileLogger
    {
        /// <summary>
        /// Write a log entry to log file
        /// </summary>
        /// <param name="title">Log file name</param>
        /// <param name="message">Message to log</param>
        public static void WriteLog(string title, string message)
        {
            try
            {
                if (!Directory.Exists(@"c:\logs\"))
                    Directory.CreateDirectory(@"c:\logs\");

                StreamWriter sw = new StreamWriter(@"c:\logs\" + title + ".log", true);
                sw.WriteLine(DateTime.Now.ToString() + " : " + message);
                sw.Flush();
                sw.Close();
            }
            catch (Exception)
            {
            }

        }

        /// <summary>
        /// Write an exception to log file
        /// </summary>
        /// <param name="title">Log file name</param>
        /// <param name="ex">Exception to log</param>
        public static void WriteException(string title, Exception ex)
        {
            WriteLog(title, "---------------------------------------------------------------------------------------");
            WriteLog(title, "Exception Occurred");
            WriteLog(title, "Message : " + ex.Message);
            WriteLog(title, "StackTrace : " + ex.StackTrace);
            WriteLog(title, "TargetSite : " + ex.TargetSite);
            WriteLog(title, "Data : " + ex.Data);
            try
            {
                //Get a StackTrace object for the exception
                StackTrace st = new StackTrace(ex, true);

                //Get the first stack frame
                StackFrame frame = st.GetFrame(0);

                //Get the file name
                string fileName = frame.GetFileName();

                //Get the method name
                string methodName = frame.GetMethod().Name;

                //Get the line number from the stack frame
                int line = frame.GetFileLineNumber();

                //Get the column number
                int col = frame.GetFileColumnNumber();

                WriteLog(title, "fileName : " + fileName);
                WriteLog(title, "methodName : " + methodName);
                WriteLog(title, "line : " + line);
                WriteLog(title, "col : " + col);
            }
            catch (Exception)
            {
            }
            WriteLog(title, "---------------------------------------------------------------------------------------");
        }
    }
}