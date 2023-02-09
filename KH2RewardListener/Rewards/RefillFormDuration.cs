using Memory;
using Newtonsoft.Json;

namespace KH2RewardListener.Rewards
{
    public class RefillFormDuration
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
            string rewardjson = File.ReadAllText("Rewards/RefillFormDuration.json");
            dynamic reward = JsonConvert.DeserializeObject(rewardjson);

            string chatmessage = reward["Reward"]["Message"];

            MainForm.client.SendMessage(MainForm.channel, chatmessage);
            mem.WriteMemory($"{process}.exe+2A20E4C", "float", "6000");
        }
    }
}
