using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheLuxGames.SharedResources.Util.Math
{
    public static class Polygon
    {
        //TODO Maybe move to vector2 extensions
        public static bool IsInPolygon(this Vector2 p, Vector2[] polygon)
        {
            double minX = polygon[0].x;
            double maxX = polygon[0].x;
            double minY = polygon[0].y;
            double maxY = polygon[0].y;
            for (int i = 1; i < polygon.Length; i++)
            {
                Vector2 q = polygon[i];
                minX = System.Math.Min(q.x, minX);
                maxX = System.Math.Max(q.x, maxX);
                minY = System.Math.Min(q.y, minY);
                maxY = System.Math.Max(q.y, maxY);
            }

            if (p.x < minX || p.x > maxX || p.y < minY || p.y > maxY)
            {
                return false;
            }

            // http://www.ecse.rpi.edu/Homepages/wrf/Research/Short_Notes/pnpoly.html
            bool inside = false;
            for (int i = 0, j = polygon.Length - 1; i < polygon.Length; j = i++)
            {
                if ((polygon[i].y > p.y) != (polygon[j].y > p.y) &&
                    p.x < (polygon[j].x - polygon[i].x) * (p.y - polygon[i].y) / (polygon[j].y - polygon[i].y) +
                    polygon[i].x)
                {
                    inside = !inside;
                }
            }

            return inside;
        }

        public static void DrawPolygon(Action<Vector3, Vector3> draw, Vector2 origin, List<Vector2> polygon,
            Color color)
        {
            UnityEngine.Gizmos.color = color;
            for (int i = 0; i < polygon.Count; i++)
            {
                if (i != polygon.Count - 1)
                    draw(origin + polygon[i], origin + polygon[i + 1]);
                else
                    draw(origin + polygon[i], origin + polygon[0]);
            }
        }
    }
}