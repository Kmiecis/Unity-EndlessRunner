using UnityEngine;

namespace Game
{
    public static class ProbabilityUtility
    {
        public static int PickIndex<T>(T[] items)
            where T : IProbability
        {
            var sum = 0;
            for (int i = 0; i < items.Length; i++)
            {
                sum += items[i].Probability;
            }

            var randomValue = Random.Range(0, sum);
            for (int i = 0; i < items.Length; i++)
            {
                sum -= items[i].Probability;

                if (sum <= randomValue)
                    return i;
            }

            return 0;
        }

        public static T PickSingle<T>(T[] items)
            where T : IProbability
        {
            return items[PickIndex(items)];
        }
    }
}