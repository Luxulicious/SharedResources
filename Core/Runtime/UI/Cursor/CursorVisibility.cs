using UnityEngine;
using UnityEngine.EventSystems;

//TODO Expand on namespace maybe
namespace TheLuxGames.SharedResources.Cursor
{
    public class CursorVisibility : MonoBehaviour, ISelectHandler
    {
        [SerializeField] private bool visible = false;

        void Start()
        {
            UnityEngine.Cursor.visible = visible;
        }

        public void OnSelect(BaseEventData eventData)
        {
            UnityEngine.Cursor.visible = visible;
        }
    }
}
