using System.Windows.Forms;
using System;
using System.Reflection.Emit;

namespace Work_Timer
{
    partial class WorkTimeRecorder : Form
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkTimeRecorder));
            this.DayTimeLabel = new System.Windows.Forms.Label();
            this.Timer1s = new System.Windows.Forms.Timer(this.components);
            this.ActiveWindowLabel = new System.Windows.Forms.Label();
            this.WeekTimeLabel = new System.Windows.Forms.Label();
            this.ThisWeeklabel = new System.Windows.Forms.Label();
            this.TodayLabel = new System.Windows.Forms.Label();
            this.ActiveWindowLabel0 = new System.Windows.Forms.Label();
            this.RecordingLabel = new System.Windows.Forms.Label();
            this.SetKeyWordButton = new System.Windows.Forms.Button();
            this.CheckAutoStart = new System.Windows.Forms.CheckBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip_NotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_CloseApp = new System.Windows.Forms.ToolStripMenuItem();
            this.button_Add30 = new System.Windows.Forms.Button();
            this.button_Subtract30 = new System.Windows.Forms.Button();
            this.contextMenuStrip_NotifyIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // DayTimeLabel
            // 
            this.DayTimeLabel.AutoSize = true;
            this.DayTimeLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.DayTimeLabel.Location = new System.Drawing.Point(177, 77);
            this.DayTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DayTimeLabel.Name = "DayTimeLabel";
            this.DayTimeLabel.Size = new System.Drawing.Size(101, 19);
            this.DayTimeLabel.TabIndex = 0;
            this.DayTimeLabel.Text = "01 hr 30 min";
            this.DayTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Timer1s
            // 
            this.Timer1s.Interval = 1000;
            this.Timer1s.Tick += new System.EventHandler(this.Timer1s_Tick);
            // 
            // ActiveWindowLabel
            // 
            this.ActiveWindowLabel.AutoSize = true;
            this.ActiveWindowLabel.Font = new System.Drawing.Font("Arial", 8F);
            this.ActiveWindowLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ActiveWindowLabel.Location = new System.Drawing.Point(34, 172);
            this.ActiveWindowLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ActiveWindowLabel.Name = "ActiveWindowLabel";
            this.ActiveWindowLabel.Size = new System.Drawing.Size(70, 14);
            this.ActiveWindowLabel.TabIndex = 1;
            this.ActiveWindowLabel.Text = "Visual Studio";
            this.ActiveWindowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WeekTimeLabel
            // 
            this.WeekTimeLabel.AutoSize = true;
            this.WeekTimeLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.WeekTimeLabel.Location = new System.Drawing.Point(177, 111);
            this.WeekTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WeekTimeLabel.Name = "WeekTimeLabel";
            this.WeekTimeLabel.Size = new System.Drawing.Size(101, 19);
            this.WeekTimeLabel.TabIndex = 2;
            this.WeekTimeLabel.Text = "01 hr 30 min";
            this.WeekTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ThisWeeklabel
            // 
            this.ThisWeeklabel.AutoSize = true;
            this.ThisWeeklabel.Font = new System.Drawing.Font("Arial", 10F);
            this.ThisWeeklabel.Location = new System.Drawing.Point(34, 111);
            this.ThisWeeklabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ThisWeeklabel.Name = "ThisWeeklabel";
            this.ThisWeeklabel.Size = new System.Drawing.Size(99, 16);
            this.ThisWeeklabel.TabIndex = 3;
            this.ThisWeeklabel.Text = "Week Average";
            this.ThisWeeklabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TodayLabel
            // 
            this.TodayLabel.AutoSize = true;
            this.TodayLabel.Font = new System.Drawing.Font("Arial", 10F);
            this.TodayLabel.Location = new System.Drawing.Point(34, 77);
            this.TodayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TodayLabel.Name = "TodayLabel";
            this.TodayLabel.Size = new System.Drawing.Size(116, 16);
            this.TodayLabel.TabIndex = 4;
            this.TodayLabel.Text = "Work Time Today";
            this.TodayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ActiveWindowLabel0
            // 
            this.ActiveWindowLabel0.AutoSize = true;
            this.ActiveWindowLabel0.Font = new System.Drawing.Font("Arial", 10F);
            this.ActiveWindowLabel0.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ActiveWindowLabel0.Location = new System.Drawing.Point(34, 149);
            this.ActiveWindowLabel0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ActiveWindowLabel0.Name = "ActiveWindowLabel0";
            this.ActiveWindowLabel0.Size = new System.Drawing.Size(112, 16);
            this.ActiveWindowLabel0.TabIndex = 5;
            this.ActiveWindowLabel0.Text = "You\'re looking at";
            this.ActiveWindowLabel0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RecordingLabel
            // 
            this.RecordingLabel.AutoSize = true;
            this.RecordingLabel.Font = new System.Drawing.Font("Arial", 12F);
            this.RecordingLabel.ForeColor = System.Drawing.Color.Red;
            this.RecordingLabel.Location = new System.Drawing.Point(34, 33);
            this.RecordingLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RecordingLabel.Name = "RecordingLabel";
            this.RecordingLabel.Size = new System.Drawing.Size(108, 18);
            this.RecordingLabel.TabIndex = 6;
            this.RecordingLabel.Text = "Not Recording";
            this.RecordingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SetKeyWordButton
            // 
            this.SetKeyWordButton.Location = new System.Drawing.Point(37, 240);
            this.SetKeyWordButton.Name = "SetKeyWordButton";
            this.SetKeyWordButton.Size = new System.Drawing.Size(241, 23);
            this.SetKeyWordButton.TabIndex = 7;
            this.SetKeyWordButton.Text = "Set Key Words";
            this.SetKeyWordButton.UseVisualStyleBackColor = true;
            this.SetKeyWordButton.Click += new System.EventHandler(this.SetKeyWordButton_Click);
            // 
            // CheckAutoStart
            // 
            this.CheckAutoStart.AutoSize = true;
            this.CheckAutoStart.Location = new System.Drawing.Point(200, 214);
            this.CheckAutoStart.Name = "CheckAutoStart";
            this.CheckAutoStart.Size = new System.Drawing.Size(78, 19);
            this.CheckAutoStart.TabIndex = 9;
            this.CheckAutoStart.Text = "Auto Start";
            this.CheckAutoStart.UseVisualStyleBackColor = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip_NotifyIcon;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Work Time Recorder";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            this.notifyIcon1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseUp);
            // 
            // contextMenuStrip_NotifyIcon
            // 
            this.contextMenuStrip_NotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_CloseApp});
            this.contextMenuStrip_NotifyIcon.Name = "contextMenuStrip_NotifyIcon";
            this.contextMenuStrip_NotifyIcon.Size = new System.Drawing.Size(137, 26);
            // 
            // toolStripMenuItem_CloseApp
            // 
            this.toolStripMenuItem_CloseApp.Name = "toolStripMenuItem_CloseApp";
            this.toolStripMenuItem_CloseApp.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem_CloseApp.Text = "Close App";
            this.toolStripMenuItem_CloseApp.Click += new System.EventHandler(this.toolStripMenuItem_CloseApp_Click);
            // 
            // button_Add30
            // 
            this.button_Add30.Location = new System.Drawing.Point(37, 211);
            this.button_Add30.Name = "button_Add30";
            this.button_Add30.Size = new System.Drawing.Size(65, 23);
            this.button_Add30.TabIndex = 10;
            this.button_Add30.Text = "+ 30 min";
            this.button_Add30.UseVisualStyleBackColor = true;
            this.button_Add30.Click += new System.EventHandler(this.button_Add30_Click);
            // 
            // button_Subtract30
            // 
            this.button_Subtract30.Location = new System.Drawing.Point(108, 211);
            this.button_Subtract30.Name = "button_Subtract30";
            this.button_Subtract30.Size = new System.Drawing.Size(65, 23);
            this.button_Subtract30.TabIndex = 11;
            this.button_Subtract30.Text = "- 30 min";
            this.button_Subtract30.UseVisualStyleBackColor = true;
            this.button_Subtract30.Click += new System.EventHandler(this.button_Subtract30_Click);
            // 
            // WorkTimeRecorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(319, 294);
            this.Controls.Add(this.button_Subtract30);
            this.Controls.Add(this.button_Add30);
            this.Controls.Add(this.CheckAutoStart);
            this.Controls.Add(this.SetKeyWordButton);
            this.Controls.Add(this.RecordingLabel);
            this.Controls.Add(this.ActiveWindowLabel0);
            this.Controls.Add(this.TodayLabel);
            this.Controls.Add(this.ThisWeeklabel);
            this.Controls.Add(this.WeekTimeLabel);
            this.Controls.Add(this.ActiveWindowLabel);
            this.Controls.Add(this.DayTimeLabel);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WorkTimeRecorder";
            this.Text = "Work Time Recorder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.contextMenuStrip_NotifyIcon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label DayTimeLabel;
        private Timer Timer1s;
        private System.Windows.Forms.Label ActiveWindowLabel;
        public System.Windows.Forms.Label WeekTimeLabel;
        private System.Windows.Forms.Label ThisWeeklabel;
        private System.Windows.Forms.Label TodayLabel;
        private System.Windows.Forms.Label ActiveWindowLabel0;
        private System.Windows.Forms.Label RecordingLabel;
        private Button SetKeyWordButton;
        private CheckBox CheckAutoStart;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip_NotifyIcon;
        private ToolStripMenuItem toolStripMenuItem_CloseApp;
        private Button button_Add30;
        private Button button_Subtract30;
    }
}

