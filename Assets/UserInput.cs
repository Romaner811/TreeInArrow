using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public int MouseButtonID;

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

        if (end == null)
        {
            return;
        }

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

    public bool CheckSlotSwap(Slot one, Slot two)
    {
        Vector2Int dir = two.BoardPosition - one.BoardPosition;
        print($"Swipe {this.start.BoardPosition}>{dir}: {this.start} -> {this.end}"); // debug
        //((direction.x * direction.y) == 0) && // non-diagonal.
        // TODO
        return true;
    }

    public void ReportDragEnd()
    {
        if (this.start != null && this.end != null)
        {
            if (this.CheckSlotSwap(this.start, this.end))
            {
                this.SwapItems(this.start, this.end);
            }
        }

        this.ResetTracking();
    }

    private void SwapItems(Slot one, Slot two)
    {
        Item itemOne = one.GetItem();
        Item itemTwo = two.GetItem();

        itemOne?.PlaceInto(null);
        itemTwo?.PlaceInto(one);
        itemOne?.PlaceInto(two);

        //itemOne.PlaceInto(null);
        //itemTwo.PlaceInto(null);

        //itemOne.PlaceInto(two);
        //itemTwo.PlaceInto(one);
    }
}
