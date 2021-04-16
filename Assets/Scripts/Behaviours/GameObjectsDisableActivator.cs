namespace Game
{
    public class GameObjectsDisableActivator : GameObjectsActivator, IOnDisable
    {
        public void OnDisable()
        {
            Activate();
        }
    }
}