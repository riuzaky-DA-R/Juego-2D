using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHM : MonoBehaviour
{
    public Transform Pos1, Pos2;
    public Transform StartPos;
    public float Speed;
    Vector3 NextPos;

    // Start is called before the first frame update
    void Start()
    {
       transform.position= StartPos.position;
    }

    private void FixedUpdate()
    {
        if (transform.position == Pos1.position)
        {
            NextPos = Pos2.position;
        }
        else if (transform.position == Pos2.position)
        {
            NextPos = Pos1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, NextPos, Speed * Time.deltaTime);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(Pos1.position,Pos2.position);
    }
}
