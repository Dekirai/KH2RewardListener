using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH2RewardListener.Memory
{
    public class CameraTypes
    {
        public static (string, int) GetCameraType(int cameratype)
        {
            List<string> getcameratype = new List<string>();

            switch (cameratype)
            {
                case 1: return ("First Person", 1);
                case 2: return ("Freeze", 4);
                case 3: return ("Top-Down", 5);
                default: return ("First Person", 1);
            }
        }
    }
}
