using UnityEngine;

namespace TheLuxGames.SharedResources.Functionals
{
    namespace Functionals
    {
        [CreateAssetMenu(fileName = "Debug", menuName = "Functionals/UnityEngine/Debug")]
        public class DebugFunctional : ScriptableObject
        {
            public void Break()
            {
                UnityEngine.Debug.Break();
            }

            public void Log(string message)
            {
                UnityEngine.Debug.Log(message);
            }
        }
    }
}