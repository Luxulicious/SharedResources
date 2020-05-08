using UnityEngine;

namespace TheLuxGames.SharedResources.Functionals
{
    [CreateAssetMenu(fileName = "Rigidbody2D Functional", menuName = "Functionals/UnityEngine/Rigidbody2D")]
    public class Rigidbody2DFunctional : ScriptableObject
    {
        public void SetVelocityYToZero(Rigidbody2D rb)
        {
            if (rb)
                rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        public void SetVelocityToZero(Rigidbody2D rb)
        {
            if (rb)
                rb.velocity = Vector2.zero;
        }
    }
}