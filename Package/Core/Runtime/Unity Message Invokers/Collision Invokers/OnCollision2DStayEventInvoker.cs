using UnityEngine;

namespace TheLuxGames.SharedResources.UnityMessageInvocation
{
    public class OnCollision2DStayEventInvoker : OnCollision2DEventInvoker
    {
        protected virtual void OnCollisionStay2D(Collision2D other)
        {
            _callback.Invoke(other);
        }
    }
}