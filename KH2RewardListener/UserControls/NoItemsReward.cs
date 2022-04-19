using MadMilkman.Ini;

namespace KH2RewardListener.UserControls
{
    public partial class NoItemsReward : UserControl
    {
        public NoItemsReward()
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
                RewardName = ini.Sections["NoItems"].Keys["RewardName"].Value;
                ChatMessage = ini.Sections["NoItems"].Keys["ChatMessage"].Value;
                Duration = int.Parse(ini.Sections["NoItems"].Keys["Duration"].Value);
            }
            catch
            {
                RewardName = "No Items";
                ChatMessage = "Sora is no longer able to use items for [Duration] seconds.";
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
            if (!ini.Sections.Contains("NoItems"))
            {
                var section = ini.Sections.Add("NoItems");
                var reward = section.Keys.Add("RewardName", $"{RewardName}");
                var message = section.Keys.Add("ChatMessage", $"{ChatMessage}");
                var duration = section.Keys.Add("Duration", $"{Duration}");
            }
            else
            {
                ini.Sections["NoItems"].Keys["RewardName"].Value = RewardName;
                ini.Sections["NoItems"].Keys["ChatMessage"].Value = ChatMessage;
                ini.Sections["NoItems"].Keys["Duration"].Value = Duration.ToString();
            }
            ini.Save("config_rewards.ini");
        }

        public void DoAction()
        {
            var duration = Duration / 1000;
            var chatmessage = ChatMessage
                .Replace("[Duration]", duration.ToString());
            MainForm.client.SendMessage(MainForm.channel, chatmessage);
            Thread thread = new Thread(NoItems);
            thread.Start();
        }

        private async void NoItems()
        {
            MainForm.mem.FreezeValue($"KINGDOM HEARTS II FINAL MIX.exe+2A5A126", "byte", "0x00");
            await Task.Delay((int)Duration);
            MainForm.mem.UnfreezeValue($"KINGDOM HEARTS II FINAL MIX.exe+2A5A126");
            MainForm.kh2.WriteByte(0x2A5A0F6, 0x03);
            MainForm.client.SendMessage(MainForm.channel, $"'{RewardName}' has ended.");
        }
    }
}
