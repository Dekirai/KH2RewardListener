﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH2RewardListener
{
    public class RewardManager
    {
        public static string? AutoAttack { get; set; }
        public static string? DriveAnti { get; set; }
        public static string? DriveFinal { get; set; }
        public static string? DriveLimit { get; set; }
        public static string? DriveMaster { get; set; }
        public static string? DriveValor { get; set; }
        public static string? DriveWisdom { get; set; }
        public static string? EmptyDrive { get; set; }
        public static string? EmptyMagic { get; set; }
        public static string? OneHP { get; set; }
        public static string? RandomCamera { get; set; }
        public static string? RandomConsumable { get; set; }
        public static string? RandomKeyblade { get; set; }
        public static string? RefillDrive { get; set; }
        public static string? RefillFormDuration { get; set; }
        public static string? RefillHP { get; set; }
        public static string? RefillMP { get; set; }
        public static string? SoftReset { get; set; }

        public static void GetRewardNames()
        {
            string autoattack_json = File.ReadAllText("Rewards/AutoAttack.json");
            dynamic autoattack_dyn = JsonConvert.DeserializeObject(autoattack_json);
            AutoAttack = autoattack_dyn["Reward"]["Name"];

            string emptydrive_json = File.ReadAllText("Rewards/EmptyDrive.json");
            dynamic emptydrive_dyn = JsonConvert.DeserializeObject(emptydrive_json);
            EmptyDrive = emptydrive_dyn["Reward"]["Name"];

            string emptymagic_json = File.ReadAllText("Rewards/EmptyMagic.json");
            dynamic emptymagic_dyn = JsonConvert.DeserializeObject(emptymagic_json);
            EmptyMagic = emptymagic_dyn["Reward"]["Name"];

            string driveanti_json = File.ReadAllText("Rewards/DriveAnti.json");
            dynamic driveanti_dyn = JsonConvert.DeserializeObject(driveanti_json);
            DriveAnti = driveanti_dyn["Reward"]["Name"];

            string drivefinal_json = File.ReadAllText("Rewards/DriveFinal.json");
            dynamic drivefinal_dyn = JsonConvert.DeserializeObject(drivefinal_json);
            DriveFinal = drivefinal_dyn["Reward"]["Name"];

            string drivelimit_json = File.ReadAllText("Rewards/DriveLimit.json");
            dynamic drivelimit_dyn = JsonConvert.DeserializeObject(drivelimit_json);
            DriveLimit = drivelimit_dyn["Reward"]["Name"];

            string drivemaster_json = File.ReadAllText("Rewards/DriveMaster.json");
            dynamic drivemaster_dyn = JsonConvert.DeserializeObject(drivemaster_json);
            DriveMaster = drivemaster_dyn["Reward"]["Name"];

            string drivevalor_json = File.ReadAllText("Rewards/DriveValor.json");
            dynamic drivevalor_dyn = JsonConvert.DeserializeObject(drivevalor_json);
            DriveValor = drivevalor_dyn["Reward"]["Name"];

            string drivewisdom_json = File.ReadAllText("Rewards/DriveWisdom.json");
            dynamic drivewisdom_dyn = JsonConvert.DeserializeObject(drivewisdom_json);
            DriveWisdom = drivewisdom_dyn["Reward"]["Name"];

            string onehp_json = File.ReadAllText("Rewards/OneHP.json");
            dynamic onehp_dyn = JsonConvert.DeserializeObject(onehp_json);
            OneHP = onehp_dyn["Reward"]["Name"];

            string randomconsumable_json = File.ReadAllText("Rewards/RandomConsumable.json");
            dynamic randomconsumable_dyn = JsonConvert.DeserializeObject(randomconsumable_json);
            RandomConsumable = randomconsumable_dyn["Reward"]["Name"];

            string refilldrive_json = File.ReadAllText("Rewards/RefillDrive.json");
            dynamic refilldrive_dyn = JsonConvert.DeserializeObject(refilldrive_json);
            RefillDrive = refilldrive_dyn["Reward"]["Name"];

            string refillformduration_json = File.ReadAllText("Rewards/RefillFormDuration.json");
            dynamic refillformduration_dyn = JsonConvert.DeserializeObject(refillformduration_json);
            RefillFormDuration = refillformduration_dyn["Reward"]["Name"];

            string refillhp_json = File.ReadAllText("Rewards/RefillHP.json");
            dynamic refillhp_dyn = JsonConvert.DeserializeObject(refillhp_json);
            RefillHP = refillhp_dyn["Reward"]["Name"];

            string refillmp_json = File.ReadAllText("Rewards/RefillMP.json");
            dynamic refillmp_dyn = JsonConvert.DeserializeObject(refillmp_json);
            RefillMP = refillmp_dyn["Reward"]["Name"];

            string softreset_json = File.ReadAllText("Rewards/SoftReset.json");
            dynamic softreset_dyn = JsonConvert.DeserializeObject(softreset_json);
            SoftReset = softreset_dyn["Reward"]["Name"];
        }
    }
}
