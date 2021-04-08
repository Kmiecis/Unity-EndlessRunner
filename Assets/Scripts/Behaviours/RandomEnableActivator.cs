namespace Game
{
    public class RandomEnableActivator : AOnEnable
    {
        public ProbabilityBehaviour[] behaviours;

        protected override void OnEnable()
        {
            var index = ProbabilityUtility.PickIndex(behaviours);
            for (int i = 0; behaviours != null && i < behaviours.Length; i++)
                behaviours[i].gameObject.SetActive(i == index);
        }
    }
}