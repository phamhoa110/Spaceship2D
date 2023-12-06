using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject rocketPrefab;


    private bool check = false;
    public float speed = 10f;
    public float reloadBulletTime = 0.3f;
    private float elapsedTime = 0f;
    private float timeToUseRocket = 0f;
    private float minX, minY, maxX, maxY;

    private void Start()
    {
        minX = -22f;
        maxX = 22f;
        minY = -10f;
        maxY = 10f;
    }
    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (check)
        {
            timeToUseRocket += Time.deltaTime;
        }
        RangeToMove();
        Move();
        Fire();
    }
    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 position = new Vector3(moveHorizontal, moveVertical, 0.0f);
        transform.position += position * speed * Time.deltaTime;
    }

    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space) && elapsedTime > reloadBulletTime)
        {
            if (check && (timeToUseRocket > 0f && timeToUseRocket < 10f))
            {
                ChangeBullet(rocketPrefab);

            }
            else
            {
                check = false;
                timeToUseRocket = 0f;
                reloadBulletTime = 0.1f;
                ChangeBullet(bulletPrefab);
            }
        }
    }
    void ChangeBullet(GameObject otherBullet)
    {
        Vector3 spawnPos = transform.position;
        spawnPos += new Vector3(0.0f, 1.2f, 0.0f);
        GameObject bullet = Instantiate(otherBullet, spawnPos, Quaternion.identity);
        elapsedTime = 0f;
    }
    void RangeToMove()
    {
        if (transform.position.x < minX)
            transform.position = new Vector3(minX, transform.position.y);
        if (transform.position.x > maxX)
            transform.position = new Vector3(maxX, transform.position.y);
        if (transform.position.y < minY)
            transform.position = new Vector3(transform.position.x, minY);
        if (transform.position.y > maxY)
            transform.position = new Vector3(transform.position.x, maxY);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rocket_1")
        {
            if (!check)
            {
                check = true;
                reloadBulletTime = 0.2f;
                //collision.gameObject.SetActive(false);
                Destroy(collision.gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
            //Time.timeScale = 0f;
        }
    }
}
