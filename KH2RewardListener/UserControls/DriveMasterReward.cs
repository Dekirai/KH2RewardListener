using MadMilkman.Ini;

namespace KH2RewardListener.UserControls
{
    public partial class DriveMasterReward : UserControl
    {
        public DriveMasterReward()
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
                RewardName = ini.Sections["DriveMaster"].Keys["RewardName"].Value;
                ChatMessage = ini.Sections["DriveMaster"].Keys["ChatMessage"].Value;
            }
            catch
            {
                RewardName = "Force Master";
                ChatMessage = "Sora got forced into the Master Form.";
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
            if (!ini.Sections.Contains("DriveMaster"))
            {
                var section = ini.Sections.Add("DriveMaster");
                var reward = section.Keys.Add("RewardName", $"{RewardName}");
                var message = section.Keys.Add("ChatMessage", $"{ChatMessage}");
            }
            else
            {
                ini.Sections["DriveMaster"].Keys["RewardName"].Value = RewardName;
                ini.Sections["DriveMaster"].Keys["ChatMessage"].Value = ChatMessage;
            }
            ini.Save("config_rewards.ini");
        }

        public void DoAction()
        {
            bool hasKeyblade = false;
            var keyblade = MainForm.kh2.ReadByte(0x9AA44C);
            if (keyblade == 0)
                MainForm.kh2.Write2Bytes(0x9AA44C, 0x29, 0x00);
            else
                hasKeyblade = true;
            MainForm.client.SendMessage(MainForm.channel, ChatMessage);
            MainForm.mem.WriteMemory("KINGDOM HEARTS II FINAL MIX.exe+2A5A096", "bytes", "0x05 0x00 0x01 0x00"); //Revert incase we are in a form already
            Thread.Sleep(400);
            MainForm.mem.WriteMemory("KINGDOM HEARTS II FINAL MIX.exe+2A5A096", "bytes", "0x04 0x00 0x04 0x00");
            Thread.Sleep(400);
            MainForm.mem.WriteMemory("KINGDOM HEARTS II FINAL MIX.exe+2A5A096", "bytes", "0x00 0x00 0x00 0x00");
        }
    }
}
