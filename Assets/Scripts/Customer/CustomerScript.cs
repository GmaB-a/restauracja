using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerScript : MonoBehaviour
{
    public Image dialogue;
    [SerializeField] private AnimationClip spawnAnim;
    void Update()
    {
        if (!gameObject.GetComponent<Animation>().IsPlaying(spawnAnim.name)) dialogue.gameObject.SetActive(true);
    }

    public void ChangeSprite(Sprite customerSprite)
    {
        gameObject.GetComponent<Image>().sprite = customerSprite;
    }
}
