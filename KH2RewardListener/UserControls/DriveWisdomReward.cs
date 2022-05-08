using MadMilkman.Ini;

namespace KH2RewardListener.UserControls
{
    public partial class DriveWisdomReward : UserControl
    {
        public DriveWisdomReward()
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
                RewardName = ini.Sections["DriveWisdom"].Keys["RewardName"].Value;
                ChatMessage = ini.Sections["DriveWisdom"].Keys["ChatMessage"].Value;
            }
            catch
            {
                RewardName = "Force Wisdom";
                ChatMessage = "Sora got forced into the Wisdom Form.";
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
            if (!ini.Sections.Contains("DriveWisdom"))
            {
                var section = ini.Sections.Add("DriveWisdom");
                var reward = section.Keys.Add("RewardName", $"{RewardName}");
                var message = section.Keys.Add("ChatMessage", $"{ChatMessage}");
            }
            else
            {
                ini.Sections["DriveWisdom"].Keys["RewardName"].Value = RewardName;
                ini.Sections["DriveWisdom"].Keys["ChatMessage"].Value = ChatMessage;
            }
            ini.Save("config_rewards.ini");
        }

        public void DoAction()
        {
            MainForm.client.SendMessage(MainForm.channel, ChatMessage);
            MainForm.mem.WriteMemory("KINGDOM HEARTS II FINAL MIX.exe+2A5A096", "bytes", "0x05 0x00 0x01 0x00"); //Revert incase we are in a form already
            Thread.Sleep(400);
            MainForm.mem.WriteMemory("KINGDOM HEARTS II FINAL MIX.exe+2A5A096", "bytes", "0x04 0x00 0x02 0x00");
            Thread.Sleep(400);
            MainForm.mem.WriteMemory("KINGDOM HEARTS II FINAL MIX.exe+2A5A096", "bytes", "0x00 0x00 0x00 0x00");
            Thread.Sleep(2000);
        }
    }
}
