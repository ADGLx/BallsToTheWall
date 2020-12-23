using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    private PlayerControl input;
    public GameObject m_anker;
    private Padel m_padel;
    private Rigidbody2D rb;
    public float m_movingSpeed = 0.0001f;
    public int DividedBy = 4; //This needs to be moved to the GameState Script
    public float startingAngle = 45;
    public float m_radius = 6.25f;
   
    //Stuff to fix the bugginess of the movement
    private float negInp = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        if(rb ==null)
            Debug.LogError("Rigid Body 2D missing");

        input = this.GetComponent<PlayerControl>();
        if (input == null)
            Debug.LogError("Input Manager Reference missing");

        if(m_anker==null)
            Debug.LogError("m_anker Game Object missing");

        m_padel = this.GetComponent<Padel>();
        if (m_padel == null)
            Debug.LogError("m_panel Game Object missing");

        //Freeze some stuff so it doesnt follow gravity
        rb.gravityScale = 0;

        //Spawn the Padel at the appropiate position (This isnt needed I think)
      //  gameObject.transform.RotateAround(m_anker.transform.localPosition,Vector3.forward, startingAngle);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        float inputHorizontal = input.horizontal;

        if (negInp < 0) //reach the left
            inputHorizontal= Mathf.Max(0, input.horizontal);
        else if (negInp > 0) //reach right
            inputHorizontal = Mathf.Min(0, input.horizontal);


        gameObject.transform.RotateAround(m_anker.transform.localPosition, Vector3.forward, (inputHorizontal) * Time.deltaTime * m_movingSpeed);
        gameObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, m_anker.transform.position - gameObject.transform.position);
        
        //Clamping the movement at (0,-1) and (1,0) this is the old method to 
        Vector3 pos = this.transform.position;
        pos.x = Mathf.Clamp(pos.x, -m_radius, m_radius);
        pos.y = Mathf.Clamp(pos.y, -m_radius, m_radius);
        transform.position = pos;
      
        /*
        //Clamping the rotation
        Vector3 rot = this.transform.eulerAngles;
        rot.z = Mathf.Clamp(rot.z, 90, 180);
        this.transform.eulerAngles = rot;
        */

    }


    

    private void OnCollisionEnter2D(Collision2D collision) //This just makes it so it cannot keep going once it hits the wall
    {
       //Record the position on the impact to lave it there after it finishes the impact 
       
       // if(collision.otherCollider.gameObject.tag == "Wall")
        negInp = input.horizontal;
        
    }

    private void OnCollisionExit2D(Collision2D collision) //allows it to be okay after
    {
       // if (collision.otherCollider.gameObject.tag == "Wall")
            negInp = 0;

    }
   
    
}
