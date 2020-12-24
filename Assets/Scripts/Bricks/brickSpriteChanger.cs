using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class brickSpriteChanger : MonoBehaviour
{
    public GameObject[] blockObj;

    public Sprite mysterySprite;
    public Sprite normalSprite;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < blockObj.Length; i++)
        {

            if (blockObj[i].tag == "mysteryBrick")
            {
                blockObj[i].gameObject.GetComponent<SpriteRenderer>().sprite = mysterySprite;
            }
            else if (blockObj[i].tag == "normalBrick")
            {
                blockObj[i].gameObject.GetComponent<SpriteRenderer>().sprite = normalSprite;
            }

        }



    }

}
