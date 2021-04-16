namespace Game
{
    public class BehavioursDisableEnabler : BehavioursEnabler, IOnDisable
    {
        public void OnDisable()
        {
            Enable();
        }
    }
}