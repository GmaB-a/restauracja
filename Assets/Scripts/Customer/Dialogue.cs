using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] int maxIngridientNumber;
    [SerializeField] BurgerScriptableObjects[] OneIngridientBurgers;
    [SerializeField] BurgerScriptableObjects[] TwoIngridientBurgers;
    [SerializeField] BurgerScriptableObjects[] ThreeIngridientBurgers;
    [SerializeField] BurgerScriptableObjects[] FourIngridientBurgers;
    [SerializeField] BurgerScriptableObjects[] FiveIngridientBurgers;

    public BurgerScriptableObjects ChooseBurger()
    {
        BurgerScriptableObjects[] usedBurgersArray;
        int ingridientAmount = Random.Range(1, maxIngridientNumber);
        switch (ingridientAmount)
        {
            case 1:
                usedBurgersArray = OneIngridientBurgers;
                break;
            case 2:
                usedBurgersArray = TwoIngridientBurgers;
                break;
            case 3:
                usedBurgersArray = ThreeIngridientBurgers;
                break;
            case 4:
                usedBurgersArray = FourIngridientBurgers;
                break;
            default:
                usedBurgersArray = FiveIngridientBurgers;
                break;
        }
        return (usedBurgersArray[Random.Range(0, usedBurgersArray.Length)]);
    }
}
