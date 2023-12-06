using UnityEngine;

public class ScrollBackground : MonoBehaviour
{

    public float speed = -2f;
    public float lowY = -20f;
    public float upY = 40f;

    void Update()
    {
        transform.Translate(0.0f, speed * Time.deltaTime, 0.0f);
        if (transform.position.y <= lowY)
        {
            transform.Translate(0.0f, upY, 0.0f);
        }
    }
}
