using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] Transform endPoint;
    Vector2 startPos;
    Vector2 endPos;
    private bool active = false;
    [SerializeField] float moveSpeed = 50;

    private void Start()
    {
        startPos = transform.position;
        endPos = endPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPos = transform.position;

        if (active && currentPos != endPos)
        {
            //Debug.Log("moving up");
            transform.position = Vector3.MoveTowards(currentPos, endPos, moveSpeed * Time.deltaTime);
        }
        else if (!active && currentPos != startPos)
        {
            //Debug.Log("moving down ");
            transform.position = Vector3.MoveTowards(currentPos, startPos, moveSpeed * Time.deltaTime);
        }
    }

    public void SetActive (bool newState)
    {
        active = newState;
    }

    public void FlipActive ()
    {
        active = !active;
    }

}
