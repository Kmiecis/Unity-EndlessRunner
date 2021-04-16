using UnityEngine;

namespace Game
{
    public class BehavioursEnabler : MonoBehaviour
    {
        public Behaviour[] behaviours;

        public void Enable()
        {
            for (int i = 0; behaviours != null && i < behaviours.Length; i++)
                behaviours[i].enabled = true;
        }

        public void Disable()
        {
            for (int i = 0; behaviours != null && i < behaviours.Length; i++)
                behaviours[i].enabled = false;
        }
    }
}