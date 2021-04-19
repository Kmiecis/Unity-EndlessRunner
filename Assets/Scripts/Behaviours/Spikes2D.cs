namespace Game
{
    public class Spikes2D : AOnPlayerTriggerEnter2D
    {
        public float snareDuration;

        protected override void OnPlayerEnter(Player player)
        {
            player.SetSnared(snareDuration);
        }
    }
}