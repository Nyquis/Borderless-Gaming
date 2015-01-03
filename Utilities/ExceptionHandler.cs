﻿using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace BorderlessGaming.Utilities
{
    public static class ExceptionHandler
    {
        public static void AddGlobalHandlers()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                try
                {
                    Directory.CreateDirectory("./Logs");

                    string filePath = string.Format("Logs/UnhandledException{0}.json", DateTime.Now.ToShortDateString().Replace("/", "-"));

                    File.WriteAllText("./" + filePath, JsonConvert.SerializeObject(args.ExceptionObject, Formatting.Indented));

                    MessageBox.Show(string.Format("An Unhandled Exception was Caught and Logged to:\r\n{0}", filePath),
                        "Exception Caught", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch { }
            };


            Application.ThreadException += (sender, args) =>
            {
                try
                {
                    Directory.CreateDirectory("./Logs");
                
                    string filePath = string.Format("Logs/ThreadException{0}.json", DateTime.Now.ToShortDateString().Replace("/", "-"));

                    File.WriteAllText("./" + filePath, JsonConvert.SerializeObject(args.Exception, Formatting.Indented));

                    MessageBox.Show(string.Format("An Unhandled Thread Exception was Caught and Logged to:\r\n{0}", filePath),
                        "Thread Exception Caught", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
                catch { }
           };
        }
    }
}