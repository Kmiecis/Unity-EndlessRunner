namespace Game
{
    public class RenderersDisableDisabler : RenderersEnabler, IOnDisable
    {
        public void OnDisable()
        {
            Disable();
        }
    }
}