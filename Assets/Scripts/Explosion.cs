using UnityEngine;

public class Explosion : MonoBehaviour
{
    private SpawnManager _spawnManager;

    [SerializeField]
    private AudioClip _explosionAudioClip;
    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _audioSource = GetComponent<AudioSource>();

        if (_audioSource == null)
        {
            Debug.Log("AudioSource is NULL");
        }
        else
        {
            _audioSource.clip = _explosionAudioClip;
        }

        _audioSource.Play();
        _spawnManager.StartSpawning();
        Destroy(gameObject, 2.4f);
    }


}
