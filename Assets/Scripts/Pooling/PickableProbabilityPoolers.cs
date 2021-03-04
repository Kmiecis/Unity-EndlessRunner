namespace Game
{
    public class PickableProbabilityPoolers : APoolerProvider
    {
        public ProbabilityPooler[] poolers;
        public int index;

        public override Pooler GetPooler()
        {
            return poolers[index].GetPooler();
        }
    }
}