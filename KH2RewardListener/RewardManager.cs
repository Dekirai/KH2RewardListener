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
        public string DriveAnti { get; set; }
        public string DriveFinal { get; set; }
        public string DriveLimit { get; set; }
        public string DriveMaster { get; set; }
        public string DriveValor { get; set; }
        public string DriveWisdom { get; set; }
        public string EmptyDrive { get; set; }
        public string EmptyMagic { get; set; }
        public string EndDrive { get; set; }
        public string OneHP { get; set; }
        public string RandomCamera { get; set; }
        public string RandomConsumable { get; set; }
        public string RandomKeyblade { get; set; }
        public string RefillDrive{ get; set; }
        public string RefillFormDuration { get; set; }
        public string RefillHP { get; set; }
        public string RefillMP { get; set; }
        public string SoftReset { get; set; }

        public RewardManager()
        {
            string onehp_json = File.ReadAllText("Rewards/OneHP.json");
            dynamic onehp_dyn = JsonConvert.DeserializeObject(onehp_json);
            OneHP = onehp_dyn["Reward"]["RewardName"];

            string refillhp_json = File.ReadAllText("Rewards/RefillHP.json");
            dynamic refillhp_dyn = JsonConvert.DeserializeObject(refillhp_json);
            RefillHP = refillhp_dyn["Reward"]["RewardName"];

            //string onehp_json = File.ReadAllText("Rewards/OneHP.json");
            //dynamic onehp_dyn = JsonConvert.DeserializeObject(onehp_json);
            //OneHP = onehp_dyn["Reward"]["RewardName"];

            //string onehp_json = File.ReadAllText("Rewards/OneHP.json");
            //dynamic onehp_dyn = JsonConvert.DeserializeObject(onehp_json);
            //OneHP = onehp_dyn["Reward"]["RewardName"];

            //string onehp_json = File.ReadAllText("Rewards/OneHP.json");
            //dynamic onehp_dyn = JsonConvert.DeserializeObject(onehp_json);
            //OneHP = onehp_dyn["Reward"]["RewardName"];

            //string onehp_json = File.ReadAllText("Rewards/OneHP.json");
            //dynamic onehp_dyn = JsonConvert.DeserializeObject(onehp_json);
            //OneHP = onehp_dyn["Reward"]["RewardName"];

            //string onehp_json = File.ReadAllText("Rewards/OneHP.json");
            //dynamic onehp_dyn = JsonConvert.DeserializeObject(onehp_json);
            //OneHP = onehp_dyn["Reward"]["RewardName"];

            //string onehp_json = File.ReadAllText("Rewards/OneHP.json");
            //dynamic onehp_dyn = JsonConvert.DeserializeObject(onehp_json);
            //OneHP = onehp_dyn["Reward"]["RewardName"];

            //string onehp_json = File.ReadAllText("Rewards/OneHP.json");
            //dynamic onehp_dyn = JsonConvert.DeserializeObject(onehp_json);
            //OneHP = onehp_dyn["Reward"]["RewardName"];

            //string onehp_json = File.ReadAllText("Rewards/OneHP.json");
            //dynamic onehp_dyn = JsonConvert.DeserializeObject(onehp_json);
            //OneHP = onehp_dyn["Reward"]["RewardName"];

            //string onehp_json = File.ReadAllText("Rewards/OneHP.json");
            //dynamic onehp_dyn = JsonConvert.DeserializeObject(onehp_json);
            //OneHP = onehp_dyn["Reward"]["RewardName"];

            //string onehp_json = File.ReadAllText("Rewards/OneHP.json");
            //dynamic onehp_dyn = JsonConvert.DeserializeObject(onehp_json);
            //OneHP = onehp_dyn["Reward"]["RewardName"];

            //string onehp_json = File.ReadAllText("Rewards/OneHP.json");
            //dynamic onehp_dyn = JsonConvert.DeserializeObject(onehp_json);
            //OneHP = onehp_dyn["Reward"]["RewardName"];

            //string onehp_json = File.ReadAllText("Rewards/OneHP.json");
            //dynamic onehp_dyn = JsonConvert.DeserializeObject(onehp_json);
            //OneHP = onehp_dyn["Reward"]["RewardName"];

            //string onehp_json = File.ReadAllText("Rewards/OneHP.json");
            //dynamic onehp_dyn = JsonConvert.DeserializeObject(onehp_json);
            //OneHP = onehp_dyn["Reward"]["RewardName"];

            //string onehp_json = File.ReadAllText("Rewards/OneHP.json");
            //dynamic onehp_dyn = JsonConvert.DeserializeObject(onehp_json);
            //OneHP = onehp_dyn["Reward"]["RewardName"];

            //string onehp_json = File.ReadAllText("Rewards/OneHP.json");
            //dynamic onehp_dyn = JsonConvert.DeserializeObject(onehp_json);
            //OneHP = onehp_dyn["Reward"]["RewardName"];

            //string onehp_json = File.ReadAllText("Rewards/OneHP.json");
            //dynamic onehp_dyn = JsonConvert.DeserializeObject(onehp_json);
            //OneHP = onehp_dyn["Reward"]["RewardName"];
        }
    }
}
