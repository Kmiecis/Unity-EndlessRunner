using UnityEngine;

namespace Game
{
    public class RenderersEnabler : MonoBehaviour
    {
        public Renderer[] renderers;

        public void Enable()
        {
            for (int i = 0; renderers != null && i < renderers.Length; i++)
                renderers[i].enabled = true;
        }

        public void Disable()
        {
            for (int i = 0; renderers != null && i < renderers.Length; i++)
                renderers[i].enabled = false;
        }
    }
}