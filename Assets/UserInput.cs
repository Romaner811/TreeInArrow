using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInput : MonoBehaviour
{
    public ItemStreakRule ItemStreakMatcher;

    public Text ControlsMessage;
    public float ControlsMessageReappearTimeout;

    public int MouseButtonID;
    public IList<Vector2Int> MoveDirections = new List<Vector2Int>()
    {
        Vector2Int.up, Vector2Int.down,
        Vector2Int.right, Vector2Int.left
    };

    private Slot start;
    private Slot end;

    private float LastActivity;

    private void Awake()
    {
        this.ResetTracking();
        this.MaybeReappearControlsMessage();
    }

    private void MaybeReappearControlsMessage()
    {
        float delay = this.ControlsMessageReappearTimeout;

        if (this.ControlsMessage.enabled == false)
        {
            float idleTime = Time.time - this.LastActivity + 0.1f;
            if (idleTime >= this.ControlsMessageReappearTimeout)
            {
                this.ControlsMessage.enabled = true;
                this.ControlsMessage.CrossFadeAlpha(1f, 1f, false);
            }
            else
            {
                delay -= idleTime;
            }
        }

        print($"MaybeReappearControlsMessage delay={delay}");
        this.Invoke("MaybeReappearControlsMessage", delay);
    }

    public void ResetTracking()
    {
        this.LastActivity = Time.time;

        this.start?.UnMark();
        this.start = null;
        this.end?.UnMark();
        this.end = null;
    }

    public void ReportDragStart(Slot start)
    {
        this.start = start;
        start.Mark();

        this.LastActivity = Time.time;

        if (this.ControlsMessage.enabled)
        {
            this.ControlsMessage.CrossFadeAlpha(0.1f, 1f, false);
        }
    }

    public void ReportDragHover(Slot end)
    {
        if (this.start == null)
        {
            return;
        }

        this.end?.UnMark();
        this.end = end;

        if (this.CheckSlotSwap(this.start, this.end))
        {
            this.end.Mark();
        }
    }

    public void ReportDragEnd()
    {
        if (this.CheckSlotSwap(this.start, this.end))
        {
            print($"Swipe {this.start.BoardPosition}>{this.end.BoardPosition - this.start.BoardPosition}: {this.start} -> {this.end}"); // debug
            this.SwapItems(this.start, this.end);

            this.ControlsMessage.enabled = false;
        }
        else if (this.ControlsMessage.enabled)
        {
            this.ControlsMessage.CrossFadeAlpha(1f, 1f, false);
        }

        this.ResetTracking();
    }

    private void SwapItems(Slot src, Slot dst)
    {
        Item itemOne = src?.GetItem();
        Item itemTwo = dst?.GetItem();

        itemOne?.PlaceInto(null);
        itemTwo?.PlaceInto(src);
        itemOne?.PlaceInto(dst);
    }

    public bool CheckSlotSwap(Slot src, Slot dst)
    {
        if (this.start == null || this.end == null)
        {
            return false;
        }

        // check direction and distance
        Vector2Int dir = dst.BoardPosition - src.BoardPosition;
        if (this.MoveDirections.IndexOf(dir) < 0)
        {
            return false;
        }
        
        // check if move is succesfull;
        if (
            (this.ItemStreakMatcher.PredictStreak(dst.BoardPosition, src.GetItem()) == null)
            &&
            (this.ItemStreakMatcher.PredictStreak(src.BoardPosition, dst.GetItem()) == null)
            )
        {
            return false;
        }
        
        return true;
    }
}
