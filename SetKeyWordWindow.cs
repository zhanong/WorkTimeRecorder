using System;
using System.Windows.Forms;

namespace Work_Timer
{
    public partial class KeyWordSetter : Form
    {
        public KeyWordSetter()
        {
            InitializeComponent();
        }

        private void KeyWordSetter_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 获取文本框中的输入
            string inputText = KeyWordBox.Text;

            // 分割多行输入
            string[] keyWrods = inputText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            DataPersistence.SaveKeyWord(keyWrods);
            EventManager.onKeyWordChanged.Invoke(keyWrods);
        }

        private void KeyWordSetter_Load(object sender, EventArgs e)
        {
            string keyWrods = string.Join(Environment.NewLine, DataPersistence.LoadKeyWord());
            KeyWordBox.Text = keyWrods;
        }
    }
}
