using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Policy;

namespace KH2RewardListener.Rewards
{
    public class PlayerSize
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
            Random random = new Random();
            string rewardjson = File.ReadAllText("Rewards/PlayerSize.json");
            dynamic reward = JsonConvert.DeserializeObject(rewardjson);

            string chatmessage = reward["Reward"]["Message"];
            string endmessage = reward["Reward"]["EndMessage"];
            string duration = reward["Reward"]["Duration"];
            int counter = int.Parse(duration);

            string size = "";
            if (MainForm.userinput == "small")
                size = "Small";
            else if (MainForm.userinput == "big")
                size = "Big";
            else
            {
                MainForm.client.SendMessage(MainForm.channel, "Input wasn't valid. You just wasted some points.");
                return;
            }
            MainForm.client.SendMessage(MainForm.channel, chatmessage.Replace("[Duration]", counter.ToString()).Replace("[Type]", size));
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
                    if (size == "Small")
                    {
                        Hypervisor.Write<float>(Hypervisor.GetPointer64(0x718CB0, [0x30]), 0.5f, true);
                        Hypervisor.Write<float>(Hypervisor.GetPointer64(0x718CB0, [0x34]), 0.5f, true);
                        Hypervisor.Write<float>(Hypervisor.GetPointer64(0x718CB0, [0x38]), 0.5f, true);
                    }
                    else if (size == "Big")
                    {
                        Hypervisor.Write<float>(Hypervisor.GetPointer64(0x718CB0, [0x30]), 3f, true);
                        Hypervisor.Write<float>(Hypervisor.GetPointer64(0x718CB0, [0x34]), 3f, true);
                        Hypervisor.Write<float>(Hypervisor.GetPointer64(0x718CB0, [0x38]), 3f, true);
                    }
                    Thread.Sleep(1000);
                    counter--;
                }

                Hypervisor.Write<float>(Hypervisor.GetPointer64(0x718CB0, [0x30]), 1f, true);
                Hypervisor.Write<float>(Hypervisor.GetPointer64(0x718CB0, [0x34]), 1f, true);
                Hypervisor.Write<float>(Hypervisor.GetPointer64(0x718CB0, [0x38]), 1f, true);
                MainForm.client.SendMessage(MainForm.channel, endmessage);
            }).Start();
        }
    }
}
