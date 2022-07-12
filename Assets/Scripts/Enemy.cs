using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }


    public void Movement()
    {

        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        if(transform.position.y <= -5.2f)
        {
            transform.position = new Vector3(Random.Range(-9.74f,9.74f), 7.2f, 0);
        }
    }


   
        
    

private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player")
        {
            Destroy(gameObject);

            Player player = collision.transform.GetComponent<Player>();

            if(player != null)
            {
                player.Damage();
            }

        }else if(collision.tag == "Laser")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
