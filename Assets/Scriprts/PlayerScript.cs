using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed;
    public GameObject Bullet;
    public Transform Dir;
    //public int Bullets;
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
        }

        Vector3 difference = mousePosition - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
        if (Input.GetMouseButtonDown(1))//Bullets > 0))
        {
            Instantiate(Bullet, Dir.position, transform.rotation);
            //Bullets--;

        }
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
      {
          if(collision.gameObject.tag == "Bullet")
          {
              Bullets++;
              Destroy(collision.gameObject);
          }
   */
}