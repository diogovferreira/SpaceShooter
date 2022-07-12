using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private GameObject _enemyContainer;

    [SerializeField]
    private GameObject[] _listOfPowerUps; 

    private bool _stopSpwaning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUps());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (_stopSpwaning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-9.5f, 9.5f), 8f, 0f);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn,Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }

    }

    IEnumerator SpawnPowerUps()
    {
        while(_stopSpwaning == false)
        {
            Vector3 posToSpwan = new Vector3(Random.Range(-9.5f,9.5f),8f,0f);
            int powerUpPosition = Random.Range(0, _listOfPowerUps.Length);
            GameObject newPowerUp = Instantiate(_listOfPowerUps[powerUpPosition], posToSpwan, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(5,10));
        }
    }

    public void onPlayerDead()
    {
        _stopSpwaning = true;
    }
}
