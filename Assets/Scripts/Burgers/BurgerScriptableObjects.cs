using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BurgerData", menuName = "ScriptableObjects/BurgerData", order = 1)]
public class BurgerScriptableObjects : ScriptableObject
{
    public Sprite BurgerSprite;
    public bool HasOnion;
    public bool HasTomato;
    public bool HasCheese;
    public bool HasSalad;
    public bool HasPatty;
    public bool HasUpperBun;
}
