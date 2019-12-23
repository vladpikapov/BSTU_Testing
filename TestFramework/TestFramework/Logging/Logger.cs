﻿using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Logging
{
    class Logger
    {
        private static ILog log = LogManager.GetLogger("LOG");
        public static ILog Log
        {
            get { return log; }
        }
        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }
    }
}
