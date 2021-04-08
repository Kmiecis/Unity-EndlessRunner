namespace Game
{
    public class AudioSourceFinishDestroyer : AOnAudioSourceFinish
    {
        protected override void OnFinish()
        {
            Destroy(m_AudioSource.gameObject);
        }
    }
}