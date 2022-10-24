using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerManager : MonoBehaviour
{
    [SerializeField] private GameObject customerPrefab;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private Image dialogue;
    //public bool NeedSpawnNewCustomer = false;
    void Start()
    {
        GameObject customer = Instantiate(customerPrefab, spawnPos);
    }
}
