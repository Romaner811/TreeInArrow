using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongBehaviour : MonoBehaviour
{
    public static int RunningBehaviors { get; private set; } = 0;

    public float Progress { get; private set; }  // percentage
    public bool IsFinished { get { return this.Progress >= 1f; } }

    void Awake()
    {
        this.enabled = false;
    }

    public void Begin()
    {
        if (this.enabled != true)
        {
            LongBehaviour.RunningBehaviors++;
        }
        else
        {
            Debug.LogWarning("Already Running!", this);
        }
        this.Progress = 0f;
        this.enabled = true;
    }

    public void Step(float step)
    {
        this.Progress = Mathf.Min(1f, this.Progress + step);
        if (this.IsFinished)
        {
            this.Finish();
        }
    }

    public void Finish()
    {
        if (this.enabled != false)
        {
            LongBehaviour.RunningBehaviors--;
        }
        else
        {
            Debug.LogWarning("Already Stopped!", this);
        }

        this.enabled = false;
    }
}
