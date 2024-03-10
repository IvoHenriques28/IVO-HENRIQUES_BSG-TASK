using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBehaviour : MonoBehaviour
{

    [SerializeField] private GameObject emote;
    [SerializeField] private GameObject player;
    public Animator DialogueUI;

    private bool DialogueTriggered;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if the player presses F while inside collider before dialogue is already active
        if (Input.GetKeyDown("f") && emote.activeSelf && !DialogueTriggered)
        {
            player.GetComponent<PlayerMovement>().enabled = false;
            DialogueTriggered = true;
            DialogueUI.SetBool("DialogueTrigger", DialogueTriggered);
            emote.SetActive(false);
        }
    }

    //if player collides with this object's collider, show the player he can interact with NPC, remove sign if player leaves collider area
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            emote.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            emote.SetActive(false);
        }
    }

    public void ReactivateScene()
    {
        player.GetComponent<PlayerMovement>().enabled = true;
        DialogueTriggered = false;
        DialogueUI.SetBool("DialogueTrigger", DialogueTriggered);

        emote.SetActive(true);
    }
}
