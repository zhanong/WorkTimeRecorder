using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Work_Timer
{
    internal class CurrentWindow
    {
        static string[] validKeyWords;
        public static string CurrentActiveWindow { get; set; }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowTextLength(IntPtr hWnd);

        static CurrentWindow()
        {
            validKeyWords = DataPersistence.LoadKeyWord();
            EventManager.onKeyWordChanged += (keyWords) => validKeyWords = keyWords;
        }

        public static void UpdateCaptionOfActiveWindow()
        {
            var handle = GetForegroundWindow();
            var intLength = GetWindowTextLength(handle) + 1;
            var stringBuilder = new StringBuilder(intLength);

            if (GetWindowText(handle, stringBuilder, intLength) > 0)
            {
                CurrentActiveWindow = stringBuilder.ToString();
                return;
            }

            CurrentActiveWindow = string.Empty;
        }

        public static bool IsValidWindow()
        {
            foreach (var keyword in validKeyWords)
            {
                if (CheckMatch(keyword))
                    return true;
            }
            return false;
        }

        static bool CheckMatch(string keyWord)
        {
            string[] words = keyWord.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words) 
                if (!CurrentActiveWindow.Contains(word)) 
                    return false;
            return true;
        }
    }
}
