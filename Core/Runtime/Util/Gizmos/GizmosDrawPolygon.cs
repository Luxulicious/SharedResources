using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TheLuxGames.SharedResources.Util.Gizmos
{
    public class GizmosDrawPolygon : MonoBehaviour
    {
        public Color color = Color.blue;
        public List<Transform> points = new List<Transform>();

        void Start()
        {
            if (!points.Any())
            {
                foreach (Transform child in this.transform)
                {
                    points.Add(child);
                }
            }
        }

        void OnDrawGizmos()
        {
            UnityEngine.Gizmos.color = color;
            for (int i = 0; i < points.Count; i++)
            {
                DrawCross(points[i].position, 0.1f);
                if (i + 1 < points.Count)
                    UnityEngine.Gizmos.DrawLine(points[i].position, points[i + 1].position);
                else
                    UnityEngine.Gizmos.DrawLine(points[i].position, points[0].position);
            }

        }

        //TODO Move this to it's own class
        public void DrawCross(Vector2 point, float size)
        {
            UnityEngine.Gizmos.DrawLine(point, point + new Vector2(size, size));
            UnityEngine.Gizmos.DrawLine(point, point + new Vector2(-size, size));
            UnityEngine.Gizmos.DrawLine(point, point + new Vector2(-size, -size));
            UnityEngine.Gizmos.DrawLine(point, point + new Vector2(size, -size));
        }
    }
}