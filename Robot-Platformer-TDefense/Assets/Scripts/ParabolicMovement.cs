using UnityEngine;
 
public static class CurveMath
{

    public static Vector2 Lerp(Vector2 a, Vector2 b, float t)
    {
        return a + (b - a) * t;
    }

    //with 3 points you can create a parabolic movement
    // https://www.youtube.com/watch?v=RF04Fi9OCPc
    public static Vector2 QuadraticCurve(Vector2 a, Vector2 b, Vector2 c, float t)
    {
        Vector2 p0 = Lerp(a, b, t);
        Vector2 p1 = Lerp(b, c, t);
        return Lerp(p0, p1, t);
    }
}

