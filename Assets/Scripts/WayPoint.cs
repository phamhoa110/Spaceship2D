using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public static Transform[] _WayPoint;
    private void Awake()
    {

        _WayPoint = new Transform[transform.childCount];

        for (int i = 0; i < _WayPoint.Length; i++)
        {
            _WayPoint[i] = transform.GetChild(i);
        }
    }
}
