using MadMilkman.Ini;

namespace KH2RewardListener.UserControls
{
    public partial class EmptyDriveReward : UserControl
    {
        public EmptyDriveReward()
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
                RewardName = ini.Sections["EmptyDrive"].Keys["RewardName"].Value;
                ChatMessage = ini.Sections["EmptyDrive"].Keys["ChatMessage"].Value;
            }
            catch
            {
                RewardName = "Empty Drive";
                ChatMessage = "Sora's drive gauge has been set to 0.";
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
            if (!ini.Sections.Contains("EmptyDrive"))
            {
                var section = ini.Sections.Add("EmptyDrive");
                var reward = section.Keys.Add("RewardName", $"{RewardName}");
                var message = section.Keys.Add("ChatMessage", $"{ChatMessage}");
            }
            else
            {
                ini.Sections["EmptyDrive"].Keys["RewardName"].Value = RewardName;
                ini.Sections["EmptyDrive"].Keys["ChatMessage"].Value = ChatMessage;
            }
            ini.Save("config_rewards.ini");
        }

        public void DoAction()
        {
            MainForm.client.SendMessage(MainForm.channel, ChatMessage);
            MainForm.kh2.WriteByte(0x2A20E48, 0x00);
            MainForm.kh2.WriteByte(0x2A20E49, 0x00);
        }
    }
}
