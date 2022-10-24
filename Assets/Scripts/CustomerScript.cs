using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerScript : MonoBehaviour
{
    [SerializeField] private Image dialogue;
    [SerializeField] private AnimationClip spawnAnim;
    void Update()
    {
        if (!gameObject.GetComponent<Animation>().IsPlaying(spawnAnim.name)) dialogue.gameObject.SetActive(true);
    }
}
