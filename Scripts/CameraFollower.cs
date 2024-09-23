using System;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject Target = null; // The target (ship) the camera should follow
    public GameObject T = null;
    public float speed = 1.5f;
    public int index;

    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        T=GameObject.FindGameObjectWithTag("Target");

    }

    void Update()
    {

    }
    void FixedUpdate()
    {
        this.transform.LookAt(Target.transform);
        float boat_Move = Mathf.Abs(Vector3.Distance(this.transform.position, T.transform.position) * speed);
        this.transform.position = Vector3.MoveTowards(this.transform.position, T.transform.position, boat_Move* Time.deltaTime);
    }
}
