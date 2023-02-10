using Memory;
using Newtonsoft.Json;

namespace KH2RewardListener.Rewards
{
    public class RandomStrength
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
            string rewardjson = File.ReadAllText("Rewards/RandomStrength.json");
            dynamic reward = JsonConvert.DeserializeObject(rewardjson);

            string chatmessage = reward["Reward"]["Message"];
            string endmessage = reward["Reward"]["EndMessage"];
            string duration = reward["Reward"]["Duration"];
            int counter = int.Parse(duration);

            var old = mem.ReadByte($"{process}.exe+0x2A20E20");

            int value = random.Next(0, 256);
            if (value > 255)
                value = 255;

            MainForm.client.SendMessage(MainForm.channel, chatmessage.Replace("[Duration]", counter.ToString()).Replace("[Amount]", value.ToString()));
            new Thread(() =>
            {
                while (counter > 0)
                {
                    int _isPaused = mem.ReadByte($"{process}.exe+AB9054");
                    int _cantMove = mem.ReadByte($"{process}.exe+2A148E8");
                    int _isWorldMap = mem.ReadByte($"{process}.exe+714DB8");
                    int _isMapLoaded = mem.ReadByte($"{process}.exe+9B80D0");
                    if (_isPaused > 0 || _cantMove > 0 || _isWorldMap == 15 || _isMapLoaded == 0)
                    {
                        Thread.Sleep(1000);
                        continue;
                    }

                    mem.WriteMemory($"{process}.exe+0x2A20E20", "byte", $"0x{value.ToString("X")}");
                    Thread.Sleep(1000);
                    counter--;
                }
                mem.WriteMemory($"{process}.exe+0x2A20E20", "byte", $"0x{old.ToString("X")}");
                MainForm.client.SendMessage(MainForm.channel, endmessage);
            }).Start();
        }
    }
}
