using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperReference : MonoBehaviour
{

    public GameObject shopKeeper;
    

    public void AnimationEvent()
    {
        shopKeeper.GetComponent<ShopBehaviour>().ReactivateScene();
    }

    public void LeaveShop()
    {
        gameObject.GetComponent<Animator>().SetBool("DialogueTrigger", false);
        gameObject.GetComponent<Animator>().SetBool("ShowOptions", false);
    }
}
