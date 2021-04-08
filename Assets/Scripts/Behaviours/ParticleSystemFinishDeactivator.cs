namespace Game
{
    public class ParticleSystemFinishDeactivator : AOnParticleSystemFinish
    {
        protected override void OnFinish()
        {
            m_ParticleSystem.gameObject.SetActive(false);
        }
    }
}