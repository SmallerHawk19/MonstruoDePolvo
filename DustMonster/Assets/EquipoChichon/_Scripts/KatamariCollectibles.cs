using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]


public class KatamariCollectibles : MonoBehaviour
{
    [HideInInspector] public DustSpawner DustSpawner;
    [SerializeField] private int _collectiblePoints = 1;

    public float CollectibleSize = 1f;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = true; //Disbale the RB when it collides with the ground
    }

    public void Collect(Transform katamariBall)
    {
        transform.parent = katamariBall;
        transform.GetComponent<Collider>().enabled = false;
        GameManager.Instance.CollectedItem();
        GameManager.Instance.AddScore(_collectiblePoints);
        DustSpawner.DustCollected();
        PlaySound();
        Destroy(this);
    }

    private void PlaySound()
    {
        _audioSource.pitch = Random.Range(0.8f, 1.2f);
        _audioSource.Play();
    }
}
