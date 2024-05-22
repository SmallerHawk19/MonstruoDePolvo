using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private BoosterType boosterType;
    [SerializeField] private float _valueToChange = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectItem();
            Destroy(gameObject);
        }
    }

    private void CollectItem()
    {
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
}
