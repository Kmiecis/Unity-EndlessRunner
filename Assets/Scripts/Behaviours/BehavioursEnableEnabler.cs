namespace Game
{
    public class BehavioursEnableEnabler : BehavioursEnabler, IOnEnable
    {
        public void OnEnable()
        {
            Enable();
        }
    }
}