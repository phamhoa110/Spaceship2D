using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    private void Start()
    {
        Rigidbody2D bulletRb = GetComponent<Rigidbody2D>();
        bulletRb.velocity = new Vector2(0.0f, bulletSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet" || collision.gameObject.tag == "Boss")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
