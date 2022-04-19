using MadMilkman.Ini;

namespace KH2RewardListener.UserControls
{
    public partial class InvisibleModelsReward : UserControl
    {
        public InvisibleModelsReward()
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
                RewardName = ini.Sections["InvisibleModels"].Keys["RewardName"].Value;
                ChatMessage = ini.Sections["InvisibleModels"].Keys["ChatMessage"].Value;
                Duration = int.Parse(ini.Sections["InvisibleModels"].Keys["Duration"].Value);
            }
            catch
            {
                RewardName = "Invisible Models";
                ChatMessage = "All models are invisible for [Duration] seconds.";
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
            if (!ini.Sections.Contains("InvisibleModels"))
            {
                var section = ini.Sections.Add("InvisibleModels");
                var reward = section.Keys.Add("RewardName", $"{RewardName}");
                var message = section.Keys.Add("ChatMessage", $"{ChatMessage}");
                var duration = section.Keys.Add("Duration", $"{Duration}");
            }
            else
            {
                ini.Sections["InvisibleModels"].Keys["RewardName"].Value = RewardName;
                ini.Sections["InvisibleModels"].Keys["ChatMessage"].Value = ChatMessage;
                ini.Sections["InvisibleModels"].Keys["Duration"].Value = Duration.ToString();
            }
            ini.Save("config_rewards.ini");
        }

        public void DoAction()
        {
            var duration = Duration / 1000;
            var chatmessage = ChatMessage
                .Replace("[Duration]", duration.ToString());
            MainForm.client.SendMessage(MainForm.channel, chatmessage);
            Thread thread = new Thread(InvisibleModels);
            thread.Start();
        }

        private async void InvisibleModels()
        {
            MainForm.kh2.WriteFloat(0x3CA84C, 0);
            await Task.Delay((int)Duration);
            MainForm.kh2.WriteFloat(0x3CA84C, 1);
            MainForm.client.SendMessage(MainForm.channel, $"'{RewardName}' wurde beendet.");
        }
    }
}
