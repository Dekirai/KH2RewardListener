using MadMilkman.Ini;

namespace KH2RewardListener.UserControls
{
    public partial class Magic255Reward : UserControl
    {
        public Magic255Reward()
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
                RewardName = ini.Sections["Magic255"].Keys["RewardName"].Value;
                ChatMessage = ini.Sections["Magic255"].Keys["ChatMessage"].Value;
                Duration = int.Parse(ini.Sections["Magic255"].Keys["Duration"].Value);
            }
            catch
            {
                RewardName = "Magic 255";
                ChatMessage = "Sora's magic strength has been set to 255 for [Duration] seconds.";
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
            if (!ini.Sections.Contains("Magic255"))
            {
                var section = ini.Sections.Add("Magic255");
                var reward = section.Keys.Add("RewardName", $"{RewardName}");
                var message = section.Keys.Add("ChatMessage", $"{ChatMessage}");
                var duration = section.Keys.Add("Duration", $"{Duration}");
            }
            else
            {
                ini.Sections["Magic255"].Keys["RewardName"].Value = RewardName;
                ini.Sections["Magic255"].Keys["ChatMessage"].Value = ChatMessage;
                ini.Sections["Magic255"].Keys["Duration"].Value = Duration.ToString();
            }
            ini.Save("config_rewards.ini");
        }

        public void DoAction()
        {
            var duration = Duration / 1000;
            var chatmessage = ChatMessage
                .Replace("[Duration]", duration.ToString());
            MainForm.client.SendMessage(MainForm.channel, chatmessage);
            Thread thread = new Thread(Magic255);
            thread.Start();
        }

        private async void Magic255()
        {
            var old = MainForm.kh2.ReadByte(0x2A20E22);
            MainForm.mem.FreezeValue($"KINGDOM HEARTS II FINAL MIX.exe+2A20E22", "byte", "0xFF");
            await Task.Delay((int)Duration);
            MainForm.mem.UnfreezeValue($"KINGDOM HEARTS II FINAL MIX.exe+2A20E22");
            MainForm.kh2.WriteByte(0x2A20E22, old);
            MainForm.client.SendMessage(MainForm.channel, $"'{RewardName}' wurde beendet.");
        }
    }
}
