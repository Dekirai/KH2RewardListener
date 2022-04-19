using MadMilkman.Ini;

namespace KH2RewardListener.UserControls
{
    public partial class SoftResetReward : UserControl
    {
        public SoftResetReward()
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
                RewardName = ini.Sections["SoftReset"].Keys["RewardName"].Value;
                ChatMessage = ini.Sections["SoftReset"].Keys["ChatMessage"].Value;
            }
            catch
            {
                RewardName = "Soft Reset";
                ChatMessage = "The game has been reset.";
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
            if (!ini.Sections.Contains("SoftReset"))
            {
                var section = ini.Sections.Add("SoftReset");
                var reward = section.Keys.Add("RewardName", $"{RewardName}");
                var message = section.Keys.Add("ChatMessage", $"{ChatMessage}");
            }
            else
            {
                ini.Sections["SoftReset"].Keys["RewardName"].Value = RewardName;
                ini.Sections["SoftReset"].Keys["ChatMessage"].Value = ChatMessage;
            }
            ini.Save("config_rewards.ini");
        }

        public void DoAction()
        {
            MainForm.client.SendMessage(MainForm.channel, ChatMessage);
            MainForm.kh2.WriteByte(0xAB845A, 0x01);
            MainForm.kh2.WriteInt(0x751310, 1);
            MainForm.kh2.WriteByte(0x2AE3478, 0x00);
        }
    }
}
