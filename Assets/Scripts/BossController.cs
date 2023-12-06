using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public GameObject bossBulletPrefab;
    public float bossBulletSpeed = 10f;

    public float fireRate = 1f;
    private float nextFire = 0.5f;

    private Transform playerTransform;
    private Rigidbody2D rb;
    private Vector2 targetPosition;
    private float minX, minY, maxX, maxY;

    private void Awake()
    {
        minX = -22;
        maxX = 22;
        minY = 0;
        maxY = transform.position.y;
    }
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        targetPosition = GetRandomPosition();
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = GetRandomPosition();
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
        }
    }
    private Vector2 GetRandomPosition()
    {
        float ranX = Random.Range(minX, maxX);
        float ranY = Random.Range(minY, maxY);
        return new Vector2(ranX, ranY);
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(bossBulletPrefab, transform.position, Quaternion.identity);
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bossBulletSpeed;
    }



}
