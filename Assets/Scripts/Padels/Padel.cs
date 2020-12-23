using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Padel : MonoBehaviour
{
    public GameObject m_anker;
    public Quaternion m_startingRotation;
    public int m_padelindex;

    void Awake()
    {
        if (m_anker == null)
        {
            Debug.LogError("m_anker Game Object missing");
            return;
        }

        gameObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, m_anker.transform.position - gameObject.transform.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        m_startingRotation = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
