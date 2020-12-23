using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public class InputKeys //easier to change to the input in unity
    {
        public string HORIZONTAL = "Horizontal";
        public string SPACE = "Jump"; 
    }
    public InputKeys Key = new InputKeys();

   //The actual input
    [HideInInspector]
    public float horizontal;

    [HideInInspector]
    public bool space;

    void GetInput()
    {
        
        horizontal = Input.GetAxis(Key.HORIZONTAL);
        space = Input.GetButton(Key.SPACE);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetInput();
    }
}
