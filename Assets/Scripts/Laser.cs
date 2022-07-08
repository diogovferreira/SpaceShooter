using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    private float _laserSpeed = 8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * Time.deltaTime * _laserSpeed);


        if(transform.position.y >= 7.18)
        {
            if(transform.parent != null)
            {
                Destroy(transform.parent.gameObject, 0f);
            }
            Destroy(gameObject,0f);
        }
    }
}
