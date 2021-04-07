using UnityEngine;

namespace Game
{
    public class BehavioursDisableDisabler : AOnDisable
    {
        public Behaviour[] behaviours;

        protected override void OnDisable()
        {
            for (int i = 0; behaviours != null && i < behaviours.Length; i++)
            {
                behaviours[i].enabled = false;
            }
        }
    }
}