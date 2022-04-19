using MadMilkman.Ini;

namespace KH2RewardListener.UserControls
{
    public partial class EmptyMagicReward : UserControl
    {
        public EmptyMagicReward()
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
                RewardName = ini.Sections["EmptyMagic"].Keys["RewardName"].Value;
                ChatMessage = ini.Sections["EmptyMagic"].Keys["ChatMessage"].Value;
            }
            catch
            {
                RewardName = "Empty Magic";
                ChatMessage = "Sora's MP has been set to 0.";
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
            if (!ini.Sections.Contains(tb_rewardname.Text))
            {
                var section = ini.Sections.Add("EmptyMagic");
                var reward = section.Keys.Add("RewardName", $"{RewardName}");
                var message = section.Keys.Add("ChatMessage", $"{ChatMessage}");
            }
            ini.Save("config_rewards.ini");
        }

        public void DoAction()
        {
            MainForm.client.SendMessage(MainForm.channel, ChatMessage);
            MainForm.kh2.WriteInt(0x2A20E18, 0);
        }
    }
}
