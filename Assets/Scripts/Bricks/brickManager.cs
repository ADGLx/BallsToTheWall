using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class brickManager : MonoBehaviour
{

    public bool desi;
   



    // Start is called before the first frame update
    void Start()
    {

        desi = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.tag == "mysteryBrick")
        {
            if (collision.gameObject.tag == "Player")
            {
                //do destroy just set as inactive
                gameObject.SetActive(desi);

                // Trigger any animations 


                //Award the player an item
                Debug.Log("Mystery Brick hit");
            }
        }
        else if (gameObject.tag == "normalBrick")
        {
            if (collision.gameObject.tag == "Player")
            {
                //do destroy just set as inactive
                gameObject.SetActive(desi);

                // Trigger any animations


                Debug.Log("Brick hit");
            }
        }
        
    }








}
