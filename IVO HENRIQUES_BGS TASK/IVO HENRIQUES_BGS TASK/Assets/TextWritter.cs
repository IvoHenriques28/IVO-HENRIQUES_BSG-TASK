using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextWritter : MonoBehaviour
{
    public TextMeshProUGUI textToSee;
    public TextMeshProUGUI dialogue;
    public string textToWrite;
    private int characterIndex;
    public float timerPerCharacter;
    public float timer;

    public ShopBehaviour shopkeeper;
    // Start is called before the first frame update
    void Awake()
    {
        textToSee = dialogue;
        characterIndex = 0;
        textToSee.text = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(textToSee != null)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f)
            {
                //Display next character
                timer += timerPerCharacter;
                characterIndex++;
                textToSee.text = textToWrite.Substring(0, characterIndex);

                if(characterIndex >= textToWrite.Length)
                {
                    //Entire text is already displayed
                    textToSee = null;
                    shopkeeper.DialogueUI.SetBool("ShowOptions", true);
                    characterIndex = 0;
                    return;
                }
            }
        }
    }
}
