using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionBehaviour : LongBehaviour
{
    public float ProgressSpeed; // percentage

    private Vector3 start;
    private Vector3 target;

    public void Target(Vector3 target)
    {
        this.start = this.transform.position;
        this.target = target;

        this.Begin();
    }

    void Update()
    {
        this.transform.position = Vector3.Lerp(this.start, this.target, this.Progress);

        this.Step(this.ProgressSpeed);
    }
}
