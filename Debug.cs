using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work_Timer
{
    internal class Debug
    {
        static int nextTick = 0;
        public static void Initialization()
        {
            EventManager.on1sUpdate += On1sUpdate;
            EventManager.onStartRecording += ()=>
            {
                var record = DateTime.Now.ToString() + "     Watch Start: " + WTimer.WorkTimeToday.ToString();
                Record(record);
            };
            EventManager.onStopRecording += ()=>
            {
                var record = DateTime.Now.ToString() + "     Watch Pause: " + WTimer.WorkTimeToday.ToString();
                Record(record);
            };
            EventManager.onEndTimerStart += () =>
            {
                Record(DateTime.Now.ToString() + "     End Timer Start");
            };
            EventManager.onStopRecording += () =>
            {
                Record(DateTime.Now.ToString() + "     End Timer Stop");
            };
            EventManager.onSaving += () =>
            {
                Record(DateTime.Now.ToString() + "     Before Saving: Today's Work Time: " + WTimer.WorkTimeToday.ToString() + "        Total Timer: " + WTimer.TotalTime.ToString());
            };
            EventManager.onSaved+=() =>
            {
                Record(DateTime.Now.ToString() + "     After Saving: Today's Work Time: " + WTimer.WorkTimeToday.ToString() + "        Total Timer: " + WTimer.TotalTime.ToString());
            };
        }

        static void On1sUpdate(int ticks)
        {
            if (ticks < nextTick)
                return;

            EventManager.onKeyPress.Invoke();
            int addition = new Random().Next(900);
            Record(DateTime.Now.ToString() + "     Key pressed: tick = " + ticks + ", Next tick = " + (ticks + addition));
            nextTick = ticks + addition;
        }
        public static void Record(string text)
        {
                try
                {
                    // 获取当前可执行文件所在目录
                    string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

                    // 创建文件夹（如果不存在）
                    string fullPath = Path.Combine(currentDirectory, DataPersistence.relativePath);
                    Directory.CreateDirectory(fullPath);

                    var filePath = Path.Combine(fullPath, "Debug Track");

                    if (!File.Exists(filePath))
                        File.Create(filePath).Close();

                    var allText = File.ReadAllLines(filePath).ToList();
                    allText.Add(text);
                    File.WriteAllLines(filePath, allText.ToArray());

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }


        }
    }
}
