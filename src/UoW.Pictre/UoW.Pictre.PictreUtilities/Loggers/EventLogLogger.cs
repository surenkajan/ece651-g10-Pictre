using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace UoW.Pictre.PictreUtilities.Loggers
{
    public class EventLogLogger
    {
        /// <summary>
        /// Write a log entry to log file
        /// </summary>
        /// <param name="title">Log file name</param>
        /// <param name="message">Message to log</param>
        public static void WriteLog(string title, string message)
        {

            EventLog.WriteEntry(title, message);

        }

        /// <summary>
        /// Write an exception to log file
        /// </summary>
        /// <param name="title">Log file name</param>
        /// <param name="ex">Exception to log</param>
        public static void WriteException(string title, Exception ex)
        {

            string fileName = "";
            string methodName = "";
            int line = 0;
            int col = 0;

            try
            {

                //Get a StackTrace object for the exception
                StackTrace st = new StackTrace(ex, true);

                //Get the first stack frame
                StackFrame frame = st.GetFrame(0);

                //Get the file name
                fileName = frame.GetFileName();

                //Get the method name
                methodName = frame.GetMethod().Name;

                //Get the line number from the stack frame
                line = frame.GetFileLineNumber();

                //Get the column number
                col = frame.GetFileColumnNumber();


            }

            catch (Exception)
            {
            }


            EventLog.WriteEntry(title, string.Format(@"
                                            Message : {0}
                                            StackTrace : {1}
                                            TargetSite : {2}
                                            Data : {3}
                                            fileName : {4}
                                            methodName : {5}
                                            line : {6}
                                            col : {7}
                                            ", ex.Message, ex.StackTrace, ex.TargetSite, ex.Data, fileName, methodName, line, col));

        }

        /// <summary>
        /// Write an exception to log file
        /// </summary>
        /// <param name="title">Log file name</param>
        /// <param name="ex">Exception to log</param>
        /// <param name="extraInfo"></param>
        public static void WriteException(string title, Exception ex, string extraInfo)
        {
            string fileName = "";
            string methodName = "";
            int line = 0;
            int col = 0;

            try
            {

                //Get a StackTrace object for the exception
                StackTrace st = new StackTrace(ex, true);

                //Get the first stack frame
                StackFrame frame = st.GetFrame(0);

                //Get the file name
                fileName = frame.GetFileName();

                //Get the method name
                methodName = frame.GetMethod().Name;

                //Get the line number from the stack frame
                line = frame.GetFileLineNumber();

                //Get the column number
                col = frame.GetFileColumnNumber();

            }
            catch (Exception)
            {
            }


            EventLog.WriteEntry(title, string.Format(@"
                                        Message : {0}
                                        StackTrace : {1}
                                        TargetSite : {2}
                                        Data : {3}
                                        fileName : {4}
                                        methodName : {5}
                                        line : {6}
                                        col : {7}
                                        " + extraInfo, ex.Message, ex.StackTrace, ex.TargetSite, ex.Data, fileName, methodName, line, col));
        }
    }
}
