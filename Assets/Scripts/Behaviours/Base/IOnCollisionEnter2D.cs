using UnityEngine;

namespace Game
{
    public interface IOnCollisionEnter2D
    {
        void OnCollisionEnter2D(Collision2D collision);
    }
}