using UnityEngine;

public static class VectorsExtension
{
   public static Vector3 WithAxis(this Vector3 vector, Axis axis, float vaule)
   {
        return new Vector3(
            x:axis == Axis.X ? vaule : vector.x,
            y: axis == Axis.Y ? vaule : vector.y,
            z: axis == Axis.Z ? vaule : vector.z
            );
   }
}
    // Update is called once per frame
public enum Axis
{
        X, Y, Z
}
