namespace Game
{
    public class ProbabilityPoolers : APoolerProvider
    {
        public ProbabilityPooler[] poolers;

        public override Pooler GetPooler()
        {
            return ProbabilityUtility.PickSingle(poolers);
        }
    }
}