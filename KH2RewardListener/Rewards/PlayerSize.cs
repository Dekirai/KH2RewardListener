using Memory;
using Newtonsoft.Json;
using System.Security.Policy;

namespace KH2RewardListener.Rewards
{
    public class PlayerSize
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
            string rewardjson = File.ReadAllText("Rewards/PlayerSize.json");
            dynamic reward = JsonConvert.DeserializeObject(rewardjson);

            string chatmessage = reward["Reward"]["Message"];
            string endmessage = reward["Reward"]["EndMessage"];
            string duration = reward["Reward"]["Duration"];
            int counter = int.Parse(duration);

            var old = mem.ReadByte($"{process}.exe+0x2A20E20");

            string size = "";
            if (MainForm.userinput == "small")
                size = "Small";
            else if (MainForm.userinput == "big")
                size = "Big";
            else
            {
                MainForm.client.SendMessage(MainForm.channel, "Input wasn't valid. You just wasted some points.");
                return;
            }
            MainForm.client.SendMessage(MainForm.channel, chatmessage.Replace("[Duration]", counter.ToString()).Replace("[Type]", size));
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
                    if (size == "Small")
                        mem.FreezeValue($"{process}.exe+0xABA7E8,0x3C", "float", $"0.5");
                    else if (size == "Big")
                        mem.FreezeValue($"{process}.exe+0xABA7E8,0x3C", "float", $"2");
                    Thread.Sleep(1000);
                    counter--;
                }
                mem.UnfreezeValue($"{process}.exe+0xABA7E8,0x3C");
                mem.WriteMemory($"{process}.exe+0xABA7E8,0x3C", "float", $"1");
                MainForm.client.SendMessage(MainForm.channel, endmessage);
            }).Start();
        }
    }
}
