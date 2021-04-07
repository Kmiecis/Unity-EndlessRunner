using UnityEngine;

namespace Game
{
    public class BehavioursEnableDisabler : AOnEnable
    {
        public Behaviour[] behaviours;

        protected override void OnEnable()
        {
            for (int i = 0; behaviours != null && i < behaviours.Length; i++)
            {
                behaviours[i].enabled = false;
            }
        }
    }
}