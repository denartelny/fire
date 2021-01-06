using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform Player;
    public GameObject Bullet;
    public Transform Dir;
    public int DestroyTime;
    public float speed;


    void Start()
        
    {
        Player = GameObject.Find("Player").transform;
        InvokeRepeating("Attack", 2, 2);
        Invoke("DestroyEnemy", DestroyTime);
    }


    void Update()
    {

        Vector3 moveDirection = Player.position - transform.position;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(-moveDirection.x, moveDirection.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            Vector3 directionToTarget = (Player.transform.position - transform.position).normalized;
            transform.Translate(directionToTarget * speed * Time.deltaTime);

            Vector3 delta = Player.position - transform.position;
            delta.Normalize();

            float moveSpeed = speed * Time.deltaTime;
            transform.position = transform.position + (delta * moveSpeed);

        }

    }
    void Attack()
    {
        Instantiate(Bullet, Dir.position, transform.rotation);

    }
    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
