using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public ItemStreakRule ItemStreakMatcher;

    public int MouseButtonID;
    public IList<Vector2Int> MoveDirections = new List<Vector2Int>()
    {
        Vector2Int.up, Vector2Int.down,
        Vector2Int.right, Vector2Int.left
    };

    private Slot start;
    private Slot end;

    private void Awake()
    {
        this.ResetTracking();
    }

    public void ResetTracking()
    {
        this.start = null;
        this.end = null;
    }

    public void ReportDragStart(Slot start)
    {
        this.start = start;
    }

    public void ReportDragHover(Slot end)
    {
        if (this.start == null)
        {
            return;
        }

        this.end = end;

        if (this.CheckSlotSwap(this.start, this.end))
        {
            this.PreviewMove();
        }
    }

    public void ReportDragEnd()
    {
        if (this.CheckSlotSwap(this.start, this.end))
        {
            print($"Swipe {this.start.BoardPosition}>{this.end.BoardPosition - this.start.BoardPosition}: {this.start} -> {this.end}"); // debug
            this.SwapItems(this.start, this.end);
        }

        this.ResetTracking();
    }

    public void PreviewMove()
    {
        print($"Dragg {this.start.BoardPosition} -> {this.end.BoardPosition - this.start.BoardPosition}"); // debug
        Debug.DrawLine(
            this.start.transform.position,
            this.end.transform.position,
            Color.Lerp(
                this.start.GetItem().GetComponent<SpriteRenderer>().color,
                this.end.GetItem().GetComponent<SpriteRenderer>().color,
                0.5f  // lerp %
            ),
            3f  // duration
        );
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

        //debug!
        return true;


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
