using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;

    [SerializeField]
    private int powerupID;

 


    // Update is called once per frame
    void Update()
    {

        Movement();
        if (transform.position.y < -5.8f)
        {
            Destroy(gameObject, 0f);
        }
    }

    private void Movement()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player playerComponent = collision.transform.GetComponent<Player>();

            switch (powerupID)
            {
                case 0: 
                    playerComponent.setTripleShotActive();
                    break;
                case 1:
                    playerComponent.activatePowerUpSpeed();
                    break;
                case 2:
                    playerComponent.activatePowerUpShield();
                    break;
                case 3:
                    break;
            }
            
            Destroy(this.gameObject);
        }
    }
}
