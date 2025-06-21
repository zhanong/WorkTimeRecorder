using System;
using System.IO;

namespace Work_Timer
{
    internal class DataPersistence
    {
        public readonly static string relativePath = "TimeData";
        static string dayDataFile = "DayData.txt";
        static string weekDataFile = "WeekData.txt";
        static string keyWordFile = "KeyWord.txt";
        public static void WriteText(string[] dayData, string[] weekData)
        {
            if (!GetPath(dayDataFile, out string dayPath) | !GetPath(weekDataFile, out string weekPath))
                return;

            File.WriteAllLines(dayPath, dayData);
            File.WriteAllLines(weekPath, weekData);
        }

        public static void SaveKeyWord(string[] keyWords)
        {
            if (!GetPath(keyWordFile, out string filePath))
                throw new Exception(" Failed to Create File");
            File.WriteAllLines(filePath, keyWords);
        }

        public static string[] LoadKeyWord()
        {
            if (!GetPath(keyWordFile, out string filePath))
                throw new Exception(" Failed to Create File");
            return File.ReadAllLines(filePath);
        }

        public static bool GetData(out string[] dayData, out string[] weekData)
        {
            if (GetPath(dayDataFile, out string dayPath) & GetPath(weekDataFile, out string weekPath))
            {
                dayData = File.ReadAllLines(dayPath);
                weekData = File.ReadAllLines(weekPath);
                return true;
            }
            dayData = null;
            weekData = null;
            return false;
        }

        public static bool GetPath(string fileName, out string filePath)
        {
            try
            {
                // 获取当前可执行文件所在目录
                string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

                // 创建文件夹（如果不存在）
                string fullPath = Path.Combine(currentDirectory, relativePath);
                Directory.CreateDirectory(fullPath);

                filePath = Path.Combine(fullPath, fileName);

                if (!File.Exists(filePath))
                    File.Create(filePath).Close();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                filePath = default;
                return false;
            }

        }
    }
}
