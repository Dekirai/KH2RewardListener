using MadMilkman.Ini;

namespace KH2RewardListener.UserControls
{
    public partial class Attack0Reward : UserControl
    {
        public Attack0Reward()
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
                RewardName = ini.Sections["Attack0"].Keys["RewardName"].Value;
                ChatMessage = ini.Sections["Attack0"].Keys["ChatMessage"].Value;
                Duration = int.Parse(ini.Sections["Attack0"].Keys["Duration"].Value);
            }
            catch
            {
                RewardName = "Attack 0";
                ChatMessage = "Sora's attack has been set to 0 for [Duration] seconds.";
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
            if (!ini.Sections.Contains("Attack0"))
            {
                var section = ini.Sections.Add("Attack0");
                var reward = section.Keys.Add("RewardName", $"{RewardName}");
                var message = section.Keys.Add("ChatMessage", $"{ChatMessage}");
                var duration = section.Keys.Add("Duration", $"{Duration}");
            }
            else
            {
                ini.Sections["Attack0"].Keys["RewardName"].Value = RewardName;
                ini.Sections["Attack0"].Keys["ChatMessage"].Value = ChatMessage;
                ini.Sections["Attack0"].Keys["Duration"].Value = Duration.ToString();
            }
            ini.Save("config_rewards.ini");
        }

        public void DoAction()
        {
            var duration = Duration / 1000;
            var chatmessage = ChatMessage
                .Replace("[Duration]", duration.ToString());
            MainForm.client.SendMessage(MainForm.channel, chatmessage);
            Thread thread = new Thread(Attack0);
            thread.Start();
        }

        private async void Attack0()
        {
            var old = MainForm.kh2.ReadByte(0x2A20E20);
            MainForm.mem.FreezeValue($"KINGDOM HEARTS II FINAL MIX.exe+2A20E20", "byte", "0x00");
            await Task.Delay((int)Duration);
            MainForm.mem.UnfreezeValue($"KINGDOM HEARTS II FINAL MIX.exe+2A20E20");
            MainForm.kh2.WriteByte(0x2A20E20, old);
            MainForm.client.SendMessage(MainForm.channel, $"'{RewardName}' wurde beendet.");
        }
    }
}
