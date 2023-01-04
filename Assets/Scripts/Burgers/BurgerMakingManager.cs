using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BurgerMakingManager : MonoBehaviour
{
    private static BurgerMakingManager _instance;
    public static BurgerMakingManager Instance { get { return _instance; } }


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
    [SerializeField] private Image addToBurger;
    [SerializeField] private Image trash;
    [SerializeField] private GameObject[] ingridientPositions;
    private GameObject[] ingridientsInBurger;
    private int lastPositionOccupied;

    public bool IsHoldingAnIngridient;
    public string HoldIngridientName;
    public Image HoldIngridientImage;

    public BurgerScriptableObjects currentBurger;

    private void Start()
    {
        ingridientsInBurger = new GameObject[ingridientPositions.Length];
        lastPositionOccupied = 0;
    }

    private void Update()
    {
        if (IsHoldingAnIngridient)
        {
            if (CheckUIOverlap(HoldIngridientImage.rectTransform, trash.rectTransform)) TrashIngridient();
            if (CheckUIOverlap(HoldIngridientImage.rectTransform, addToBurger.rectTransform)) AddIngridientToBurger();
        }
    }

    private void TrashIngridient()
    {
        Destroy(HoldIngridientImage.gameObject);
        IsHoldingAnIngridient = false;
        HoldIngridientName = "";
    }


    private void AddIngridientToBurger()
    {
        switch (HoldIngridientName)
        {
            case "patty":
                currentBurger.HasPatty = true;
                break;
            case "tomato":
                currentBurger.HasTomato = true;
                break;
            case "cheese":
                currentBurger.HasCheese = true;
                break;
            case "onion":
                currentBurger.HasOnion = true;
                break;
            case "salad":
                currentBurger.HasSalad = true;
                break;
            case "upperBun":
                currentBurger.HasUpperBun = true;
                break;
        }

        if (lastPositionOccupied < ingridientPositions.Length && 
            !ingridientPositions[lastPositionOccupied].GetComponent<IngridientPositions>().isOccupied)
        {
            HoldIngridientImage.GetComponent<IngridientScript>().HasToFollowCursor = false;
            HoldIngridientImage.transform.position = ingridientPositions[lastPositionOccupied].transform.position;
            ingridientsInBurger[lastPositionOccupied] = HoldIngridientImage.gameObject;
            ingridientPositions[lastPositionOccupied].GetComponent<IngridientPositions>().isOccupied = true;
            lastPositionOccupied += 1;
            IsHoldingAnIngridient = false;
            HoldIngridientName = "";
        }
        else lastPositionOccupied += 1;
    }

    public void CheckBurgersEquality()
    {
        BurgerScriptableObjects burgerWanted = CustomerManager.Instance.burgerWanted;
        if (HasSameIngridients(burgerWanted))
        {
            CustomerManager.Instance.CustomerGoAway();
        }

        ResetCurrentIngridients();
    }

    private bool HasSameIngridients(BurgerScriptableObjects burgerWanted)
    {
        bool cheese = currentBurger.HasCheese == burgerWanted.HasCheese;
        bool patty = currentBurger.HasPatty == burgerWanted.HasPatty;
        bool salad = currentBurger.HasSalad == burgerWanted.HasSalad;
        bool onion = currentBurger.HasOnion == burgerWanted.HasOnion;
        bool tomato = currentBurger.HasTomato == burgerWanted.HasTomato;
        bool upperBun = currentBurger.HasUpperBun == burgerWanted.HasUpperBun;

        print("Cheese " + cheese);
        print("Patty " + patty);
        print("Salad " + salad);
        print("Onion " + onion);
        print("Tomato " + tomato);
        print("Bun " + upperBun);

        return cheese && patty && salad && onion && tomato && upperBun;
    }

    private void ResetCurrentIngridients()
    {
        foreach (GameObject ingridient in ingridientsInBurger)
        {
            Destroy(ingridient);
        }
        foreach (GameObject position in ingridientPositions)
        {
            position.GetComponent<IngridientPositions>().isOccupied = false;
        }
        lastPositionOccupied = 0;

        currentBurger.HasCheese = false;
        currentBurger.HasPatty = false;
        currentBurger.HasSalad = false;
        currentBurger.HasOnion = false;
        currentBurger.HasTomato = false;
        currentBurger.HasUpperBun = false;
    }

    private bool CheckUIOverlap(RectTransform rectTransform1, RectTransform rectTransform2)
    {
        Vector3[] corners = new Vector3[4];
        rectTransform1.GetWorldCorners(corners);
        Rect rec = new Rect(corners[0].x, corners[0].y, corners[2].x - corners[0].x, corners[2].y - corners[0].y);

        rectTransform2.GetWorldCorners(corners);
        Rect rec2 = new Rect(corners[0].x, corners[0].y, corners[2].x - corners[0].x, corners[2].y - corners[0].y);

        if (rec.Overlaps(rec2)) return true;
        return false;
    }
}
