using KH2RewardListener.Memory;
using Memory;
using Newtonsoft.Json;

namespace KH2RewardListener.Rewards
{
    public class RandomMunny
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
            string rewardjson = File.ReadAllText("Rewards/RandomMunny.json");
            dynamic reward = JsonConvert.DeserializeObject(rewardjson);

            string chatmessage = reward["Reward"]["Message"];
            //string rangestart_get = reward["Reward"]["RangeStart"];
            //string rangeend_get = reward["Reward"]["RangeEnd"];

            int counter = 1;

            //int start = int.Parse(rangestart_get);
            //int end = int.Parse(rangeend_get) + 1;

            int value = random.Next(-500, 2000);
            //int amount = random.Next(start, end);

            MainForm.client.SendMessage(MainForm.channel, chatmessage.Replace("[Amount]", $"{value}"));

            new Thread(() =>
            {
                while (counter > 0)
                {
                    //int _isPaused = mem.ReadByte($"{process}.exe+AB9054");
                    //int _cantMove = mem.ReadByte($"{process}.exe+2A148E8");
                    //int _isWorldMap = mem.ReadByte($"{process}.exe+714DB8");
                    int _isMapLoaded = mem.ReadByte($"{process}.exe+9B80D0");
                    if (_isMapLoaded == 0)
                    {
                        Thread.Sleep(1000);
                        continue;
                    }
                    var currentamount = mem.ReadInt($"{process}.exe+9A94F0");
                    var count = currentamount + value;
                    if (count > 999999)
                        count = 999999;
                    else if (count < 0)
                        count = 0;
                    mem.WriteMemory($"{process}.exe+9A94F0", "int", $"{count}");
                    counter--;
                }
            }).Start();
        }
    }
}
