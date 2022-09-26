using SharedLibrary.Helpers;
namespace PlayerBaseApi.Helpers
{
    public class LootRandomer : RandomHelper
    {
        public static int GetRandomResource(int min, int max, double minChance = 0.1, double maxChance = 0.05)//TODO: Random algoritması araştırılacak
        {
            var random = new Random().Next(min, max);
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
