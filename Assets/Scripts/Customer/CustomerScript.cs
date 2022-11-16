using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerScript : MonoBehaviour
{
    public GameObject Dialogue;
    [SerializeField] private AnimationClip spawnAnim;
    public BurgerScriptableObjects BurgerWanted;
    void Update()
    {
        if (!gameObject.GetComponent<Animation>().IsPlaying(spawnAnim.name)) Dialogue.gameObject.SetActive(true);
    }

    public void ChangeSprite(Sprite customerSprite)
    {
        gameObject.GetComponent<Image>().sprite = customerSprite;
    }
}
