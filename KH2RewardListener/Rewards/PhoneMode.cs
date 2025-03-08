using Newtonsoft.Json;
using System.Diagnostics;

namespace KH2RewardListener.Rewards
{
    public class PhoneMode
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
            string rewardjson = File.ReadAllText("Rewards/Phonemode.json");
            dynamic reward = JsonConvert.DeserializeObject(rewardjson);

            string chatmessage = reward["Reward"]["Message"];
            string endmessage = reward["Reward"]["EndMessage"];
            string duration = reward["Reward"]["Duration"];
            int counter = int.Parse(duration);
            MainForm.client.SendMessage(MainForm.channel, chatmessage.Replace("[Duration]", counter.ToString()));
            new Thread(() =>
            {
                while (counter > 0)
                {
                    int _isPaused = Hypervisor.Read<byte>(0xABB854);
                    int _cantMove = Hypervisor.Read<byte>(0x2A171E8);
                    int _isWorldMap = Hypervisor.Read<byte>(0x717008);
                    int _isMapLoaded = Hypervisor.Read<byte>(0x9BA8D0);
                    if (_isPaused > 0 || _cantMove > 0 || _isWorldMap == 15 || _isMapLoaded == 0)
                    {
                        Thread.Sleep(1000);
                        continue;
                    }
                    Hypervisor.Write<float>(0x8A0990, 0.25f);
                    Thread.Sleep(1000);
                    counter--;
                }
                Hypervisor.Write<float>(0x8A0990, 1);
                MainForm.client.SendMessage(MainForm.channel, endmessage);
            }).Start();
        }
    }
}
