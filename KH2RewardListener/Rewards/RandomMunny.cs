using Newtonsoft.Json;
using System.Diagnostics;

namespace KH2RewardListener.Rewards
{
    public class RandomMunny
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
            string rewardjson = File.ReadAllText("Rewards/RandomMunny.json");
            dynamic reward = JsonConvert.DeserializeObject(rewardjson);

            string chatmessage = reward["Reward"]["Message"];
            //string rangestart_get = reward["Reward"]["RangeStart"];
            //string rangeend_get = reward["Reward"]["RangeEnd"];

            int counter = 1;

            //int start = int.Parse(rangestart_get);
            //int end = int.Parse(rangeend_get) + 1;

            int value = random.Next(-1000, 2000);
            //int amount = random.Next(start, end);

            MainForm.client.SendMessage(MainForm.channel, chatmessage.Replace("[Amount]", $"{value}"));

            new Thread(() =>
            {
                while (counter > 0)
                {
                    //int _isPaused = mem.ReadByte($"{process}.exe+ABB854");
                    //int _cantMove = mem.ReadByte($"{process}.exe+2A16310");
                    //int _isWorldMap = mem.ReadByte($"{process}.exe+717008");
                    int _isMapLoaded = Hypervisor.Read<byte>(0x9BA8D0);
                    if (_isMapLoaded == 0)
                    {
                        Thread.Sleep(1000);
                        continue;
                    }
                    var currentamount = Hypervisor.Read<int>(0x9ABCF0);
                    var count = currentamount + value;
                    if (count > 999999)
                        count = 999999;
                    else if (count < 0)
                        count = 0;
                    Hypervisor.Write<int>(0x9ABCF0, count);
                    counter--;
                }
            }).Start();
        }
    }
}
