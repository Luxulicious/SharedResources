using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheLuxGames.SharedResources.Functionals
{
    [CreateAssetMenu(fileName = "Scene Manager", menuName = "Functionals/UnityEngine/SceneManager")]
    public class SceneManagerFunctional : ScriptableObject
    {
        public void Reload()
        {
            SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene()
                .name);
        }

        public void LoadScene(int sceneBuildIndex)
        {
            SceneManager.LoadScene(sceneBuildIndex);
        }
        
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}