namespace Game
{
    public class GameObjectsEnableDeactivator : GameObjectsActivator, IOnEnable
    {
        public void OnEnable()
        {
            Deactivate();
        }
    }
}