using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerScript : MonoBehaviour
{
    public GameObject Dialogue;
    [SerializeField] private AnimationClip spawnAnim;
    [SerializeField] private AnimationClip finishAnim;

    public void StartDialogue()
    {
        Dialogue.gameObject.SetActive(true);
    }

    public void EndDialogue()
    {
        Dialogue.gameObject.SetActive(false);
    }

    public void ChangeSprite(Sprite customerSprite)
    {
        gameObject.GetComponent<Image>().sprite = customerSprite;
    }

    public void SpawnNextCustomer()
    {
        CustomerManager.Instance.SpawnCustomer();
    }

    public void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
}
