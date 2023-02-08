using Memory;
using Newtonsoft.Json;

namespace KH2RewardListener.Rewards
{
    public class AutoAttack
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
            string rewardjson = File.ReadAllText("Rewards/AutoAttack.json");
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
                    int _isPaused = mem.ReadByte($"{process}.exe+AB9054");
                    if (_isPaused == 1)
                    {
                        Thread.Sleep(1000);
                        continue;
                    }
                    mem.WriteMemory($"{process}.exe+0x2A5A096", "byte", "0x01");
                    Thread.Sleep(1000);
                    counter--;
                }
                mem.WriteMemory($"{process}.exe+0x2A5A096", "byte", "0x00");
                MainForm.client.SendMessage(MainForm.channel, endmessage);
            }).Start();
        }
    }
}
