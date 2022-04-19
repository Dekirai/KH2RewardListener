﻿using MadMilkman.Ini;

namespace KH2RewardListener.UserControls
{
    public partial class BlindSightReward : UserControl
    {
        public BlindSightReward()
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
                RewardName = ini.Sections["BlindSight"].Keys["RewardName"].Value;
                ChatMessage = ini.Sections["BlindSight"].Keys["ChatMessage"].Value;
                Duration = int.Parse(ini.Sections["BlindSight"].Keys["Duration"].Value);
            }
            catch
            {
                RewardName = "Blind Sight";
                ChatMessage = "The streamer can't see anything but the HUD for [Duration] seconds.";
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
            if (!ini.Sections.Contains("BlindSight"))
            {
                var section = ini.Sections.Add("BlindSight");
                var reward = section.Keys.Add("RewardName", $"{RewardName}");
                var message = section.Keys.Add("ChatMessage", $"{ChatMessage}");
                var duration = section.Keys.Add("Duration", $"{Duration}");
            }
            else
            {
                ini.Sections["BlindSight"].Keys["RewardName"].Value = RewardName;
                ini.Sections["BlindSight"].Keys["ChatMessage"].Value = ChatMessage;
                ini.Sections["BlindSight"].Keys["Duration"].Value = Duration.ToString();
            }
            ini.Save("config_rewards.ini");
        }

        public void DoAction()
        {
            var duration = Duration / 1000;
            var chatmessage = ChatMessage
                .Replace("[Duration]", duration.ToString());
            MainForm.client.SendMessage(MainForm.channel, chatmessage);
            Thread thread = new Thread(BlindSight);
            thread.Start();
        }

        private async void BlindSight()
        {
            MainForm.kh2.WriteFloat(0x89E9F0, 0);
            await Task.Delay((int)Duration);
            MainForm.kh2.WriteFloat(0x89E9F0, 1);
            MainForm.client.SendMessage(MainForm.channel, $"'{RewardName}' wurde beendet.");
        }
    }
}
