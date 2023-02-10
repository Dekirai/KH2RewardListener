using Memory;
using Newtonsoft.Json;

namespace KH2RewardListener.Rewards
{
    public class RefillHP
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
            string rewardjson = File.ReadAllText("Rewards/RefillHP.json");
            dynamic reward = JsonConvert.DeserializeObject(rewardjson);

            string chatmessage = reward["Reward"]["Message"];

            int counter = 1;
            MainForm.client.SendMessage(MainForm.channel, chatmessage);
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
                    mem.WriteMemory($"{process}.exe+2A20C98", "int", $"{mem.ReadInt($"{process}.exe+2A20C9C")}");
                    counter--;
                }
            }).Start();
        }
    }
}
