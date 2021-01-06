using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 10, 10); 
    }

    // Update is called once per frame
    void Spawn()
    {
        Instantiate(Enemy, transform.position, transform.rotation);
    }
}
