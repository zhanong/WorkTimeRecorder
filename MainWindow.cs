using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Forms;

namespace Work_Timer
{
    public partial class WorkTimeRecorder : Form
    {
        int ticks = 0;
        public WorkTimeRecorder()
        {
            InitializeComponent();
            OnLoad();
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            EventManager.onStartRecording += () => RecordingLabel.Text = "Recording";
            EventManager.onStopRecording += () => RecordingLabel.Text = "Not Recording";
            EventManager.onDayEnding += SaveCurrent;
            Timer1s.Interval = 1000; // 1 second interval
            Timer1s.Start();
            if (IsAutoStart())
                CheckAutoStart.Checked = true;
            else
                CheckAutoStart.Checked = false;
            UpdateDisplay();
        }

        private void OnLoad()
        {
            //Debug.Initialization();
            WTimer.Initialization();
            DataProcesser.Initialization();
            KeyboardHook.Initialization();
            MouseHook.Initialization();
        }

        static void SaveCurrent()
        {
            EventManager.onSaving.Invoke();
            DataProcesser.UpdateData(WTimer.TotalTime, out string[] dayData, out string[] weekData);
            DataPersistence.WriteText(dayData, weekData);
            WTimer.CleanTotalTime();
            EventManager.onSaved.Invoke();
        }

        void UpdateDisplay()
        {
            CurrentWindow.UpdateCaptionOfActiveWindow();
            ActiveWindowLabel.Text = CurrentWindow.CurrentActiveWindow;
            DayTimeLabel.Text = $"{WTimer.WorkTimeToday.Hours:00} hr {WTimer.WorkTimeToday.Minutes:00} min";
            WeekTimeLabel.Text = $"{WTimer.AverageTimeOfWeek.Hours:00} hr {WTimer.AverageTimeOfWeek.Minutes:00} min";
        }

        void SetAutoStart()
        {
            string keyName = @"Software\Microsoft\Windows\CurrentVersion\Run";
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName, true))
            {
                if (key != null && key.GetValue("WorkTimeRecorder") == null)
                    key.SetValue("WorkTimeRecorder", Application.ExecutablePath);
            }
        }

        void RemoveAutoStart()
        {
            string keyName = @"Software\Microsoft\Windows\CurrentVersion\Run";
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName, true))
            {
                if (key != null && key.GetValue("WorkTimeRecorder") != null)
                    key.DeleteValue("WorkTimeRecorder");
            }
        }

        bool IsAutoStart()
        {
            string keyName = @"Software\Microsoft\Windows\CurrentVersion\Run";
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName, true))
            {
                if (key != null && key.GetValue("WorkTimeRecorder") != null)
                    return true;
            }
            return false;
        }

        /******************************************************************************************************/
        #region component Events

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Visible = false;
                return;
            }
        }

        private void Timer1s_Tick(object sender, EventArgs e)
        {
            UpdateDisplay();
            EventManager.on1sUpdate.Invoke(ticks);

            if (ticks % 600 == 0)
            {
                SaveCurrent();
            }
            ticks ++;
        }



        private void SetKeyWordButton_Click(object sender, EventArgs e)
        {
            var keyWordSetter = new KeyWordSetter();
            keyWordSetter.ShowDialog();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    // 当程序是最小化的状态时显示程序页面
                    this.WindowState = FormWindowState.Normal;
                }
                this.Activate();
                this.Visible = true;
                this.ShowInTaskbar = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripMenuItem_CloseApp_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void notifyIcon1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // 显示右键菜单
                contextMenuStrip_NotifyIcon.Show(Cursor.Position);
            }
        }

        private void button_Add30_Click(object sender, EventArgs e)
        {
            WTimer.AddMinutes(30);
            UpdateDisplay();
        }

        private void button_Subtract30_Click(object sender, EventArgs e)
        {
            WTimer.AddMinutes(-30);
            UpdateDisplay();
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            EventManager.onRealClose.Invoke();
            if (CheckAutoStart.Checked)
                SetAutoStart();
            else
                RemoveAutoStart();
        }

        #endregion component Events

    }


}
