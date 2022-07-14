using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _speed = 5f;
    [SerializeField]
    private GameObject _laserPrefab;
    private float _canFire = -1;

    [SerializeField]
    private int _lives = 3;

    [SerializeField]
    private float _fireRate = 0.5f;
    private SpawnManager _spawnManager;


    private bool _isTripleActive = false;
    private bool _isSpeedBoostActive = false;
    private bool _isShieldActive = false;
    [SerializeField]
    private GameObject _tripleShotPrefab;

    [SerializeField]
    private GameObject _playerShield;

    [SerializeField]
    private int _score;

    private UIManager _uIManager;

    [SerializeField]
    private GameObject _rightEngine;
    [SerializeField]
    private GameObject _leftEngine;



    void Start()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if(_spawnManager == null)
        {
            Debug.Log("Spawn Manager is NULL");
        }

        if(_uIManager == null)
        {
            Debug.Log("UI Manager is NULL");
        }

        _uIManager.updateLives(_lives);
    }

    void Update()
    {
        PlayerMovement();
        Shoot();
       
    }

    private void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 directon = new Vector3(horizontal, vertical, 0);
        transform.Translate(directon * _speed * Time.deltaTime);


        float leftBoundarie = -11.24f;
        float rightBoundarie = 11.24f;
        float topBoundarie = 6f;
        float bottomBoundarie = -4f;

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, bottomBoundarie, topBoundarie), 0);

        if (transform.position.x >= rightBoundarie)
        {
            transform.position = new Vector3(leftBoundarie, transform.position.y, 0);
        }
        else if (transform.position.x <= leftBoundarie)
        {
            transform.position = new Vector3(rightBoundarie, transform.position.y, 0);
        }
        
    }

    private void Shoot()
    {

        float offset = 0.8f;

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {

            _canFire = Time.time + _fireRate;
            if (_isTripleActive)
            {  
                Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(_laserPrefab, new Vector3(transform.position.x, transform.position.y + offset, 0), Quaternion.identity);
            }
            
        }

    }

    public void Damage()
    {
        if (_isShieldActive)
        {
            _isShieldActive = false;
            _playerShield.SetActive(false);
            return;
        }
            _lives--;

        if(_lives == 2)
        {
            _rightEngine.SetActive(true);
        }else if(_lives == 1)
        {
            _leftEngine.SetActive(true);
        }
        else
        {
            _rightEngine.SetActive(false);
            _leftEngine.SetActive(false);

        }
        _uIManager.updateLives(_lives);

            if (_lives < 1)
            {
                _spawnManager.onPlayerDead();
                Destroy(this.gameObject);
            }
    }


    public void setTripleShotActive()
    {
        _isTripleActive = true;
        StartCoroutine(PowerDownTripleShot());
    }

    public void activatePowerUpSpeed()
    {
        _isSpeedBoostActive = true;
        _speed = 8f;
        StartCoroutine(PowerDownSpeedPowerUp());
    }

    public void activatePowerUpShield()
    {
        _isShieldActive = true;
        _playerShield.SetActive(_isShieldActive);
    }

    IEnumerator PowerDownTripleShot()
    {
        while (_isTripleActive)
        {
            yield return new WaitForSeconds(5);
            _isTripleActive = false;
        }
    }

    IEnumerator PowerDownSpeedPowerUp()
    {
        while (_isSpeedBoostActive)
        {
            yield return new WaitForSeconds(5);
            _speed = 5f;
            _isSpeedBoostActive = false;
        }
    }

    public void addToScore(int points)
    {
        //increment score
        _score += points;
        //Communicate to UIManager
        _uIManager.addToScore(_score);
 
    }

    public void decreaseLives(int currentLives)
    {
        _uIManager.updateLives(currentLives);
    }

}
 