using System;
using System.Drawing;
using System.IO;

namespace Work_Timer
{
    internal class DataProcesser
    {
        static TimeSpan _lastSavedThisDayTime;
        public static TimeSpan LastSavedThisDayTime => _lastSavedThisDayTime;

        static TimeSpan _lastSavedThisWeekTime;
        public static TimeSpan LastSavedThisWeekTime => _lastSavedThisWeekTime;

        public static void Initialization()
        {
            UpdateData(TimeSpan.Zero, out string[] dayData, out string[] weekData);
            Decode(dayData[dayData.Length - 1], out _, out _lastSavedThisDayTime);
            Decode(weekData[weekData.Length - 1], out _, out _lastSavedThisWeekTime);
            EventManager.onDayStarted += () => { _lastSavedThisDayTime = TimeSpan.Zero; };
            EventManager.onWeekStarted += () => { _lastSavedThisWeekTime = TimeSpan.Zero; };
        }


        public static void UpdateData(TimeSpan timeSpan, out string[] dayData, out string[] weekData)
        {
            if (!DataPersistence.GetData(out dayData, out weekData))
                return;

            //Update Day
            UpdateData(ref dayData, WTimer.Today, timeSpan);
            Decode(dayData[dayData.Length - 1], out _, out _lastSavedThisDayTime);

            //Update Week
            UpdateData(ref weekData, GetThisMonday(), timeSpan);
            Decode(weekData[weekData.Length - 1], out _, out _lastSavedThisWeekTime);
        }

        static void UpdateData(ref string[] data, DateTime date, TimeSpan timeSpan)
        {
            TimeSpan originalSpan = TimeSpan.Zero;
            int index = 0;
            if (data == null)
                data = new string[1];
            else if (!TryFindDate(data, date, out index, out originalSpan))
            {
                Array.Resize(ref data, data.Length + 1);
                index = data.Length - 1;
            }
            originalSpan += timeSpan;
            data[index] = Encode(date, originalSpan);
        }

        static bool TryFindDate(string[] dayData, DateTime expectedDate, out int index, out TimeSpan timeSpan)
        {
            index = -1;
            timeSpan = TimeSpan.Zero;
            if (dayData.Length == 0)
                return false;

            for (int i = dayData.Length - 1; i >= 0; i--)
            {
                Decode(dayData[i], out var date, out var span);
                if (date.Date == expectedDate.Date)
                {
                    index = i;
                    timeSpan = span;
                    return true;
                }
            }
            return false;
        }

        static string Encode(DateTime dateTime, TimeSpan timeSpan)
        {
            return $"{dateTime.Year}!{dateTime.Month}!{dateTime.Day}:{timeSpan.Days}!{timeSpan.Hours}!{timeSpan.Minutes}!{timeSpan.Seconds}";
            // return $"{dateTime.Year}!{dateTime.Month}!{dateTime.Day}:{timeSpan.Hours}!{timeSpan.Minutes}!{timeSpan.Seconds}";
        }

        static void Decode(string input, out DateTime dateTime, out TimeSpan timeSpan)
        {
            string[] strings = input.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            string[] dt = strings[0].Split(new char[] { '!' }, StringSplitOptions.RemoveEmptyEntries);
            string[] ts = strings[1].Split(new char[] { '!' }, StringSplitOptions.RemoveEmptyEntries);
            dateTime = new DateTime(int.Parse(dt[0]), int.Parse(dt[1]), int.Parse(dt[2]));
            if (ts.Length == 4)
                timeSpan = new TimeSpan(int.Parse(ts[0]), int.Parse(ts[1]), int.Parse(ts[2]), int.Parse(ts[3]));
            else
                timeSpan = new TimeSpan(int.Parse(ts[0]), int.Parse(ts[1]), int.Parse(ts[2]));
        }

        static DateTime GetThisMonday()
        {
            if (WTimer.Today.DayOfWeek is DayOfWeek.Sunday)
                return WTimer.Today.AddDays(-6);

            return WTimer.Today.AddDays(1 - (int)WTimer.Today.DayOfWeek);
        }

    }
}
