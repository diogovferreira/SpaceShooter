using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    // Start is called before the first frame update

    private Player _player;

    private Animator _enemyAnimator;
    void Start()
    {
        _enemyAnimator = GetComponent<Animator>();
        _player = GameObject.Find("Player").GetComponent<Player>();

        if(_player == null)
        {
            Debug.Log("Player is NULL");
        }

        if(_enemyAnimator == null)
        {
            Debug.Log("Enemy Animator is NULL");
        }
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
            DestroyEnemy();
            Player player = collision.transform.GetComponent<Player>();

            if(player != null)
            {
                player.Damage();
            }

        }
        else if(collision.tag == "Laser"){

            Destroy(collision.gameObject);
            if (_player != null)
            {
                _player.addToScore(10);
            }

            DestroyEnemy();
        }
    }

    private void DestroyEnemy()
    {
        _enemyAnimator.SetTrigger("onEnemyDeath");
        _speed = 0f;
        Destroy(gameObject, 2.45f);
    }
}



