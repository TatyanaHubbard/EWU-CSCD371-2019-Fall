﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Configuration
{
    public class FileConfig
    {
        private string fileConfigPath;
        public FileConfig()
        {
            this.fileConfigPath = Path.GetFullPath("config.settings");
        }

        public FileConfig(string filePath)
        {
            this.fileConfigPath = filePath;
        }
        public List<String> ReadConfig()
        {
            string[] lines = File.ReadAllLines(this.fileConfigPath);
            List<String> configLines = new List<String>();

            foreach(string line in lines)
            {
                if(line.Split("=").Length != 2)
                {
                    throw new ArgumentException("Too many arguments on one line");
                }

                configLines.Add(line);
            }

            return configLines;
        }

        public void WriteConfig(string name, string? value)
        {
            if(IsValidInput(name, value))
            {
                using (StreamWriter sr = new StreamWriter(this.fileConfigPath))
                {
                    sr.WriteLine($"{name}={value}");
                }
            }

        }

        public static bool IsValidInput(string name, string? value)
        {
            if(string.IsNullOrEmpty(name) || name.Contains(' ') || name.Contains('='))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(value) || value.Contains(' ') || value.Contains('='))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
