using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH2RewardListener.Memory
{
    public class KeybladeIDs
    {
        public static async Task<string[]> GetKeybladeID(int keyblade)
        {
            List<string> getkeyblade = new List<string>();

            switch (keyblade)
            {
                case 1:
                    getkeyblade.Add("Kingdom Key");
                    getkeyblade.Add("41");
                    break;
                case 2:
                    getkeyblade.Add("Oathkeeper");
                    getkeyblade.Add("42");
                    break;
                case 3:
                    getkeyblade.Add("Oblivion");
                    getkeyblade.Add("43");
                    break;
                case 4:
                    getkeyblade.Add("Struggle Sword");
                    getkeyblade.Add("384");
                    break;
                case 5:
                    getkeyblade.Add("Star Seeker");
                    getkeyblade.Add("480");
                    break;
                case 6:
                    getkeyblade.Add("Hidden Dragon");
                    getkeyblade.Add("481");
                    break;
                case 7:
                    getkeyblade.Add("Hero's Crest");
                    getkeyblade.Add("484");
                    break;
                case 8:
                    getkeyblade.Add("Monochrome");
                    getkeyblade.Add("485");
                    break;
                case 9:
                    getkeyblade.Add("Follow the Wind");
                    getkeyblade.Add("486");
                    break;
                case 10:
                    getkeyblade.Add("Circle of Life");
                    getkeyblade.Add("487");
                    break;
                case 11:
                    getkeyblade.Add("Photon Debugger");
                    getkeyblade.Add("488");
                    break;
                case 12:
                    getkeyblade.Add("Gull Wing");
                    getkeyblade.Add("489");
                    break;
                case 13:
                    getkeyblade.Add("Rumbling Rose");
                    getkeyblade.Add("490");
                    break;
                case 14:
                    getkeyblade.Add("Guardian Soul");
                    getkeyblade.Add("491");
                    break;
                case 15:
                    getkeyblade.Add("Wishing Lamp");
                    getkeyblade.Add("492");
                    break;
                case 16:
                    getkeyblade.Add("Decisive Pumpkin");
                    getkeyblade.Add("493");
                    break;
                case 17:
                    getkeyblade.Add("Sleeping Lion");
                    getkeyblade.Add("494");
                    break;
                case 18:
                    getkeyblade.Add("Sweet Memories");
                    getkeyblade.Add("495");
                    break;
                case 19:
                    getkeyblade.Add("Mysterious Abyss");
                    getkeyblade.Add("496");
                    break;
                case 20:
                    getkeyblade.Add("Fatal Crest");
                    getkeyblade.Add("497");
                    break;
                case 21:
                    getkeyblade.Add("Bond of Flame");
                    getkeyblade.Add("498");
                    break;
                case 22:
                    getkeyblade.Add("Fenrir");
                    getkeyblade.Add("499");
                    break;
                case 23:
                    getkeyblade.Add("Ultima Weapon");
                    getkeyblade.Add("500");
                    break;
                case 24:
                    getkeyblade.Add("Struggle Wand");
                    getkeyblade.Add("501");
                    break;
                case 25:
                    getkeyblade.Add("Struggle Hammer");
                    getkeyblade.Add("502");
                    break;
                case 26:
                    getkeyblade.Add("Two Become One");
                    getkeyblade.Add("543");
                    break;
                case 27:
                    getkeyblade.Add("Winner's Proof");
                    getkeyblade.Add("544");
                    break;
                default:
                    getkeyblade.Add("Kingdom Key");
                    getkeyblade.Add("41");
                    break;
            }
            return getkeyblade.ToArray();
        }
    }
}
