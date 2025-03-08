using KH2RewardListener.Memory;
using Newtonsoft.Json;
using System.Diagnostics;

namespace KH2RewardListener.Rewards
{
    public class DriveMaster
    {
        static string process = "KINGDOM HEARTS II FINAL MIX";
        private static void GetPID()
        {
            try
            {
                var _myProcess = Process.GetProcessesByName(process)[0];
                if (_myProcess.Id > 0)
                    Hypervisor.AttachProcess(_myProcess);
            }
            catch
            {
                // Ignore exception
            }
        }

        public static void DoAction()
        {
            GetPID();
            string rewardjson = File.ReadAllText("Rewards/DriveMaster.json");
            dynamic reward = JsonConvert.DeserializeObject(rewardjson);

            string chatmessage = reward["Reward"]["Message"];

            int counter = 1;

            MainForm.client.SendMessage(MainForm.channel, chatmessage);
            int _isForm = Hypervisor.Read<byte>(0x9ACDD4);
            int _isSummon = Hypervisor.Read<byte>(0x9ACDD5);
            int _isLimit = Hypervisor.Read<byte>(0x2A10980);
            if (_isForm > 0 || _isSummon > 0 || _isLimit > 0)
                MainForm.client.SendMessage(MainForm.channel, "The reward has been added to the queue because the player is either in a form, summon or limit!");

            new Thread(() =>
            {
                while (counter > 0)
                {
                    int _isPaused = Hypervisor.Read<byte>(0xABB854);
                    int _isForm = Hypervisor.Read<byte>(0x9ACDD4);
                    int _isSummon = Hypervisor.Read<byte>(0x9ACDD5);
                    int _cantMove = Hypervisor.Read<byte>(0x2A171E8);
                    int _isMapLoaded = Hypervisor.Read<byte>(0x9BA8D0);
                    int _isWorldMap = Hypervisor.Read<byte>(0x717008);
                    int _isLimit = Hypervisor.Read<byte>(0x2A10980);
                    if (_isPaused > 0 || _isForm > 0 || _isSummon > 0 || _cantMove > 0 || _isWorldMap == 15 || _isMapLoaded == 0 || _isLimit > 0)
                    {
                        Thread.Sleep(3500);
                        continue;
                    }
                    Thread.Sleep(500);
                    int CharCheck = Hypervisor.Read<short>(0x2A25300);
                    if (CharCheck == UCMs.Sora || CharCheck == UCMs.Sora_SP || CharCheck == UCMs.Sora_XMAS || CharCheck == UCMs.Sora_XMAS2 || CharCheck == UCMs.Sora_TR || CharCheck == UCMs.Sora_Halloween)
                    {
                        Hypervisor.Write<byte>(0x2A5C996, [0x04, 0x00, 0x04, 0x00]);
                        Thread.Sleep(69);
                        Hypervisor.Write<byte>(0x2A5C996, [0x00, 0x00, 0x00, 0x00]);
                    }
                    else
                    {
                        MainForm.client.SendMessage(MainForm.channel, "The player needs to be Sora for that.");
                        return;
                    }
                    counter--;
                }
            }).Start();
        }
    }
}