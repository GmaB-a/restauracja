using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcurrencyList : MonoBehaviour
{

    public void Update()
    {
        Time.timeScale = 0f;
    }
    public void DestroyThis()
    {
        Destroy(gameObject);
        Time.timeScale = 1f;
    }
}
