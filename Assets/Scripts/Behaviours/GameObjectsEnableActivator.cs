namespace Game
{
    public class GameObjectsEnableActivator : GameObjectsActivator, IOnEnable
    {
        public void OnEnable()
        {
            Activate();
        }
    }
}