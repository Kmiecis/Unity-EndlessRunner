using UnityEngine;

namespace Game
{
    public class RenderersEnableDisabler : AOnEnable
    {
        public Renderer[] renderers;

        protected override void OnEnable()
        {
            for (int i = 0; renderers != null && i < renderers.Length; i++)
            {
                renderers[i].enabled = false;
            }
        }
    }
}