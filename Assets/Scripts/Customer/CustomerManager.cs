using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerManager : MonoBehaviour
{
    [SerializeField] private GameObject customerPrefab;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Image dialogue;
    [SerializeField] private Sprite[] customersSprites;
    //public bool NeedSpawnNewCustomer = false;
    void Start()
    {
        SpawnCustomer();
    }

    void SpawnCustomer()
    {
        GameObject customer = Instantiate(customerPrefab, canvas.transform);
        customer.transform.SetSiblingIndex(1);
        customer.GetComponent<CustomerScript>().dialogue = dialogue;
        Sprite newCustomerSprite = customersSprites[Random.Range(0, customersSprites.Length)];
        customer.GetComponent<CustomerScript>().ChangeSprite(newCustomerSprite);
    }
}
