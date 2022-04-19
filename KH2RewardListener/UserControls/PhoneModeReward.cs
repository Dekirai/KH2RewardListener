using MadMilkman.Ini;

namespace KH2RewardListener.UserControls
{
    public partial class PhoneModeReward : UserControl
    {
        public PhoneModeReward()
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
                RewardName = ini.Sections["PhoneMode"].Keys["RewardName"].Value;
                ChatMessage = ini.Sections["PhoneMode"].Keys["ChatMessage"].Value;
                Duration = int.Parse(ini.Sections["PhoneMode"].Keys["Duration"].Value);
            }
            catch
            {
                RewardName = "Phone Mode";
                ChatMessage = "The screen ratio will be changed to a phone like screen for [Duration] seconds.";
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
            if (!ini.Sections.Contains("PhoneMode"))
            {
                var section = ini.Sections.Add("PhoneMode");
                var reward = section.Keys.Add("RewardName", $"{RewardName}");
                var message = section.Keys.Add("ChatMessage", $"{ChatMessage}");
                var duration = section.Keys.Add("Duration", $"{Duration}");
            }
            else
            {
                ini.Sections["PhoneMode"].Keys["RewardName"].Value = RewardName;
                ini.Sections["PhoneMode"].Keys["ChatMessage"].Value = ChatMessage;
                ini.Sections["PhoneMode"].Keys["Duration"].Value = Duration.ToString();
            }
            ini.Save("config_rewards.ini");
        }

        public void DoAction()
        {
            var duration = Duration / 1000;
            var chatmessage = ChatMessage
                .Replace("[Duration]", duration.ToString());
            MainForm.client.SendMessage(MainForm.channel, chatmessage);
            Thread thread = new Thread(PhoneMode);
            thread.Start();
        }

        private async void PhoneMode()
        {
            MainForm.kh2.WriteFloat(0x89E9C0, 0.25f);
            await Task.Delay((int)Duration);
            MainForm.kh2.WriteFloat(0x89E9C0, 1);
            MainForm.client.SendMessage(MainForm.channel, $"'{RewardName}' has ended.");
        }
    }
}
