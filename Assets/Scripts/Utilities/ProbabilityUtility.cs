using System.Collections.Generic;
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
                sum += items[i].Probability;

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

        public static List<T> PickMultiple<T>(T[] items, int count)
            where T : IProbability
        {
            var result = new List<T>();
            var temp = new List<T>(items);
            if (count > temp.Count)
                return temp;

            var sum = 0;
            for (int i = 0; i < items.Length; i++)
                sum += items[i].Probability;

            for (int i = 0; i < count; i++)
            {
                var randomValue = Random.Range(0, sum);
                for (int j = 0; j < temp.Count; j++)
                {
                    var tempItem = temp[j];
                    sum -= tempItem.Probability;

                    if (sum <= randomValue)
                    {
                        sum -= tempItem.Probability;
                        result.Add(tempItem);
                        temp.RemoveAt(j);
                        break;
                    }
                }
            }

            return result;
        }
    }
}