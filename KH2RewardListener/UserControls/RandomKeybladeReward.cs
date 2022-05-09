using KH2RewardListener.Memory;
using MadMilkman.Ini;

namespace KH2RewardListener.UserControls
{
    public partial class RandomKeybladeReward : UserControl
    {
        Random random = new Random();
        public RandomKeybladeReward()
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
                RewardName = ini.Sections["RandomKeyblade"].Keys["RewardName"].Value;
                ChatMessage = ini.Sections["RandomKeyblade"].Keys["ChatMessage"].Value;
            }
            catch
            {
                RewardName = "Random Keyblade";
                ChatMessage = "Sora's current Keyblade got replaced by [Item].";
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

        private void bt_Save_Click(object sender, EventArgs e)
        {
            if (tb_rewardname.Text.Length == 0)
            {
                MessageBox.Show("Error", "Please enter a valid reward name!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var ini = new IniFile();
            ini.Load(Environment.CurrentDirectory + @"\config_rewards.ini");
            if (!ini.Sections.Contains("RandomKeyblade"))
            {
                var section = ini.Sections.Add("RandomKeyblade");
                var reward = section.Keys.Add("RewardName", $"{RewardName}");
                var message = section.Keys.Add("ChatMessage", $"{ChatMessage}");
            }
            else
            {
                ini.Sections["RandomKeyblade"].Keys["RewardName"].Value = RewardName;
                ini.Sections["RandomKeyblade"].Keys["ChatMessage"].Value = ChatMessage;
            }
            ini.Save("config_rewards.ini");
        }

        public async void DoAction()
        {
            int value = random.Next(1, 28);
            var item = await KeybladeIDs.GetKeybladeID(value);
            int amount = random.Next(1, 6);
            var chatmessage = ChatMessage
                        .Replace("[Item]", item[0]);
            MainForm.client.SendMessage(MainForm.channel, chatmessage);
            MainForm.mem.WriteMemory($"KINGDOM HEARTS II FINAL MIX.exe+0x9A95A0", "int", $"{item[1]}");
        }
    }
}
