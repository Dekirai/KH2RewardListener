﻿//using Memory;
//using Newtonsoft.Json;

//namespace KH2RewardListener.Rewards
//{
//    public class MovementSpeed
//    {
//        static Mem mem = new Mem();
//        static string process = "KINGDOM HEARTS II FINAL MIX";
//        private static void GetPID()
//        {
//            int pid = mem.GetProcIdFromName(process);
//            bool openProc = false;

//            if (pid > 0) openProc = mem.OpenProcess(pid);
//        }

//        public static void DoAction()
//        {
//            GetPID();
//            string rewardjson = File.ReadAllText("Rewards/MovementSpeed.json");
//            dynamic reward = JsonConvert.DeserializeObject(rewardjson);

//            string chatmessage = reward["Reward"]["Message"];
//            string endmessage = reward["Reward"]["EndMessage"];
//            string duration = reward["Reward"]["Duration"];
//            int counter = int.Parse(duration);
//            MainForm.client.SendMessage(MainForm.channel, chatmessage.Replace("[Duration]", counter.ToString()));
//            new Thread(() =>
//            {
//                while (counter > 0)
//                {
//                    int _isPaused = mem.ReadByte($"{process}.exe+ABB854");
//                    int _cantMove = mem.ReadByte($"{process}.exe+2A16310");
//                    int _isWorldMap = mem.ReadByte($"{process}.exe+717008");
//                    int _isMapLoaded = mem.ReadByte($"{process}.exe+9BA8D0");
//                    if (_isPaused > 0 || _cantMove > 0 || _isWorldMap == 15 || _isMapLoaded == 0)
//                    {
//                        Thread.Sleep(1000);
//                        continue;
//                    }
//                    mem.WriteMemory($"{process}.exe+00716A60,0x128", "float", "60");
//                    mem.WriteMemory($"{process}.exe+00716A60,0x12C", "float", "60");
//                    Thread.Sleep(1000);
//                    counter--;
//                }
//                mem.WriteMemory($"{process}.exe+00716A60,0x128", "float", "2");
//                mem.WriteMemory($"{process}.exe+00716A60,0x12C", "float", "8");
//                MainForm.client.SendMessage(MainForm.channel, endmessage);
//            }).Start();
//        }
//    }
//}
