using UnityEngine;

namespace TheLuxGames.SharedResources.UnityMessageInvocation
{
    public class OnCollision2DEnterEventInvoker : OnCollision2DEventInvoker
    {
        protected virtual void OnCollisionEnter2D(Collision2D other)
        {
            _callback.Invoke(other);
        }
    }
}