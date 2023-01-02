using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PickUpIngridient : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Image ingridientImagePrefab;
    public void SpawnIngridient(Sprite ingridientSprite)
    {
        Image ingridientImage = Instantiate(ingridientImagePrefab, canvas.transform);
        ingridientImage.GetComponent<Image>().sprite = ingridientSprite;
        ingridientImage.GetComponent<IngridientScript>().canvas = canvas;
    }
}
