using UnityEngine;

namespace Andtech.Ego
{

    public static class CrosshairExtensions
    {

        public static void Link(this Crosshair crosshair, ActionPoint actionPoint)
        {
            crosshair.AngleStrategy = () => new Vector2(actionPoint.HorizontalAngle, actionPoint.VerticalAngle);
        }
    }
}
