using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class KatamariCollectibles : MonoBehaviour
{
    [HideInInspector] public DustSpawner DustSpawner;

    public float CollectibleSize = 1f;

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = true; //Disbale the RB when it collides with the ground
    }

    public void Collect(Transform katamariBall)
    {
        GameManager.Instance.ColledItem();
        DustSpawner.DustCollected();
        transform.GetComponent<Collider>().enabled = false;
        transform.parent = katamariBall;
        Destroy(this);
    }
}
