using MadMilkman.Ini;

namespace KH2RewardListener.UserControls
{
    public partial class AutoJumpReward : UserControl
    {
        public AutoJumpReward()
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
                RewardName = ini.Sections["AutoJump"].Keys["RewardName"].Value;
                ChatMessage = ini.Sections["AutoJump"].Keys["ChatMessage"].Value;
                Duration = int.Parse(ini.Sections["AutoJump"].Keys["Duration"].Value);
            }
            catch
            {
                RewardName = "Auto-Jump";
                ChatMessage = "Sora is now jumping continuously for [Duration] seconds.";
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
            if (!ini.Sections.Contains("AutoJump"))
            {
                var section = ini.Sections.Add("AutoJump");
                var reward = section.Keys.Add("RewardName", $"{RewardName}");
                var message = section.Keys.Add("ChatMessage", $"{ChatMessage}");
                var duration = section.Keys.Add("Duration", $"{Duration}");
            }
            else
            {
                ini.Sections["AutoJump"].Keys["RewardName"].Value = RewardName;
                ini.Sections["AutoJump"].Keys["ChatMessage"].Value = ChatMessage;
                ini.Sections["AutoJump"].Keys["Duration"].Value = Duration.ToString();
            }
            ini.Save("config_rewards.ini");
        }

        public void DoAction()
        {
            var duration = Duration / 1000;
            var chatmessage = ChatMessage
                .Replace("[Duration]", duration.ToString());
            MainForm.client.SendMessage(MainForm.channel, chatmessage);
            Thread thread = new Thread(AutoJump);
            thread.Start();
        }

        private async void AutoJump()
        {
            MainForm.kh2.Write2Bytes(0x3D484E, 0x90, 0x90);
            await Task.Delay((int)Duration);
            MainForm.kh2.Write2Bytes(0x3D484E, 0x74, 0x2A);
            MainForm.client.SendMessage(MainForm.channel, $"'{RewardName}' wurde beendet.");
        }
    }
}
