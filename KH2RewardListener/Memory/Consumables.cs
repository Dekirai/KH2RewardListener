namespace KH2RewardListener.Memory
{
    public class Consumables
    {
        public static (string, int) GetConsumable(int consumable)
        {
            switch (consumable)
            {
                case 1: return ("Potion", 0x9ACE30 + 0x2800);
                case 2: return ("Hi-Potion", 0x9AA631 + 0x2800);
                case 3: return ("Ether", 0x9AA632 + 0x2800);
                case 4: return ("Elixir", 0x9AA633 + 0x2800);
                case 5: return ("Mega-Potion", 0x9AA634 + 0x2800);
                case 6: return ("Mega-Ether", 0x9AA635 + 0x2800);
                case 7: return ("Megalixir", 0x9AA636 + 0x2800);
                case 8: return ("Tent", 0x9AA691 + 0x2800);
                case 9: return ("Drive Recovery", 0x9AA714 + 0x2800);
                case 10: return ("High Drive Recovery", 0x9AA715 + 0x2800);
                case 11: return ("Power Boost", 0x9AA716 + 0x2800);
                case 12: return ("Magic Boost", 0x9AA717 + 0x2800);
                case 13: return ("Defense Boost", 0x9AA718 + 0x2800);
                case 14: return ("AP Boost", 0x9AA719 + 0x2800);
                default: return ("Potion", 0x9AA630 + 0x2800);
            }
        }
    }
}