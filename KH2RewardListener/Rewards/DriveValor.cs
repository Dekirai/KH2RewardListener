using KH2RewardListener.Memory;
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

            MainForm.client.SendMessage(MainForm.channel, chatmessage);
            int _isForm = mem.ReadByte($"{process}.exe+9AA5D4");
            int _isSummon = mem.ReadByte($"{process}.exe+9AA5D5");
            int _isLimit = mem.ReadByte($"{process}.exe+2A0E080");
            if (_isForm > 0 || _isSummon > 0 || _isLimit > 0)
                MainForm.client.SendMessage(MainForm.channel, "The reward has been added to the queue because the player is either in a form, summon or limit!");

            new Thread(() =>
            {
                while (counter > 0)
                {
                    int _isPaused = mem.ReadByte($"{process}.exe+AB9054");
                    int _isForm = mem.ReadByte($"{process}.exe+9AA5D4");
                    int _isSummon = mem.ReadByte($"{process}.exe+9AA5D5");
                    int _cantMove = mem.ReadByte($"{process}.exe+2A148E8");
                    int _isMapLoaded = mem.ReadByte($"{process}.exe+9B80D0");
                    int _isWorldMap = mem.ReadByte($"{process}.exe+714DB8");
                    int _isLimit = mem.ReadByte($"{process}.exe+2A0E080");
                    if (_isPaused > 0 || _isForm > 0 || _isSummon > 0 || _cantMove > 0 || _isWorldMap == 15 || _isMapLoaded == 0 || _isLimit > 0)
                    {
                        Thread.Sleep(3500);
                        continue;
                    }
                    var keyblade = mem.ReadByte($"{process}.exe+9AA3A4");
                    if (keyblade == 0)
                        mem.WriteMemory($"{process}.exe+9AA3A4", "bytes", "0x29 0x00");
                    Thread.Sleep(500);
                    var CharCheck = mem.Read2Byte($"{process}.exe+2A22A00");
                    if (CharCheck == UCMs.Sora || CharCheck == UCMs.Sora_SP || CharCheck == UCMs.Sora_XMAS || CharCheck == UCMs.Sora_XMAS2 || CharCheck == UCMs.Sora_TR || CharCheck == UCMs.Sora_Halloween)
                    {
                        mem.WriteMemory($"{process}.exe+2A5A096", "bytes", "0x04 0x00 0x01 0x00");
                        Thread.Sleep(400);
                        mem.WriteMemory($"{process}.exe+2A5A096", "bytes", "0x00 0x00 0x00 0x00");
                        Thread.Sleep(1000);
                        BlockRevert();
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

        private static void BlockRevert()
        {

            int counter = 1;

            new Thread(() =>
            {
                while (counter > 0)
                {
                    float _driveRemaining = mem.ReadFloat($"{process}.exe+2A20E4C");
                    int _isForm = mem.ReadByte($"{process}.exe+9AA5D4");
                    if (_isForm > 0)
                        mem.WriteMemory($"{process}.exe+2A5A186", "byte", "0x00");
                    if (_driveRemaining > 0)
                    {
                        mem.WriteMemory($"{process}.exe+2A5A186", "byte", "0x00");
                        Thread.Sleep(1000);
                        continue;
                    }
                    mem.WriteMemory($"{process}.exe+2A5A186", "byte", "0x05");
                    counter--;
                }
            }).Start();
        }
    }
}