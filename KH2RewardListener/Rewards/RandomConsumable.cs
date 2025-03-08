using KH2RewardListener.Memory;
using Memory;
using Newtonsoft.Json;

namespace KH2RewardListener.Rewards
{
    public class RandomConsumable
    {
        static Mem mem = new Mem();
        static string process = "KINGDOM HEARTS II FINAL MIX";
        private static void GetPID()
        {
            int pid = mem.GetProcIdFromName(process);
            bool openProc = false;

            if (pid > 0) openProc = mem.OpenProcess(pid);
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
                    //int _isPaused = mem.ReadByte($"{process}.exe+ABB854");
                    //int _cantMove = mem.ReadByte($"{process}.exe+2A171E8");
                    //int _isWorldMap = mem.ReadByte($"{process}.exe+717008");
                    int _isMapLoaded = mem.ReadByte($"{process}.exe+9BA8D0");
                    if (_isMapLoaded == 0)
                    {
                        Thread.Sleep(1000);
                        continue;
                    }
                    var currentamount = mem.ReadByte($"{process}.exe+{item.Item2}");
                    var count = currentamount + amount;
                    if (count > 99)
                        count = 99;
                    if (count < 0)
                        count = 0;
                    mem.WriteMemory($"{process}.exe+{item.Item2}", "byte", $"0x{count.ToString("X")}");
                    counter--;
                }
            }).Start();
        }
    }
}
