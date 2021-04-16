namespace Game
{
    public class BehavioursEnableDisabler : BehavioursEnabler, IOnEnable
    {
        public void OnEnable()
        {
            Disable();
        }
    }
}