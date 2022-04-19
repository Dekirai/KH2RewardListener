using MadMilkman.Ini;

namespace KH2RewardListener.UserControls
{
    public partial class NoMagicReward : UserControl
    {
        public NoMagicReward()
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
                RewardName = ini.Sections["NoMagic"].Keys["RewardName"].Value;
                ChatMessage = ini.Sections["NoMagic"].Keys["ChatMessage"].Value;
                Duration = int.Parse(ini.Sections["NoMagic"].Keys["Duration"].Value);
            }
            catch
            {
                RewardName = "No Magic";
                ChatMessage = "Sora is no longer able to use magic for [Duration] seconds.";
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
            if (!ini.Sections.Contains("NoMagic"))
            {
                var section = ini.Sections.Add("NoMagic");
                var reward = section.Keys.Add("RewardName", $"{RewardName}");
                var message = section.Keys.Add("ChatMessage", $"{ChatMessage}");
                var duration = section.Keys.Add("Duration", $"{Duration}");
            }
            else
            {
                ini.Sections["NoMagic"].Keys["RewardName"].Value = RewardName;
                ini.Sections["NoMagic"].Keys["ChatMessage"].Value = ChatMessage;
                ini.Sections["NoMagic"].Keys["Duration"].Value = Duration.ToString();
            }
            ini.Save("config_rewards.ini");
        }

        public void DoAction()
        {
            var duration = Duration / 1000;
            var chatmessage = ChatMessage
                .Replace("[Duration]", duration.ToString());
            MainForm.client.SendMessage(MainForm.channel, chatmessage);
            Thread thread = new Thread(NoMagic);
            thread.Start();
        }

        private async void NoMagic()
        {
            MainForm.mem.FreezeValue($"KINGDOM HEARTS II FINAL MIX.exe+2A5A0F6", "byte", "0x00");
            await Task.Delay((int)Duration);
            MainForm.mem.UnfreezeValue($"KINGDOM HEARTS II FINAL MIX.exe+2A5A0F6");
            MainForm.kh2.WriteByte(0x2A5A0F6, 0x02);
            MainForm.client.SendMessage(MainForm.channel, $"'{RewardName}' has ended.");
        }
    }
}
