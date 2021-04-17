namespace Game
{
    public class Pick2D : AOnPlayerTriggerEnter2D
    {
        public RenderersEnabler renderersEnabler;
        public BehavioursEnabler behavioursEnabler;
        public GameObjectsActivator objectsActivator;
        
        protected override void OnPlayerEnter(Player player)
        {
            objectsActivator.Activate();
            renderersEnabler.Disable();
            behavioursEnabler.Disable();
        }
    }
}