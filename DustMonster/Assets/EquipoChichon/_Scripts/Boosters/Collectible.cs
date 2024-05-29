using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private BoosterType boosterType;
    [SerializeField] private float _valueToChange = 0;
    [SerializeField] private AudioClip _audioClip;

    [HideInInspector] public DustSpawner DustSpawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlaySound();
            CollectItem();
            Destroy(gameObject);
        }
    }

    private void CollectItem()
    {
        DustSpawner.DustCollected();
        switch (boosterType)
        {
            case BoosterType.Time:
                GameManager.Instance.AddTime(_valueToChange);
                break;
            case BoosterType.Speed:
                GameManager.Instance.AddSpeed(_valueToChange);
                break;
            case BoosterType.Shield:
                GameManager.Instance.AddShield(_valueToChange);
                break;
        }
    }

    private void PlaySound()
    {
        AudioSource.PlayClipAtPoint(_audioClip, transform.position);
    }
}
