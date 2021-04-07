using UnityEngine;

namespace Game
{
    public class RenderersDisableDisabler : AOnDisable
    {
        public Renderer[] renderers;

        protected override void OnDisable()
        {
            for (int i = 0; renderers != null && i < renderers.Length; i++)
            {
                renderers[i].enabled = false;
            }
        }
    }
}