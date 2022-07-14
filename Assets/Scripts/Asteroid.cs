using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 12.0f;

    [SerializeField]
    private GameObject _asteroidExplosion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * _rotationSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D  collision)
    {

        if(collision.tag == "Laser")
        {
            Instantiate(_asteroidExplosion, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            
        }
    }
}
