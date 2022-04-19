using MadMilkman.Ini;

namespace KH2RewardListener.UserControls
{
    public partial class RefillFormDurationReward : UserControl
    {
        public RefillFormDurationReward()
        {
            InitializeComponent();
            CheckSettingsFile();
            LoadSettingsFile();
        }

        public void CheckSettingsFile()
        {
            var ini = new IniFile();

            if (!File.Exists("config_rewards.ini"))
                File.Create("config_rewards.ini");
        }

        public void LoadSettingsFile()
        {
            var ini = new IniFile();
            ini.Load(Environment.CurrentDirectory + @"\config_rewards.ini");
            try
            {
                RewardName = ini.Sections["RefillFormDuration"].Keys["RewardName"].Value;
                ChatMessage = ini.Sections["RefillFormDuration"].Keys["ChatMessage"].Value;
            }
            catch
            {
                RewardName = "Refill Form Duration";
                ChatMessage = "The form duration got refilled.";
            }
        }

        public string RewardName
        {
            get
            {
                return tb_rewardname.Text;
            }
            set
            {
                tb_rewardname.Text = value;
            }
        }

        public string ChatMessage
        {
            get
            {
                return tb_chatmessage.Text;
            }
            set
            {
                tb_chatmessage.Text = value;
            }
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            if (tb_rewardname.Text.Length == 0)
            {
                MessageBox.Show("Error", "Please enter a valid reward name!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var ini = new IniFile();
            ini.Load(Environment.CurrentDirectory + @"\config_rewards.ini");
            if (!ini.Sections.Contains("RefillFormDuration"))
            {
                var section = ini.Sections.Add("RefillFormDuration");
                var reward = section.Keys.Add("RewardName", $"{RewardName}");
                var message = section.Keys.Add("ChatMessage", $"{ChatMessage}");
            }
            else
            {
                ini.Sections["RefillFormDuration"].Keys["RewardName"].Value = RewardName;
                ini.Sections["RefillFormDuration"].Keys["ChatMessage"].Value = ChatMessage;
            }
            ini.Save("config_rewards.ini");
        }

        public void DoAction()
        {
            MainForm.client.SendMessage(MainForm.channel, ChatMessage);
            MainForm.kh2.WriteFloat(0x2A20E4C, 6000);
        }
    }
}
