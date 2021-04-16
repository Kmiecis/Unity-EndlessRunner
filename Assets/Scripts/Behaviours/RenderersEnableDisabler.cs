namespace Game
{
    public class RenderersEnableDisabler : RenderersEnabler, IOnEnable
    {
        public void OnEnable()
        {
            Disable();
        }
    }
}