using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    public Sprite[] shirtSprites;
    public Sprite[] pantsSprites;
    public Sprite[] miscSprites;
    public Sprite[] headSprites;
    public Sprite[] accessorySprites;
}
