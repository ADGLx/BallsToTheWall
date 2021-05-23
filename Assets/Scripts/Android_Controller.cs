using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Android_Controller : MonoBehaviour
{
   #if UNITY_ANDROID

    private float ScreenW;
    SimpleMovement localPlayer;

    public float MobileMovementSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        ScreenW = Screen.width;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (localPlayer == null)
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<SimpleMovement>())
                localPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<SimpleMovement>();
            else
                Debug.LogError("Player could not be found");
        } else
        {
            int i = 0;

            while (i < Input.touchCount)
            {
                if(Input.touchCount == 2)
                {
                    localPlayer.GetComponent<Padel>().FireBall();
                }

                if (Input.GetTouch(i).position.x > ScreenW / 2)
                {
                    //MoveRight
                    localPlayer.HandleMoveHorizontal(1f);
                }

                if (Input.GetTouch(i).position.x < ScreenW / 2)
                {
                    //MoveLeft
                    localPlayer.HandleMoveHorizontal(-1f);
                }
                i++;
            }
        }

    }
#endif
}
