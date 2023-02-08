using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH2RewardListener
{
    public class RewardManager
    {
        public static string AutoAttack { get; set; }
        public static string DriveAnti { get; set; }
        public static string DriveFinal { get; set; }
        public static string DriveLimit { get; set; }
        public static string DriveMaster { get; set; }
        public static string DriveValor { get; set; }
        public static string DriveWisdom { get; set; }
        public static string EmptyDrive { get; set; }
        public static string EmptyMagic { get; set; }
        public static string OneHP { get; set; }
        public static string RandomCamera { get; set; }
        public static string RandomConsumable { get; set; }
        public static string RandomKeyblade { get; set; }
        public static string RefillDrive{ get; set; }
        public static string RefillFormDuration { get; set; }
        public static string RefillHP { get; set; }
        public static string RefillMP { get; set; }
        public static string SoftReset { get; set; }

        public static void GetRewardNames()
        {
            string autoattack_json = File.ReadAllText("Rewards/AutoAttack.json");
            dynamic autoattack_dyn = JsonConvert.DeserializeObject(autoattack_json);
            AutoAttack = autoattack_dyn["Reward"]["Name"];

            string onehp_json = File.ReadAllText("Rewards/OneHP.json");
            dynamic onehp_dyn = JsonConvert.DeserializeObject(onehp_json);
            OneHP = onehp_dyn["Reward"]["Name"];

            string refillhp_json = File.ReadAllText("Rewards/RefillHP.json");
            dynamic refillhp_dyn = JsonConvert.DeserializeObject(refillhp_json);
            RefillHP = refillhp_dyn["Reward"]["Name"];

            string refillmp_json = File.ReadAllText("Rewards/RefillMP.json");
            dynamic refillmp_dyn = JsonConvert.DeserializeObject(refillmp_json);
            RefillMP = refillmp_dyn["Reward"]["Name"];

        }
    }
}
