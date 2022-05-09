using MadMilkman.Ini;

namespace KH2RewardListener.UserControls
{
    public partial class FOVReward : UserControl
    {
        public FOVReward()
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
                RewardName = ini.Sections["FOV"].Keys["RewardName"].Value;
                ChatMessage = ini.Sections["FOV"].Keys["ChatMessage"].Value;
                Duration = int.Parse(ini.Sections["FOV"].Keys["Duration"].Value);
            }
            catch
            {
                RewardName = "Field of View";
                ChatMessage = "The field of view got increased for [Duration] seconds.";
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
            if (!ini.Sections.Contains("FOV"))
            {
                var section = ini.Sections.Add("FOV");
                var reward = section.Keys.Add("RewardName", $"{RewardName}");
                var message = section.Keys.Add("ChatMessage", $"{ChatMessage}");
                var duration = section.Keys.Add("Duration", $"{Duration}");
            }
            else
            {
                ini.Sections["FOV"].Keys["RewardName"].Value = RewardName;
                ini.Sections["FOV"].Keys["ChatMessage"].Value = ChatMessage;
                ini.Sections["FOV"].Keys["Duration"].Value = Duration.ToString();
            }
            ini.Save("config_rewards.ini");
        }

        public void DoAction()
        {
            var duration = Duration / 1000;
            var chatmessage = ChatMessage
                .Replace("[Duration]", duration.ToString());
            MainForm.client.SendMessage(MainForm.channel, chatmessage);
            Thread thread = new Thread(FOV);
            thread.Start();
        }

        private async void FOV()
        {
            MainForm.kh2.WriteFloat(0x47435D, 5);
            await Task.Delay((int)Duration);
            MainForm.kh2.WriteFloat(0x47435D, 1);
            MainForm.client.SendMessage(MainForm.channel, $"'{RewardName}' has ended.");
        }
    }
}
