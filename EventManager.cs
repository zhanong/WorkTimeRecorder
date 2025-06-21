using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work_Timer
{
    internal static class EventManager
    {
        public delegate void Action();
        public static Action onKeyPress = delegate { };
        public static Action onMouseClicked = delegate { };
        public static Action onStartRecording = delegate { };
        public static Action onStopRecording = delegate { };
        public static Action onEndTimerStart = delegate { };
        public static Action onEndTimerStop = delegate { };
        public static Action onRealClose = delegate { };
        public static Action onSaving = delegate { };
        public static Action onSaved = delegate { };
        public static Action onDayEnding = delegate { };
        public static Action onDayStarted = delegate { };
        public static Action onWeekStarted = delegate { };

        public delegate void Action_Int(int num);
        public static Action_Int on1sUpdate = delegate { };

        public delegate void Action_Strings(string[] strings);
        public static Action_Strings onKeyWordChanged = delegate { };
    }
}
