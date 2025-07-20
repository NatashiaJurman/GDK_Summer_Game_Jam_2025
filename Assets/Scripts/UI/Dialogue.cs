using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public Image uiImageComponent;
    public Sprite[] uiImage;
    public string[] lines;
    public float textSpeed;
    private int index;

    public GameObject firstSparrow;
    public GameObject secondSparrow;


    void Start()
    {
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (textComponent.text == lines[index] && uiImageComponent.sprite == uiImage[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
                uiImageComponent.sprite = uiImage[index];
            }
        }
    }

    public void StartDialogue()
    {
        this.gameObject.SetActive(true);
        
        firstSparrow.tag = "Untagged";
        secondSparrow.tag = "Untagged";

        index = 0;
        uiImageComponent.sprite = uiImage[index];
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        uiImageComponent.sprite = uiImage[index];

        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1 && index < uiImage.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            uiImageComponent.sprite = null;
            StartCoroutine(TypeLine());
        }
        else
        {
            if (this.gameObject.tag == "FirstSparrowDialogue")
            {
                secondSparrow.SetActive(true);
                secondSparrow.tag = "Interactable";

                firstSparrow.SetActive(false);
            }
            gameObject.SetActive(false);

        }
    }
}