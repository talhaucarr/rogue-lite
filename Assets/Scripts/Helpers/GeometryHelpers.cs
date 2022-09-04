using System;
using UnityEngine;

namespace Utilities
{
    public static class Geometry
    {
        public static double DistanceFromPointToLine(Vector2 startPoint, Vector2 endPoint, Vector2 point)
        {
            double s1 = endPoint.y - startPoint.y;
            double s2 = endPoint.x - startPoint.x;
            return Math.Abs((point.x - startPoint.x) * s1 + (point.y - startPoint.y) * s2) / Math.Sqrt(s1*s1 + s2*s2);
        }
        
        public static Vector2 NearestPointOnFiniteLine(Vector2 startPoint, Vector2 endPoint, Vector2 point)
        {
            var line = (endPoint - startPoint);
            var lineLength = line.magnitude;
            line.Normalize();

            var v = point - startPoint;
            var d = Vector2.Dot(v, line);
            d = Mathf.Clamp(d, 0f, lineLength);
            return startPoint + line * d;
        }
    }
}