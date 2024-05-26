using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoving : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveRange;
    private Vector3 oldPosition;

    void Start()
    {
        oldPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(new Vector3(transform.position.x,-1*Time.deltaTime*moveSpeed,0));

       if (Vector3.Distance(oldPosition,transform.position) > moveRange)
       {
           transform.position = oldPosition;
       }
    }
}

