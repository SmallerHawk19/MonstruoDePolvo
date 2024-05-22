using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterCollectionManager : MonoBehaviour
{
   public static BoosterCollectionManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
