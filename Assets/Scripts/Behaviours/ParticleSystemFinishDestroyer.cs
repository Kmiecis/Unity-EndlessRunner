namespace Game
{
    public class ParticleSystemFinishDestroyer : AOnParticleSystemFinish
    {
        protected override void OnFinish()
        {
            Destroy(m_ParticleSystem.gameObject);
        }
    }
}