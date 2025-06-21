using System;
using System.Diagnostics;

namespace Work_Timer
{
    internal class WTimer
    {
        public static TimeSpan TotalTime => totalWatch.Elapsed + addedTime;
        public static TimeSpan WorkTimeToday => DataProcesser.LastSavedThisDayTime + TotalTime;
        public static DateTime Today { get; private set; }
        public static TimeSpan AverageTimeOfWeek { get
            {
                int dayNum = (int)DateTime.Today.DayOfWeek;
                if (dayNum == 0 || dayNum == 6)
                    dayNum = 5;
                TimeSpan WeekTime = DataProcesser.LastSavedThisWeekTime + TotalTime;
                return TimeSpan.FromMinutes(WeekTime.TotalMinutes / dayNum);
            } }

        // 计时器
        static Stopwatch endWatch = new Stopwatch();
        static Stopwatch totalWatch = new Stopwatch();
        static TimeSpan addedTime;
        public static bool Present { get; set; }

        public static  void Initialization()
        {
            EventManager.onKeyPress += SetPresent;
            EventManager.onMouseClicked += SetPresent;
            EventManager.on1sUpdate += On1sUpdate;
            Today = DateTime.Today;
        }

        static void On1sUpdate(int num)
        {
            CheckDayEnd();
            if (num % 10 == 0)
                CheckWorking();
        }

        public static void CleanTotalTime()
        {
            addedTime = TimeSpan.Zero;
            if (totalWatch.IsRunning)
                totalWatch.Restart();
            else
                totalWatch.Reset();
        }

        static void SetPresent()
        {
            Present = true;
        }

        public static void CheckWorking()
        {
            if (CurrentWindow.IsValidWindow() && Present)
            {
                if (endWatch.IsRunning)
                {
                    endWatch.Reset();
                    EventManager.onEndTimerStop.Invoke();
                }
                if (!totalWatch.IsRunning)
                {
                    totalWatch.Start();
                    EventManager.onStartRecording.Invoke();
                }
            }
            else
            {
                if (!totalWatch.IsRunning)
                    return;
                if (!endWatch.IsRunning)
                {
                    endWatch.Start();
                    EventManager.onEndTimerStart.Invoke();
                }
                if (endWatch.Elapsed.TotalMinutes >= 10)
                {
                    endWatch.Reset(); 
                    totalWatch.Stop();
                    EventManager.onStopRecording.Invoke();
                    EventManager.onEndTimerStop.Invoke();
                }
            }

            Present = false;
        }

        static void CheckDayEnd()
        {
            if (Today != DateTime.Today || DateTime.Now.TimeOfDay < new TimeSpan(23, 59, 55))
                return;

            EventManager.onDayEnding.Invoke();
            Today = DateTime.Today.AddDays(1);
            EventManager.onDayStarted.Invoke();

            if (Today.DayOfWeek == DayOfWeek.Monday)
                EventManager.onWeekStarted.Invoke();
        }

        public static void AddMinutes(int minutes)
        {
            var todayTime = TotalTime + DataProcesser.LastSavedThisDayTime;
            var addingTime = TimeSpan.FromMinutes(minutes);
            if (todayTime + addingTime < TimeSpan.Zero)
                addingTime = -todayTime;
            addedTime += addingTime;
        }
    }
}
