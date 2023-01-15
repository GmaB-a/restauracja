using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerManager : MonoBehaviour
{
    private static CustomerManager _instance;
    public static CustomerManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    [SerializeField] private GameObject customerPrefab;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject dialogue;
    [SerializeField] private Dialogue dialogueManager;
    [SerializeField] private Image BurgerImage;

    [SerializeField] private Sprite[] customersSprites;
    [SerializeField] private Sprite chinese;
    [SerializeField] private Sprite spanish;
    [SerializeField] private Sprite indian;

    public int chineseNum;
    public int spanishNum;
    public int indianNum;

    public BurgerScriptableObjects burgerWanted;
    void Start()
    {
        int customerPerGame = GameManager.Instance.customerPerGame;

        chineseNum = Random.Range(1, customerPerGame - 1);
        spanishNum = Random.Range(1, customerPerGame - 1);
        while(spanishNum == chineseNum) spanishNum = Random.Range(1, customerPerGame - 1);
        indianNum = Random.Range(1, customerPerGame - 1);
        while (indianNum == chineseNum || indianNum == spanishNum) indianNum = Random.Range(1, customerPerGame - 1);

        SpawnCustomer();
    }

    private GameObject customer;
    public void SpawnCustomer()
    {
        customer = Instantiate(customerPrefab, canvas.transform);
        customer.transform.SetSiblingIndex(1);

        Sprite newCustomerSprite;
        if (CheckCustomerNumbers(chineseNum)) newCustomerSprite = chinese;
        else if ((CheckCustomerNumbers(spanishNum))) newCustomerSprite = spanish;
        else if ((CheckCustomerNumbers(indianNum))) newCustomerSprite = indian;
        else newCustomerSprite = customersSprites[Random.Range(0, customersSprites.Length)];
        customer.GetComponent<CustomerScript>().ChangeSprite(newCustomerSprite);

        burgerWanted = dialogueManager.ChooseBurger();
        BurgerImage.sprite = burgerWanted.BurgerSprite;

        customer.GetComponent<CustomerScript>().Dialogue = dialogue;
        customer.GetComponent<Animation>().Play("CustomerSpawnAnim");

    }

    public bool CheckCustomerNumbers(int num)
        => GameManager.Instance.CurrentCustomer == num;
    

    public void CustomerGoAway()
    {
        customer.GetComponent<Animation>().Play("CustomerGoAwayAnim");
    }
}
