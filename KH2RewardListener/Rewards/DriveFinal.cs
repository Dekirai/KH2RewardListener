﻿using Memory;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;
using System.Reflection;
using TwitchLib.Client.Models;

namespace KH2RewardListener.Rewards
{
    public class DriveFinal
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
            string rewardjson = File.ReadAllText("Rewards/DriveFinal.json");
            dynamic reward = JsonConvert.DeserializeObject(rewardjson);

            string chatmessage = reward["Reward"]["Message"];

            int counter = 1;
            int _isForm = mem.ReadByte($"{process}.exe+9AA5D4");
            if (_isForm > 0)
                MainForm.client.SendMessage(MainForm.channel, "The reward has been added to the queue because the player is already in a form!");

            new Thread(() =>
            {
                while (counter > 0)
                {
                    int _isPaused = mem.ReadByte($"{process}.exe+AB9054");
                    int _isForm = mem.ReadByte($"{process}.exe+9AA5D4");
                    int _cantMove = mem.ReadByte($"{process}.exe+2A148E8");
                    int _isWorldMap = mem.ReadByte($"{process}.exe+714DB8");
                    if (_isPaused > 0 || _isForm > 0 || _cantMove > 0 || _isWorldMap == 15)
                    {
                        Thread.Sleep(3500);
                        continue;
                    }
                    var keyblade = mem.ReadByte($"{process}.exe+9AA484");
                    if (keyblade == 0)
                        mem.WriteMemory($"{process}.exe+9AA484", "bytes", "0x29 0x00");
                    MainForm.client.SendMessage(MainForm.channel, chatmessage);
                    Thread.Sleep(500);
                    var CharCheck = mem.ReadByte($"{process}.exe+2A22A00");
                    if (CharCheck != 0x54)
                    {
                        MainForm.client.SendMessage(MainForm.channel, "The player needs to be Sora for that.");
                        return;
                    }
                    mem.WriteMemory($"{process}.exe+2A5A096", "bytes", "0x04 0x00 0x05 0x00");
                    Thread.Sleep(400);
                    mem.WriteMemory($"{process}.exe+2A5A096", "bytes", "0x00 0x00 0x00 0x00");
                    counter--;
                }
            }).Start();
        }
    }
}
