using Memory;
using Newtonsoft.Json;

namespace KH2RewardListener.Rewards
{
    public class SoftReset
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
            string rewardjson = File.ReadAllText("Rewards/SoftReset.json");
            dynamic reward = JsonConvert.DeserializeObject(rewardjson);

            string chatmessage = reward["Reward"]["Message"];

            MainForm.client.SendMessage(MainForm.channel, chatmessage);
            mem.WriteMemory($"{process}.exe+AB845A", "byte", $"0x01");
            mem.WriteMemory($"{process}.exe+751310", "int", $"1");
            mem.WriteMemory($"{process}.exe+2AE3478", "byte", $"0x00");
        }
    }
}
