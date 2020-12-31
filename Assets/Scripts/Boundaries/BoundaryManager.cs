using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BoundaryManager : NetworkBehaviour
{
    Dictionary<Collider2D, Padel> m_colliderplaeyer = new Dictionary<Collider2D, Padel>();//This stores the 4 players with its collider
    [SerializeField] private Collider2D[] allBoundaries;
    private int amountPlayers = 0;
  
  

    [Server]
    public void CollisionDetected(Collider2D col, Ball ball)
    {
        if (!m_colliderplaeyer.ContainsKey(col))
            Debug.LogError("Missing Collider info");

        CmdLose(col, m_colliderplaeyer[col], ball);
    }

    [Server]
    public void AddPlayer(Padel p)
    {

        Collider2D col = DetectAssignedBoundary();
        if (m_colliderplaeyer.ContainsKey(col))
        {
            Debug.Log("Already contained key");
            return;
        }

      
        m_colliderplaeyer.Add(col, p);
        col.isTrigger = true;
        p.PlayerIndex = amountPlayers; //Maybe this should be assigned somewhere else 
        amountPlayers++;
        // Debug.Log("PlayerAdded");
    }


    private Collider2D GetColliderwithPlayerIndex(int index)
    {
        return allBoundaries[index];
    }

    private Collider2D DetectAssignedBoundary()
    {
        return allBoundaries[amountPlayers];
    }

 
    void CmdLose(Collider2D col, Padel p, Ball ball)
    {

        col.isTrigger = false; //This turns on the colliders on the server

        //This turns off the padels on the client and the sv
        p.m_isActive = false;
        ball.m_isActive = false;

        Debug.Log(col.gameObject.name + " lost");
      
      
    }
}
