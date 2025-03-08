using Newtonsoft.Json;
using System.Diagnostics;

namespace KH2RewardListener.Rewards
{
    public class NoMagic
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
            string rewardjson = File.ReadAllText("Rewards/NoMagic.json");
            dynamic reward = JsonConvert.DeserializeObject(rewardjson);

            string chatmessage = reward["Reward"]["Message"];
            string endmessage = reward["Reward"]["EndMessage"];
            string duration = reward["Reward"]["Duration"];
            int counter = int.Parse(duration);

            short _shortcut1 = Hypervisor.Read<short>(0x9ACFA8);
            short _shortcut2 = Hypervisor.Read<short>(0x9ACFAA);
            short _shortcut3 = Hypervisor.Read<short>(0x9ACFAC);
            short _shortcut4 = Hypervisor.Read<short>(0x9ACFAE);
            MainForm.client.SendMessage(MainForm.channel, chatmessage.Replace("[Duration]", counter.ToString()));
            new Thread(() =>
            {
                while (counter > 0)
                {
                    int _isPaused = Hypervisor.Read<byte>(0xABB854);
                    int _cantMove = Hypervisor.Read<byte>(0x2A171E8);
                    int _isWorldMap = Hypervisor.Read<byte>(0x717008);
                    int _isMapLoaded = Hypervisor.Read<byte>(0x9BA8D0);
                    if (_isPaused > 0 || _cantMove > 0 || _isWorldMap == 15 || _isMapLoaded == 0)
                    {
                        Thread.Sleep(1000);
                        continue;
                    }
                    if (_shortcut1 == 49 || _shortcut1 == 51 || _shortcut1 == 50 || _shortcut1 == 52 || _shortcut1 == 174 || _shortcut1 == 177 || _shortcut1 == 119 || _shortcut1 == 121 || _shortcut1 == 123 || _shortcut1 == 125 || _shortcut1 == 175 || _shortcut1 == 178 || _shortcut1 == 120 || _shortcut1 == 122 || _shortcut1 == 124 || _shortcut1 == 126 || _shortcut1 == 176 || _shortcut1 == 179)
                        Hypervisor.Write<byte>(0x9ACFA8, [0x00, 0x00]);
                    if (_shortcut2 == 49 || _shortcut2 == 51 || _shortcut2 == 50 || _shortcut2 == 52 || _shortcut2 == 174 || _shortcut2 == 177 || _shortcut2 == 119 || _shortcut2 == 121 || _shortcut2 == 123 || _shortcut2 == 125 || _shortcut2 == 175 || _shortcut2 == 178 || _shortcut2 == 120 || _shortcut2 == 122 || _shortcut2 == 124 || _shortcut2 == 126 || _shortcut2 == 176 || _shortcut2 == 179)
                        Hypervisor.Write<byte>(0x9ACFAA, [0x00, 0x00]);
                    if (_shortcut3 == 49 || _shortcut3 == 51 || _shortcut3 == 50 || _shortcut3 == 52 || _shortcut3 == 174 || _shortcut3 == 177 || _shortcut3 == 119 || _shortcut3 == 121 || _shortcut3 == 123 || _shortcut3 == 125 || _shortcut3 == 175 || _shortcut3 == 178 || _shortcut3 == 120 || _shortcut3 == 122 || _shortcut3 == 124 || _shortcut3 == 126 || _shortcut3 == 176 || _shortcut3 == 179)
                        Hypervisor.Write<byte>(0x9ACFAC, [0x00, 0x00]);
                    if (_shortcut4 == 49 || _shortcut4 == 51 || _shortcut4 == 50 || _shortcut4 == 52 || _shortcut4 == 174 || _shortcut4 == 177 || _shortcut4 == 119 || _shortcut4 == 121 || _shortcut4 == 123 || _shortcut4 == 125 || _shortcut4 == 175 || _shortcut4 == 178 || _shortcut4 == 120 || _shortcut4 == 122 || _shortcut4 == 124 || _shortcut4 == 126 || _shortcut4 == 176 || _shortcut4 == 179)
                        Hypervisor.Write<byte>(0x9ACFAE, [0x00, 0x00]);
                    Hypervisor.Write<byte>(0x2A5C9F6, 0x00);
                    Thread.Sleep(1000);
                    counter--;
                }
                Hypervisor.Write<short>(0x9ACFA8, _shortcut1);
                Hypervisor.Write<short>(0x9ACFAA, _shortcut2);
                Hypervisor.Write<short>(0x9ACFAC, _shortcut3);
                Hypervisor.Write<short>(0x9ACFAE, _shortcut4);
                Hypervisor.Write<byte>(0x2A5C9F6, 0x02);
                MainForm.client.SendMessage(MainForm.channel, endmessage);
            }).Start();
        }
    }
}
