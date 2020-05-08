namespace TheLuxGames.SharedResources.UnityMessageInvocation
{
    public class OnUpdateEventInvoker : VoidEventInvoker
    {
        private void Update()
        {
            _callback.Invoke();
        }
    }
}