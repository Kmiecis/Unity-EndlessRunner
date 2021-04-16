namespace Game
{
    public class RenderersDisableEnabler : RenderersEnabler, IOnDisable
    {
        public void OnDisable()
        {
            Enable();
        }
    }
}