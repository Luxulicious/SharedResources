using UnityEngine;

namespace TheLuxGames.SharedResources.UnityMessageInvocation
{
    public class OnTrigger2DExitEventInvoker : OnTrigger2DEventInvoker
    {
        protected virtual void OnTriggerExit2D(Collider2D other)
        {
            _callback.Invoke(other);
        }
    }
}