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

            int start = int.Parse(rangestart_get);
            int end = int.Parse(rangeend_get) + 1;

            int value = random.Next(1, 15);
            var item = Consumables.GetConsumable(value);
            int amount = random.Next(start, end);

            MainForm.client.SendMessage(MainForm.channel, chatmessage.Replace("[Item]", item[0]).Replace("[Amount]", $"{amount}"));
            var currentamount = mem.ReadByte($"{process}.exe+{item[1]}");
            var count = currentamount + amount;
            if (count > 255)
                count = 255;
            mem.WriteMemory($"{process}.exe+{item[1]}", "byte", $"0x{count.ToString("X")}");
        }
    }
}
