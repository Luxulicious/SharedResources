namespace TheLuxGames.SharedResources.UnityMessageInvocation
{
    public class OnAwakeEventInvoker : VoidEventInvoker
    {
        private void Awake()
        {
            _callback.Invoke();
        }
    }
}