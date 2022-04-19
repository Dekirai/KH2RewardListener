using MadMilkman.Ini;

namespace KH2RewardListener.UserControls
{
    public partial class AutoAttackReward : UserControl
    {
        public AutoAttackReward()
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
                RewardName = ini.Sections["AutoAttack"].Keys["RewardName"].Value;
                ChatMessage = ini.Sections["AutoAttack"].Keys["ChatMessage"].Value;
                Duration = int.Parse(ini.Sections["AutoAttack"].Keys["Duration"].Value);
            }
            catch
            {
                RewardName = "Auto-Attack";
                ChatMessage = "Sora is now attacking continuously for [Duration] seconds.";
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
            if (!ini.Sections.Contains("AutoAttack"))
            {
                var section = ini.Sections.Add("AutoAttack");
                var reward = section.Keys.Add("RewardName", $"{RewardName}");
                var message = section.Keys.Add("ChatMessage", $"{ChatMessage}");
                var duration = section.Keys.Add("Duration", $"{Duration}");
            }
            else
            {
                ini.Sections["AutoAttack"].Keys["RewardName"].Value = RewardName;
                ini.Sections["AutoAttack"].Keys["ChatMessage"].Value = ChatMessage;
                ini.Sections["AutoAttack"].Keys["Duration"].Value = Duration.ToString();
            }
            ini.Save("config_rewards.ini");
        }

        public void DoAction()
        {
            var duration = Duration / 1000;
            var chatmessage = ChatMessage
                .Replace("[Duration]", duration.ToString());
            MainForm.client.SendMessage(MainForm.channel, chatmessage);
            Thread thread = new Thread(AutoAttack);
            thread.Start();
        }

        private async void AutoAttack()
        {
            MainForm.kh2.WriteByte(0x2A5A096, 0x01);
            await Task.Delay((int)Duration);
            MainForm.kh2.WriteByte(0x2A5A096, 0x00);
            MainForm.client.SendMessage(MainForm.channel, $"'{RewardName}' wurde beendet.");
        }
    }
}
