using KH2RewardListener.Memory;
using Newtonsoft.Json;
using System.Diagnostics;

namespace KH2RewardListener.Rewards
{
    public class RandomConsumable
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
            string rewardjson = File.ReadAllText("Rewards/RandomConsumable.json");
            dynamic reward = JsonConvert.DeserializeObject(rewardjson);

            string chatmessage = reward["Reward"]["Message"];
            string rangestart_get = reward["Reward"]["RangeStart"];
            string rangeend_get = reward["Reward"]["RangeEnd"];

            int counter = 1;

            int start = int.Parse(rangestart_get);
            int end = int.Parse(rangeend_get) + 1;

            int value = random.Next(1, 15);
            var item = Consumables.GetConsumable(value);
            int amount = random.Next(start, end);

            MainForm.client.SendMessage(MainForm.channel, chatmessage.Replace("[Item]", item.Item1).Replace("[Amount]", $"{amount}"));

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
                    var currentamount = Hypervisor.Read<byte>(item.Item2);
                    var count = currentamount + amount;
                    if (count > 99)
                        count = 99;
                    if (count < 0)
                        count = 0;
                    Hypervisor.Write<byte>(item.Item2, (byte)count);
                    counter--;
                }
            }).Start();
        }
    }
}
