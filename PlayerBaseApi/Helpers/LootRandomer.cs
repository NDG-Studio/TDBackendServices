using SharedLibrary.Helpers;
namespace PlayerBaseApi.Helpers
{
    public class LootRandomer : RandomHelper
    {
        public static int GetRandomScrap(int min, int max, double minChance = 0.1, double maxChance = 0.05)
        {
            int random = new Random().Next(min, max);
            if ((max - min) * minChance > random)
            {
                random = min;
            }
            else if ((max - min) * (1 - maxChance) < random)
            {
                random = max;
            }
            return random;
        }

        public static int GetRandomBlueprint(int min, double doubleChance, double minChance = 0.1, double maxChance = 0.05)
        {
            int random = new Random().Next(1, 10000);
            if (doubleChance*10000 > random)
            {
                return 2*min;
            }
            return min;
        }

        public static int GetRandomGem(int min, int max, double minChance = 0.1, double maxChance = 0.05)
        {
            int random = new Random().Next(min, max);
            if ((max - min) * minChance > random)
            {
                random = min;
            }
            else if ((max - min) * (1 - maxChance) < random)
            {
                random = max;
            }
            return random;
        }
    }
}
