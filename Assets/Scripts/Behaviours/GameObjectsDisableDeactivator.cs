namespace Game
{
    public class GameObjectsDisableDeactivator : GameObjectsActivator, IOnDisable
    {
        public void OnDisable()
        {
            Deactivate();
        }
    }
}