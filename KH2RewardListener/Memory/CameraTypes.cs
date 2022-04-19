using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH2RewardListener.Memory
{
    public class CameraTypes
    {
        public static async Task<string[]> GetCameraType(int cameratype)
        {
            List<string> getcameratype = new List<string>();

            switch (cameratype)
            {
                case 1:
                    getcameratype.Add("First Person");
                    getcameratype.Add("1");
                    break;
                case 2:
                    getcameratype.Add("Freeze");
                    getcameratype.Add("4");
                    break;
                case 3:
                    getcameratype.Add("Top-Down");
                    getcameratype.Add("5");
                    break;
                default:
                    getcameratype.Add("First Person");
                    getcameratype.Add("1");
                    break;
            }
            return getcameratype.ToArray();
        }
    }
}
