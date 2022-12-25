using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SmartMouseWin
{
    /// <summary>
    /// 参考：https://lets-csharp.com/mouse-hook/
    /// </summary>
    public class MouseHook
    {
        protected const int WH_MOUSE_LL = 14;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, MouseHookProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        // これをしないとGCにより回収されてしまってCallbackOnCollectedDelegate例外で詰む
        private delegate IntPtr MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam);
        MouseHookProc mouseHookProc = null;

        private IntPtr hookId = IntPtr.Zero;

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public System.IntPtr dwExtraInfo;
        }

        public void Hook()
        {
            if (hookId == IntPtr.Zero)
            {
                using (var curProcess = Process.GetCurrentProcess())
                {
                    using (ProcessModule curModule = curProcess.MainModule)
                    {
                        // フィールド変数にHookProcedureを保存する
                        // そうしないとGCにより回収されてしまってCallbackOnCollectedDelegate例外で詰む
                        mouseHookProc = HookProcedure;
                        hookId = SetWindowsHookEx(WH_MOUSE_LL, mouseHookProc, GetModuleHandle(curModule.ModuleName), 0);
                    }
                }
            }
        }

        public void UnHook()
        {
            UnhookWindowsHookEx(hookId);
            hookId = IntPtr.Zero;
        }

        public IntPtr HookProcedure(int nCode, IntPtr wParam, IntPtr lParam)
        {
            int WM_MOUSEMOVE = 0x0200;
            int WM_LBUTTONDOWN = 0x0201;
            int WM_LBUTTONUP = 0x0202;
            int WM_RBUTTONDOWN = 0x0204;
            int WM_RBUTTONUP = 0x0205;

            if (nCode >= 0 && wParam == (IntPtr)WM_MOUSEMOVE)
            {
                MSLLHOOKSTRUCT ms = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                MouseMoveEvent?.Invoke(this, new MouseEventArg(ms.pt.x, ms.pt.y));
            }
            if (nCode >= 0 && wParam == (IntPtr)WM_LBUTTONDOWN)
            {
                MSLLHOOKSTRUCT ms = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                LButtonDownEvent?.Invoke(this, new MouseEventArg(ms.pt.x, ms.pt.y));
            }
            if (nCode >= 0 && wParam == (IntPtr)WM_LBUTTONUP)
            {
                MSLLHOOKSTRUCT ms = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                LButtonUpEvent?.Invoke(this, new MouseEventArg(ms.pt.x, ms.pt.y));
            }
            if (nCode >= 0 && wParam == (IntPtr)WM_RBUTTONDOWN)
            {
                MSLLHOOKSTRUCT ms = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                RButtonDownEvent?.Invoke(this, new MouseEventArg(ms.pt.x, ms.pt.y));
            }
            if (nCode >= 0 && wParam == (IntPtr)WM_RBUTTONUP)
            {
                MSLLHOOKSTRUCT ms = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                RButtonUpEvent?.Invoke(this, new MouseEventArg(ms.pt.x, ms.pt.y));
            }

            return CallNextHookEx(hookId, nCode, wParam, lParam);
        }

        public delegate void MouseEventHandler(object sender, MouseEventArg e);
        public event MouseEventHandler MouseMoveEvent;
        public event MouseEventHandler LButtonDownEvent;
        public event MouseEventHandler LButtonUpEvent;
        public event MouseEventHandler RButtonDownEvent;
        public event MouseEventHandler RButtonUpEvent;
    }

    public class MouseEventArg : EventArgs
    {
        public MouseEventArg(int x, int y)
        {
            Point = new Point(x, y);
        }
        public Point Point
        {
            get;
            private set;
        }
    }
}
