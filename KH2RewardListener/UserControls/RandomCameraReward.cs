using KH2RewardListener.Memory;
using MadMilkman.Ini;

namespace KH2RewardListener.UserControls
{
    public partial class RandomCameraReward : UserControl
    {
        Random random = new Random();
        public RandomCameraReward()
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
                RewardName = ini.Sections["RandomCamera"].Keys["RewardName"].Value;
                ChatMessage = ini.Sections["RandomCamera"].Keys["ChatMessage"].Value;
                Duration = int.Parse(ini.Sections["RandomCamera"].Keys["Duration"].Value);
            }
            catch
            {
                RewardName = "Random Camera";
                ChatMessage = "Camera angle has been changed to [Type] for [Duration] seconds.";
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
            if (!ini.Sections.Contains("RandomCamera"))
            {
                var section = ini.Sections.Add("RandomCamera");
                var reward = section.Keys.Add("RewardName", $"{RewardName}");
                var message = section.Keys.Add("ChatMessage", $"{ChatMessage}");
                var duration = section.Keys.Add("Duration", $"{Duration}");
            }
            else
            {
                ini.Sections["RandomCamera"].Keys["RewardName"].Value = RewardName;
                ini.Sections["RandomCamera"].Keys["ChatMessage"].Value = ChatMessage;
                ini.Sections["RandomCamera"].Keys["Duration"].Value = Duration.ToString();
            }
            ini.Save("config_rewards.ini");
        }

        public void DoAction()
        {
            Thread thread = new Thread(RandomCamera);
            thread.Start();
        }

        private async void RandomCamera()
        {
            int value = random.Next(1, 4);
            var item = await CameraTypes.GetCameraType(value);
            var duration = Duration / 1000;
            var chatmessage = ChatMessage
                .Replace("[Type]", item[0])
                .Replace("[Duration]", duration.ToString());
            MainForm.client.SendMessage(MainForm.channel, chatmessage);
            MainForm.mem.FreezeValue($"KINGDOM HEARTS II FINAL MIX.exe+0x716A58", "byte", $"{item[1]}");
            await Task.Delay((int)Duration);
            MainForm.mem.UnfreezeValue($"KINGDOM HEARTS II FINAL MIX.exe+0x716A58");
            MainForm.mem.WriteMemory($"KINGDOM HEARTS II FINAL MIX.exe+0x716A58", "byte", "0");
            MainForm.client.SendMessage(MainForm.channel, $"'{RewardName}' has ended.");
        }
    }
}
