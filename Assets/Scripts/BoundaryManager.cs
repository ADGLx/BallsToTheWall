using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BoundaryManager : MonoBehaviour
{
    Dictionary<Collider2D, Padel> m_colliderplaeyer = new Dictionary<Collider2D, Padel>();//This stores the 4 players with its collider
    private void Start()
    {
        
    }
   
 //this should be handled by the server only
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag == "Ball")
        {
             Collider2D col = DetectClosestCollider(collision.transform.position); //This gets the child object
            //Just send the destroy to the corrrespondent player
            
            if (!m_colliderplaeyer.ContainsKey(col))
                Debug.LogError("Missing Collider info");

            m_colliderplaeyer[col].LoseGame();
            col.isTrigger = false;
            Destroy(collision.gameObject); //destroys the ball too 
        } 
            
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && collision.otherCollider.tag== "Boundary")
        {
            Padel p = collision.gameObject.GetComponent<Padel>();
            if (p != null && !m_colliderplaeyer.ContainsKey(collision.otherCollider) && !m_colliderplaeyer.ContainsValue(p))
            {
                AddAPlayer(collision.otherCollider, p);
                Debug.Log(collision.otherCollider.gameObject.name);
            }

        }
    }


    public void AddAPlayer(Collider2D c,Padel p)
    {

        m_colliderplaeyer.Add(c, p);
        c.isTrigger = true;
    }

    private Collider2D DetectClosestCollider(Vector3 a)
    {
        Collider2D[] AllBoundaries = this.GetComponentsInChildren<Collider2D>();
        Collider2D closest = AllBoundaries[0];
        float closestdistance = Mathf.Infinity;

        foreach (Collider2D b in AllBoundaries)
        {
            float distance = (b.gameObject.transform.position - a).magnitude;

            if (distance < closestdistance)
                closest = b;
        }

        return closest;
    }
}
