using UnityEngine;

namespace TheLuxGames.SharedResources.UnityMessageInvocation
{
    public class OnTrigger2DEnterEventInvoker : OnTrigger2DEventInvoker
    {
        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            _callback.Invoke(other);
        }
    }
}
