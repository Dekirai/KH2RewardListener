using MadMilkman.Ini;

namespace KH2RewardListener.UserControls
{
    public partial class Defense0Reward : UserControl
    {
        public Defense0Reward()
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
                RewardName = ini.Sections["Defense0"].Keys["RewardName"].Value;
                ChatMessage = ini.Sections["Defense0"].Keys["ChatMessage"].Value;
                Duration = int.Parse(ini.Sections["Defense0"].Keys["Duration"].Value);
            }
            catch
            {
                RewardName = "Defense 0";
                ChatMessage = "Sora's defense has been set to 0 for [Duration] seconds.";
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
            if (!ini.Sections.Contains("Defense0"))
            {
                var section = ini.Sections.Add("Defense0");
                var reward = section.Keys.Add("RewardName", $"{RewardName}");
                var message = section.Keys.Add("ChatMessage", $"{ChatMessage}");
                var duration = section.Keys.Add("Duration", $"{Duration}");
            }
            else
            {
                ini.Sections["Defense0"].Keys["RewardName"].Value = RewardName;
                ini.Sections["Defense0"].Keys["ChatMessage"].Value = ChatMessage;
                ini.Sections["Defense0"].Keys["Duration"].Value = Duration.ToString();
            }
            ini.Save("config_rewards.ini");
        }

        public void DoAction()
        {
            var duration = Duration / 1000;
            var chatmessage = ChatMessage
                .Replace("[Duration]", duration.ToString());
            MainForm.client.SendMessage(MainForm.channel, chatmessage);
            Thread thread = new Thread(Defense0);
            thread.Start();
        }

        private async void Defense0()
        {
            var old = MainForm.kh2.ReadByte(0x2A20E24);
            MainForm.mem.FreezeValue($"KINGDOM HEARTS II FINAL MIX.exe+2A20E24", "byte", "0x04");
            await Task.Delay((int)Duration);
            MainForm.mem.UnfreezeValue($"KINGDOM HEARTS II FINAL MIX.exe+2A20E24");
            MainForm.kh2.WriteByte(0x2A20E24, old);
            MainForm.client.SendMessage(MainForm.channel, $"'{RewardName}' wurde beendet.");
        }
    }
}
