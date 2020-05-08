using UnityEngine;

namespace TheLuxGames.SharedResources.UnityMessageInvocation
{
    public class OnTrigger2DStayEventInvoker : OnTrigger2DEventInvoker
    {
        protected virtual void OnTriggerStay2D(Collider2D other)
        {
            _callback.Invoke(other);
        }
    }
}