using KH2RewardListener.Rewards;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace KH2RewardListener
{
    public class RewardManager
    {
        public static string? AutoAttack { get; set; }
        public static string? AutoJump { get; set; }
        public static string? BlindSight { get; set; }
        public static string? BlockPause { get; set; }
        public static string? DriveAnti { get; set; }
        public static string? DriveFinal { get; set; }
        public static string? DriveLimit { get; set; }
        public static string? DriveMaster { get; set; }
        public static string? DriveValor { get; set; }
        public static string? DriveWisdom { get; set; }
        public static string? EmptyDrive { get; set; }
        public static string? EmptyMagic { get; set; }
        public static string? FieldOfView { get; set; }
        public static string? Flashbang { get; set; }
        public static string? GameSpeed { get; set; }
        public static string? InvisibleModels { get; set; }
        public static string? MovementSpeed { get; set; }
        public static string? NoAttack { get; set; }
        public static string? NoDrive { get; set; }
        public static string? NoItems { get; set; }
        public static string? NoMagic { get; set; }
        public static string? NoScan { get; set; }
        public static string? OneHP { get; set; }
        public static string? PhoneMode { get; set; }
        public static string? PlayerSize { get; set; }
        public static string? RandomCamera { get; set; }
        public static string? RandomConsumable { get; set; }
        public static string? RandomDefense { get; set; }
        public static string? RandomMagic { get; set; }
        public static string? RandomMunny { get; set; }
        public static string? RandomStrength { get; set; }
        public static string? RefillDrive { get; set; }
        public static string? RefillFormDuration { get; set; }
        public static string? RefillHP { get; set; }
        public static string? RefillMP { get; set; }
        public static string? SoftReset { get; set; }

        public static void GetRewardNames()
        {
            try
            {
                string autoattack_json = File.ReadAllText("Rewards/AutoAttack.json");
                dynamic autoattack_dyn = JsonConvert.DeserializeObject(autoattack_json);
                AutoAttack = autoattack_dyn["Reward"]["ID"];

                string autojump_json = File.ReadAllText("Rewards/AutoJump.json");
                dynamic autojump_dyn = JsonConvert.DeserializeObject(autojump_json);
                AutoJump = autojump_dyn["Reward"]["ID"];

                string blindsight_json = File.ReadAllText("Rewards/BlindSight.json");
                dynamic blindsight_dyn = JsonConvert.DeserializeObject(blindsight_json);
                BlindSight = blindsight_dyn["Reward"]["ID"];

                string blockpause_json = File.ReadAllText("Rewards/BlockPause.json");
                dynamic blockpause_dyn = JsonConvert.DeserializeObject(blockpause_json);
                BlockPause = blockpause_dyn["Reward"]["ID"];

                string driveanti_json = File.ReadAllText("Rewards/DriveAnti.json");
                dynamic driveanti_dyn = JsonConvert.DeserializeObject(driveanti_json);
                DriveAnti = driveanti_dyn["Reward"]["ID"];

                string drivefinal_json = File.ReadAllText("Rewards/DriveFinal.json");
                dynamic drivefinal_dyn = JsonConvert.DeserializeObject(drivefinal_json);
                DriveFinal = drivefinal_dyn["Reward"]["ID"];

                string drivelimit_json = File.ReadAllText("Rewards/DriveLimit.json");
                dynamic drivelimit_dyn = JsonConvert.DeserializeObject(drivelimit_json);
                DriveLimit = drivelimit_dyn["Reward"]["ID"];

                string drivemaster_json = File.ReadAllText("Rewards/DriveMaster.json");
                dynamic drivemaster_dyn = JsonConvert.DeserializeObject(drivemaster_json);
                DriveMaster = drivemaster_dyn["Reward"]["ID"];

                string drivevalor_json = File.ReadAllText("Rewards/DriveValor.json");
                dynamic drivevalor_dyn = JsonConvert.DeserializeObject(drivevalor_json);
                DriveValor = drivevalor_dyn["Reward"]["ID"];

                string drivewisdom_json = File.ReadAllText("Rewards/DriveWisdom.json");
                dynamic drivewisdom_dyn = JsonConvert.DeserializeObject(drivewisdom_json);
                DriveWisdom = drivewisdom_dyn["Reward"]["ID"];

                string emptydrive_json = File.ReadAllText("Rewards/EmptyDrive.json");
                dynamic emptydrive_dyn = JsonConvert.DeserializeObject(emptydrive_json);
                EmptyDrive = emptydrive_dyn["Reward"]["ID"];

                string emptymagic_json = File.ReadAllText("Rewards/EmptyMagic.json");
                dynamic emptymagic_dyn = JsonConvert.DeserializeObject(emptymagic_json);
                EmptyMagic = emptymagic_dyn["Reward"]["ID"];

                string fieldofview_json = File.ReadAllText("Rewards/FieldOfView.json");
                dynamic fieldofview_dyn = JsonConvert.DeserializeObject(fieldofview_json);
                FieldOfView = fieldofview_dyn["Reward"]["ID"];

                string flashbang_json = File.ReadAllText("Rewards/Flashbang.json");
                dynamic flashbang_dyn = JsonConvert.DeserializeObject(flashbang_json);
                Flashbang = flashbang_dyn["Reward"]["ID"];

                string gamespeed_json = File.ReadAllText("Rewards/GameSpeed.json");
                dynamic gamespeed_dyn = JsonConvert.DeserializeObject(gamespeed_json);
                GameSpeed = gamespeed_dyn["Reward"]["ID"];

                string invisiblemodels_json = File.ReadAllText("Rewards/InvisibleModels.json");
                dynamic invisiblemodels_dyn = JsonConvert.DeserializeObject(invisiblemodels_json);
                InvisibleModels = invisiblemodels_dyn["Reward"]["ID"];

                string movementspeed_json = File.ReadAllText("Rewards/MovementSpeed.json");
                dynamic movementspeed_dyn = JsonConvert.DeserializeObject(movementspeed_json);
                MovementSpeed = movementspeed_dyn["Reward"]["ID"];

                string noattack_json = File.ReadAllText("Rewards/NoAttack.json");
                dynamic noattack_dyn = JsonConvert.DeserializeObject(noattack_json);
                NoAttack = noattack_dyn["Reward"]["ID"];

                string nodrive_json = File.ReadAllText("Rewards/NoDrive.json");
                dynamic nodrive_dyn = JsonConvert.DeserializeObject(nodrive_json);
                NoDrive = nodrive_dyn["Reward"]["ID"];

                string noitems_json = File.ReadAllText("Rewards/NoItems.json");
                dynamic noitems_dyn = JsonConvert.DeserializeObject(noitems_json);
                NoItems = noitems_dyn["Reward"]["ID"];

                string nomagic_json = File.ReadAllText("Rewards/NoMagic.json");
                dynamic nomagic_dyn = JsonConvert.DeserializeObject(nomagic_json);
                NoMagic = nomagic_dyn["Reward"]["ID"];

                string noscan_json = File.ReadAllText("Rewards/NoScan.json");
                dynamic noscan_dyn = JsonConvert.DeserializeObject(noscan_json);
                NoScan = noscan_dyn["Reward"]["ID"];

                string onehp_json = File.ReadAllText("Rewards/OneHP.json");
                dynamic onehp_dyn = JsonConvert.DeserializeObject(onehp_json);
                OneHP = onehp_dyn["Reward"]["ID"];

                string phonemode_json = File.ReadAllText("Rewards/PhoneMode.json");
                dynamic phonemode_dyn = JsonConvert.DeserializeObject(phonemode_json);
                PhoneMode = phonemode_dyn["Reward"]["ID"];

                string playersize_json = File.ReadAllText("Rewards/PlayerSize.json");
                dynamic playersize_dyn = JsonConvert.DeserializeObject(playersize_json);
                PlayerSize = playersize_dyn["Reward"]["ID"];

                string randomcamera_json = File.ReadAllText("Rewards/RandomCamera.json");
                dynamic randomcamera_dyn = JsonConvert.DeserializeObject(randomcamera_json);
                RandomCamera = randomcamera_dyn["Reward"]["ID"];

                string randomconsumable_json = File.ReadAllText("Rewards/RandomConsumable.json");
                dynamic randomconsumable_dyn = JsonConvert.DeserializeObject(randomconsumable_json);
                RandomConsumable = randomconsumable_dyn["Reward"]["ID"];

                string randomdefense_json = File.ReadAllText("Rewards/RandomDefense.json");
                dynamic randomdefense_dyn = JsonConvert.DeserializeObject(randomdefense_json);
                RandomDefense = randomdefense_dyn["Reward"]["ID"];

                string randommagic_json = File.ReadAllText("Rewards/RandomMagic.json");
                dynamic randommagic_dyn = JsonConvert.DeserializeObject(randommagic_json);
                RandomMagic = randommagic_dyn["Reward"]["ID"];

                string randommunny_json = File.ReadAllText("Rewards/RandomMunny.json");
                dynamic randommunny_dyn = JsonConvert.DeserializeObject(randommunny_json);
                RandomMunny = randommunny_dyn["Reward"]["ID"];

                string randomstrength_json = File.ReadAllText("Rewards/RandomStrength.json");
                dynamic randomstrength_dyn = JsonConvert.DeserializeObject(randomstrength_json);
                RandomStrength = randomstrength_dyn["Reward"]["ID"];

                string refilldrive_json = File.ReadAllText("Rewards/RefillDrive.json");
                dynamic refilldrive_dyn = JsonConvert.DeserializeObject(refilldrive_json);
                RefillDrive = refilldrive_dyn["Reward"]["ID"];

                string refillformduration_json = File.ReadAllText("Rewards/RefillFormDuration.json");
                dynamic refillformduration_dyn = JsonConvert.DeserializeObject(refillformduration_json);
                RefillFormDuration = refillformduration_dyn["Reward"]["ID"];

                string refillhp_json = File.ReadAllText("Rewards/RefillHP.json");
                dynamic refillhp_dyn = JsonConvert.DeserializeObject(refillhp_json);
                RefillHP = refillhp_dyn["Reward"]["ID"];

                string refillmp_json = File.ReadAllText("Rewards/RefillMP.json");
                dynamic refillmp_dyn = JsonConvert.DeserializeObject(refillmp_json);
                RefillMP = refillmp_dyn["Reward"]["ID"];

                string softreset_json = File.ReadAllText("Rewards/SoftReset.json");
                dynamic softreset_dyn = JsonConvert.DeserializeObject(softreset_json);
                SoftReset = softreset_dyn["Reward"]["ID"];
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
