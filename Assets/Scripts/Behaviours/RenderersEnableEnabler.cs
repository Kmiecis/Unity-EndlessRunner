namespace Game
{
    public class RenderersEnableEnabler : RenderersEnabler, IOnEnable
    {
        public void OnEnable()
        {
            Enable();
        }
    }
}