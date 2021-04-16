namespace Game
{
    public class Destroy2D : Hit2D
    {
        protected override void OnPlayerEnter(Player player)
        {
            if (player.canDestroy)
            {
                base.OnPlayerEnter(player);
            }
        }
    }
}