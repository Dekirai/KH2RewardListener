using Newtonsoft.Json;
using System.Diagnostics;

namespace KH2RewardListener.Rewards
{
    public class EmptyMagic
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
            string rewardjson = File.ReadAllText("Rewards/EmptyMagic.json");
            dynamic reward = JsonConvert.DeserializeObject(rewardjson);

            string chatmessage = reward["Reward"]["Message"];

            int counter = 1;
            MainForm.client.SendMessage(MainForm.channel, chatmessage);
            new Thread(() =>
            {
                while (counter > 0)
                {
                    int _isMapLoaded = Hypervisor.Read<byte>(0x9BA8D0);
                    if (_isMapLoaded == 0)
                    {
                        Thread.Sleep(1000);
                        continue;
                    }
                    Hypervisor.Write<float>(0x2A23754, 3000);
                    Hypervisor.Write<float>(0x2A23758, 3000);
                    counter--;
                }
            }).Start();
        }
    }
}
