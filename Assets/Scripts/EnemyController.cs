using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // public GameObject Player;
    public GameObject enemyBulletPrefab;
    public float enemyBulletSpeed = 5f;
    public float fireRate = 1f;
    private float nextFire = 0.5f;
    void Update()
    {

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            FireBullet();
        }

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextTarget();
        }
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        while (targetIndex == 3)
        {
            targetIndex = 0;
        }
    }

    private void FireBullet()
    {
        GameObject enemyBullet = Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);
        enemyBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -enemyBulletSpeed);
        //enemyBullet.GetComponent<Rigidbody2D>().AddForce(enemyBulletSpeed * new Vector2(0, 1), ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Normal_Bullet") || collision.CompareTag("Rocket_1") || collision.CompareTag("Player"))
        {
            //Destroy(gameObject);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
    public float speed;
    private Transform target;
    private int targetIndex = 0;

    void Start()
    {
        target = WayPoint._WayPoint[0];
    }

    void GetNextTarget()
    {
        if (targetIndex >= WayPoint._WayPoint.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        targetIndex++;
        target = WayPoint._WayPoint[targetIndex];
    }
}
