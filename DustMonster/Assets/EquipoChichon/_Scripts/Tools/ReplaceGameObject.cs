using UnityEngine;

[ExecuteInEditMode]
public class ReplaceGameObject : MonoBehaviour
{
    private GameObject objectToReplace;
    public GameObject newObjectPrefab;

    // Call this function to perform the replacement
    private void OnValidate()
    {
        if(newObjectPrefab != null)
        {
            Replace();
        }
    }

    public void Replace()
    {
        objectToReplace = this.gameObject;
        if (objectToReplace != null && newObjectPrefab != null)
        {
            // Get the current position of the object to replace
            Vector3 currentPosition = objectToReplace.transform.position;

            // Calculate the new position with y set to 0
            Vector3 newPosition = new Vector3(currentPosition.x, 0, currentPosition.z);

            // Instantiate the new object at the calculated position
            GameObject newObject = Instantiate(newObjectPrefab, newPosition, Quaternion.identity);

            // Destroy the old object
            Destroy(objectToReplace);

            // Log the replacement (optional)
            Debug.Log($"Replaced {objectToReplace.name} with {newObject.name} at position {newPosition}");
        }
        else
        {
            Debug.LogError("Object to replace or new object prefab is not assigned.");
        }
    }

}
