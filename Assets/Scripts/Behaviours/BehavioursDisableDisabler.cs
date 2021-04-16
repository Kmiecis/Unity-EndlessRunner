namespace Game
{
    public class BehavioursDisableDisabler : BehavioursEnabler, IOnDisable
    {
        public void OnDisable()
        {
            Disable();
        }
    }
}