﻿using Newtonsoft.Json;
using System.Diagnostics;

namespace KH2RewardListener.Rewards
{
    public class SoftReset
    {
        static string process = "KINGDOM HEARTS II FINAL MIX";
        private static void GetPID()
        {
            try
            {
                var _myProcess = Process.GetProcessesByName(process)[0];
                if (_myProcess.Id > 0)
                    Hypervisor.AttachProcess(_myProcess);
            }
            catch
            {
                // Ignore exception
            }
        }

        public static void DoAction()
        {
            GetPID();
            string rewardjson = File.ReadAllText("Rewards/SoftReset.json");
            dynamic reward = JsonConvert.DeserializeObject(rewardjson);

            string chatmessage = reward["Reward"]["Message"];

            int counter = 1;
            MainForm.client.SendMessage(MainForm.channel, chatmessage);
            new Thread(() =>
            {
                while (counter > 0)
                {
                    //int _isPaused = mem.ReadByte($"{process}.exe+ABB854");
                    //int _cantMove = mem.ReadByte($"{process}.exe+2A16310");
                    //int _isWorldMap = mem.ReadByte($"{process}.exe+717008");
                    int _isMapLoaded = Hypervisor.Read<byte>(0x9BA8D0);
                    if (_isMapLoaded == 0)
                    {
                        Thread.Sleep(1000);
                        continue;
                    }
                    Hypervisor.Write<byte>(0xABAC5A, 0x01);
                    Hypervisor.Write<int>(0x7535C0, 1);
                    Hypervisor.Write<byte>(0x2AE5D78, 0x00);
                    counter--;
                }
            }).Start();
        }
    }
}
