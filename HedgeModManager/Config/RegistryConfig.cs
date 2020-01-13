﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HedgeModManager
{
    public static class RegistryConfig
    {
        private const string ConfigPath = @"SOFTWARE\HEDGEMM";

        public static string LastGameDirectory;
        
        static RegistryConfig()
        {
            Load();
        }

        public static void Save()
        {
            var key = Registry.CurrentUser.CreateSubKey(ConfigPath);
            key.SetValue("LastGame", LastGameDirectory);
            key.Close();
        }

        public static void Load()
        {
            var key = Registry.CurrentUser.CreateSubKey(ConfigPath);
            LastGameDirectory = (string)key.GetValue("LastGame", string.Empty);
        }
    }
}
