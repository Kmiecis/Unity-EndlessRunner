namespace Game
{
    public class AudioSourceFinishDeactivator : AOnAudioSourceFinish
    {
        protected override void OnFinish()
        {
            m_AudioSource.gameObject.SetActive(false);
        }
    }
}