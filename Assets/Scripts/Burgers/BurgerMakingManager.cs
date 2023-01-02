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

    public bool IsHoldingAnIngridient;
    public string HoldIngridientName;
    public Image HoldIngridientImage;

    public BurgerScriptableObjects currentBurger;

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

        for(int i = 0; i < ingridientPositions.Length; i++)
        {
            if (!ingridientPositions[i].GetComponent<IngridientPositions>().isOccupied)
            {
                HoldIngridientImage.GetComponent<IngridientScript>().HasToFollowCursor = false;
                HoldIngridientImage.transform.position = ingridientPositions[i].transform.position;
                ingridientPositions[i].GetComponent<IngridientPositions>().isOccupied = true;
                IsHoldingAnIngridient = false;
                HoldIngridientName = "";
                break;
            }
        }
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
