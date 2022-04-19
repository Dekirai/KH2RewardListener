using MadMilkman.Ini;

namespace KH2RewardListener.UserControls
{
    public partial class DriveAnywhereReward : UserControl
    {
        public DriveAnywhereReward()
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
                RewardName = ini.Sections["DriveAnywhere"].Keys["RewardName"].Value;
                ChatMessage = ini.Sections["DriveAnywhere"].Keys["ChatMessage"].Value;
                Duration = int.Parse(ini.Sections["DriveAnywhere"].Keys["Duration"].Value);
            }
            catch
            {
                RewardName = "Drive Anywhere";
                ChatMessage = "Sora can use drive anywhere, regardless of party members for [Duration] seconds.";
                Duration = 10000;
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

        public decimal Duration
        {
            get
            {
                return nud_duration.Value;
            }
            set
            {
                nud_duration.Value = value;
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
            if (!ini.Sections.Contains("DriveAnywhere"))
            {
                var section = ini.Sections.Add("DriveAnywhere");
                var reward = section.Keys.Add("RewardName", $"{RewardName}");
                var message = section.Keys.Add("ChatMessage", $"{ChatMessage}");
                var duration = section.Keys.Add("Duration", $"{Duration}");
            }
            else
            {
                ini.Sections["DriveAnywhere"].Keys["RewardName"].Value = RewardName;
                ini.Sections["DriveAnywhere"].Keys["ChatMessage"].Value = ChatMessage;
                ini.Sections["DriveAnywhere"].Keys["Duration"].Value = Duration.ToString();
            }
            ini.Save("config_rewards.ini");
        }

        public void DoAction()
        {
            var duration = Duration / 1000;
            var chatmessage = ChatMessage
                .Replace("[Duration]", duration.ToString());
            MainForm.client.SendMessage(MainForm.channel, chatmessage);
            Thread thread = new Thread(DriveAnywhere);
            thread.Start();
        }

        private async void DriveAnywhere()
        {
            MainForm.kh2.WriteByte(0x3F059E, 0x77);
            MainForm.kh2.WriteByte(0x3FF735, 0x82);
            MainForm.kh2.WriteByte(0x3E107C, 0x72);
            await Task.Delay((int)Duration);
            MainForm.kh2.WriteByte(0x3F059E, 0x74);
            MainForm.kh2.WriteByte(0x3FF735, 0x85);
            MainForm.kh2.WriteByte(0x3E107C, 0x78);
            MainForm.client.SendMessage(MainForm.channel, $"'{RewardName}' wurde beendet.");
        }
    }
}
