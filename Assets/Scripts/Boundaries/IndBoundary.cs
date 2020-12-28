using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class IndBoundary : NetworkBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ball")
        {
            this.transform.parent.GetComponent<BoundaryManager>().CollisionDetected(this.gameObject.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Ball>());
        }

    }
}
