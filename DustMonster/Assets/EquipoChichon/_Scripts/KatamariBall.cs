using UnityEngine;

public class KatamariBall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        KatamariCollectibles collectible = collision.transform.GetComponent<KatamariCollectibles>();

        if(collectible != null)
        {
            collectible.Collect(this.transform);
        }
    }
}
