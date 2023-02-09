namespace KH2RewardListener.Memory
{
    public class Consumables
    {
        public static string[] GetConsumable(int consumable)
        {
            List<string> getconsumable = new List<string>();


            switch (consumable)
            {
                case 1:
                    getconsumable.Add("Potion");
                    getconsumable.Add("0x9AA630");
                    break;
                case 2:
                    getconsumable.Add("Hi-Potion");
                    getconsumable.Add("0x9AA631");
                    break;
                case 3:
                    getconsumable.Add("Ether");
                    getconsumable.Add("0x9AA632");
                    break;
                case 4:
                    getconsumable.Add("Elixir");
                    getconsumable.Add("0x9AA633");
                    break;
                case 5:
                    getconsumable.Add("Mega-Potion");
                    getconsumable.Add("0x9AA634");
                    break;
                case 6:
                    getconsumable.Add("Mega-Ether");
                    getconsumable.Add("0x9AA635");
                    break;
                case 7:
                    getconsumable.Add("Megalixir");
                    getconsumable.Add("0x9AA636");
                    break;
                case 8:
                    getconsumable.Add("Tent");
                    getconsumable.Add("0x9AA691");
                    break;
                case 9:
                    getconsumable.Add("Drive Recovery");
                    getconsumable.Add("0x9AA714");
                    break;
                case 10:
                    getconsumable.Add("High Drive Recovery");
                    getconsumable.Add("0x9AA715");
                    break;
                case 11:
                    getconsumable.Add("Power Boost");
                    getconsumable.Add("0x9AA716");
                    break;
                case 12:
                    getconsumable.Add("Magic Boost");
                    getconsumable.Add("0x9AA717");
                    break;
                case 13:
                    getconsumable.Add("Defense Boost");
                    getconsumable.Add("0x9AA718");
                    break;
                case 14:
                    getconsumable.Add("AP Boost");
                    getconsumable.Add("0x9AA719");
                    break;
                default:
                    getconsumable.Add("Potion");
                    getconsumable.Add("0x9AA630");
                    break;
            }
            return getconsumable.ToArray();
        }
    }
}
