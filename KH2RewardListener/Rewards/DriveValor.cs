using Memory;
using Newtonsoft.Json;

namespace KH2RewardListener.Rewards
{
    public class DriveValor
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
            string rewardjson = File.ReadAllText("Rewards/DriveValor.json");
            dynamic reward = JsonConvert.DeserializeObject(rewardjson);

            string chatmessage = reward["Reward"]["Message"];

            int counter = 1;
            int _isForm = mem.ReadByte($"{process}.exe+9AA5D4");

            MainForm.client.SendMessage(MainForm.channel, chatmessage);
            if (_isForm > 0)
                MainForm.client.SendMessage(MainForm.channel, "The reward has been added to the queue because the player is already in a form!");

            new Thread(() =>
            {
                while (counter > 0)
                {
                    int _isPaused = mem.ReadByte($"{process}.exe+AB9054");
                    int _isForm = mem.ReadByte($"{process}.exe+9AA5D4");
                    int _cantMove = mem.ReadByte($"{process}.exe+2A148E8");
                    int _isMapLoaded = mem.ReadByte($"{process}.exe+9B80D0");
                    int _isWorldMap = mem.ReadByte($"{process}.exe+714DB8");
                    if (_isPaused > 0 || _isForm > 0 || _cantMove > 0 || _isWorldMap == 15 || _isMapLoaded == 0)
                    {
                        Thread.Sleep(3500);
                        continue;
                    }
                    var keyblade = mem.ReadByte($"{process}.exe+9AA3A4");
                    if (keyblade == 0)
                        mem.WriteMemory($"{process}.exe+9AA3A4", "bytes", "0x29 0x00");
                    Thread.Sleep(500);
                    var CharCheck = mem.Read2Byte($"{process}.exe+2A22A00");
                    if (CharCheck == 0x0054 || CharCheck == 0xB502 || CharCheck == 0x0656 || CharCheck == 0x0657 || CharCheck == 0x0955)
                    {
                        mem.WriteMemory($"{process}.exe+2A5A096", "bytes", "0x04 0x00 0x01 0x00");
                        Thread.Sleep(400);
                        mem.WriteMemory($"{process}.exe+2A5A096", "bytes", "0x00 0x00 0x00 0x00");
                    }
                    else
                    {
                        MainForm.client.SendMessage(MainForm.channel, "The player needs to be Sora for that.");
                        return;
                    }
                    counter--;
                }
            }).Start();
        }
    }
}
