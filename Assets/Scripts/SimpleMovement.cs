using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public InputManager input;
    public GameObject m_anker;
    public Padel m_padel;
    private Rigidbody2D rb;
    public float m_movingSpeed = 0.0001f;
    public int DividedBy = 3; //This needs to be moved to the GameState Script
   
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        if(rb ==null)
            Debug.LogError("Rigid Body 2D missing");

        if (input == null)
            Debug.LogError("Input Manager Reference missing");

        if(m_anker==null)
            Debug.LogError("m_anker Game Object missing");

        //Freeze some stuff so it doesnt follow gravity
        rb.gravityScale = 0;

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        gameObject.transform.RotateAround(m_anker.transform.localPosition, Vector3.forward, input.horizontal * Time.deltaTime * m_movingSpeed);
    }
    

}
