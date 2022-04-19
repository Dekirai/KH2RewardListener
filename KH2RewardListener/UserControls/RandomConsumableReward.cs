using KH2RewardListener.Memory;
using MadMilkman.Ini;

namespace KH2RewardListener.UserControls
{
    public partial class RandomConsumableReward : UserControl
    {
        Random random = new Random();
        public RandomConsumableReward()
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
                RewardName = ini.Sections["RandomConsumable"].Keys["RewardName"].Value;
                ChatMessage = ini.Sections["RandomConsumable"].Keys["ChatMessage"].Value;
            }
            catch
            {
                RewardName = "Random Consumable";
                ChatMessage = "Sora received [Item] x[Amount].";
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
            if (!ini.Sections.Contains("RandomConsumable"))
            {
                var section = ini.Sections.Add("RandomConsumable");
                var reward = section.Keys.Add("RewardName", $"{RewardName}");
                var message = section.Keys.Add("ChatMessage", $"{ChatMessage}");
            }
            else
            {
                ini.Sections["RandomConsumable"].Keys["RewardName"].Value = RewardName;
                ini.Sections["RandomConsumable"].Keys["ChatMessage"].Value = ChatMessage;
            }
            ini.Save("config_rewards.ini");
        }

        public async void DoAction()
        {
            int value = random.Next(1, 15);
            var item = await Consumables.GetConsumable(value);
            int amount = random.Next(1, 6);
            var chatmessage = ChatMessage
                .Replace("[Item]", item[0])
                .Replace("[Amount]", $"{amount}");
            MainForm.client.SendMessage(MainForm.channel, chatmessage);
            var currentamount = MainForm.mem.ReadByte($"KINGDOM HEARTS II FINAL MIX.exe+{item[1]}");
            MainForm.mem.WriteMemory($"KINGDOM HEARTS II FINAL MIX.exe+{item[1]}", "byte", $"{currentamount + amount}");
        }
    }
}
