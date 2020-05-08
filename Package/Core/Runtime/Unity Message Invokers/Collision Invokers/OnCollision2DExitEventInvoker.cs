using UnityEngine;

namespace TheLuxGames.SharedResources.UnityMessageInvocation
{
    public class OnCollision2DExitEventInvoker : OnCollision2DEventInvoker
    {
        protected virtual void OnCollisionExit2D(Collision2D other)
        {
            _callback.Invoke(other);
        }
    }
}