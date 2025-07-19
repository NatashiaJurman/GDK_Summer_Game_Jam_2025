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


    void Start()
    {
        if (gameObject.tag == "IntroDialogue")
        {
            textComponent.text = string.Empty;
            uiImageComponent.sprite = null;
            StartDialogue();
        }
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
            gameObject.SetActive(false);
        }
    }
}