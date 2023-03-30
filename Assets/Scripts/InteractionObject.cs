using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractionObject : MonoBehaviour
{
    public enum InteractableType
    {
        nothing,
        info,
        pickup,
        dialogue,
        pickupinfo
    }

    [Header("Type of Interactable")]
    public InteractableType interType;

    [Header("Simple info Message")]
    public string infoMessage;
    private TMP_Text infoText;

    [Header("Dialogue Text")]
    [TextArea]
    public string[] sentences;


    public void Start()
    {
        infoText = GameObject.Find("InfoText").GetComponent<TMP_Text>();

    }

    public void Nothing()
    {
        Debug.LogWarning("Object: " + this.gameObject.name + " has no type set.");
    }

    public void Info()
    {
        StartCoroutine(ShowInfo(infoMessage, 2.5f));
    }

    public void Pickup()
    {
        Debug.Log("You picked up " + this.gameObject.name);
        this.gameObject.SetActive(false);
    }

    public void Dialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(sentences);
    }

    IEnumerator ShowInfo(string message, float delay)
    {
        infoText.text = message;
        yield return new WaitForSeconds(delay);
        infoText.text = null;
    }

    public void PickUpInfo()
    {
        StartCoroutine(ShowInfo(infoMessage, 2.5f));
        this.gameObject.SetActive(false);
    }
}
