using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [Scene]
    [SerializeField] private string _sceneToLoad;

    public void LoadScene()
    {
        SceneManager.LoadScene(_sceneToLoad);
    }
}
