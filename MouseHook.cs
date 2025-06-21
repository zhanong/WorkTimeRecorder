using System;
using System.Runtime.InteropServices;

namespace Work_Timer
{
    class MouseHook
    {
        // 钩子回调函数
        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);
        private static HookProc mouseProc = HookCallback;

        static IntPtr hookId;

        // 鼠标事件类型
        public enum MouseEventType
        {
            LeftButtonDown = 0x201,
            RightButtonDown = 0x204,
            MiddleButtonDown = 0x207,
            MouseWheel = 0x020A // 鼠标滚轮事件
        }

        public static void Initialization()
        {

            hookId = SetWindowsHookEx(WH_MOUSE_LL, mouseProc, IntPtr.Zero, 0);
            EventManager.onRealClose += Unhook;
        }

        private static int HookCallback(int nCode, Int32 wParam, IntPtr lParam)
        {
            if (WTimer.Present)
                return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);

            if (nCode >= 0)
            {
                if ((MouseEventType)wParam == MouseEventType.LeftButtonDown 
                    || (MouseEventType)wParam == MouseEventType.RightButtonDown
                    || (MouseEventType)wParam == MouseEventType.MiddleButtonDown
                    || (MouseEventType)wParam == MouseEventType.MouseWheel)
                    EventManager.onMouseClicked.Invoke();
            }

            return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }

        // 卸载鼠标钩子
        static void Unhook()
        {
            // 卸载钩子
            UnhookWindowsHookEx(hookId);
        }

        // Win32 API
        private const int WH_MOUSE_LL = 14;

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern int CallNextHookEx(IntPtr hhk, int nCode, Int32 wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);
    }
}
