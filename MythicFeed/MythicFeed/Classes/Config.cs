﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TweetSharp;

namespace MythicFeed
{
    internal static class Config //I have so many FUCKING singletons
    {
        internal static string ConsumerKey;
        internal static string ConsumerSecret;
        internal static string LogPath;

        internal static void InitConfig()
        {
#if DEBUG
            if (!File.Exists("Config.ini"))
            {
                using (StreamWriter sw = new StreamWriter("Config.ini"))
                {
                    sw.WriteLine("[Auth]");
                    sw.WriteLine("ConsumerKey = 123456789");
                    sw.WriteLine("ConsumerSecret = 123456789");
                    sw.WriteLine();

                    sw.WriteLine("[FileSystem]");
                    sw.WriteLine("LogPath = C:/Program Files (x86)/World of Warcraft/Logs/WoWCombatLog.txt");
                }
                Console.WriteLine("You do not have your configuration set up yet! Please fill out Config.ini before continuing.");
                Console.ReadKey();
                Environment.Exit(0);
            }

            using (StreamReader sr = new StreamReader("Config.ini"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    switch (line.Split(' ')[0])
                    {
                        case "consumerKey":
                            ConsumerKey = line.Split(' ')[2];
                            break;
                        case "consumerSecret":
                            ConsumerSecret = line.Split(' ')[2];
                            break;
                        case "LogPath":
                            LogPath = line.Split(' ')[2];
                            break;
                    }

                }
            }

#else
            ConsumerKey = "lolno";
            ConsumerSecret = "nope";
#endif
        }
    }
}
