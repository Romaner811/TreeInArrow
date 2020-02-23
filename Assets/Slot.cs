using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public UserInput Inputer;
    public Vector2Int BoardPosition;

    public Color DefaultColor;
    public Color MarkedColor;

    private SpriteRenderer renderer;

    private void Awake()
    {
        this.renderer = this.GetComponent<SpriteRenderer>();
        this.UnMark();
    }

    private Item content;

    public Item GetItem()
    {
        return this.content;
    }

    public void PutItem(Item item)
    {
        this.content = item;
    }

    public bool IsEmpty
    {
        get { return this.content == null; }
    }

    public void Mark()
    {
        this.renderer.color = this.MarkedColor;
    }
    public void UnMark()
    {
        this.renderer.color = this.DefaultColor;
    }

    private void OnMouseDown()
    {
        if (this.content == null)
        {
            return;
        }

        if (Input.GetMouseButtonDown(this.Inputer.MouseButtonID))
        {
            this.Inputer.ReportDragStart(this);
        }
    }

    private void OnMouseUp()
    {
        if (this.content == null)
        {
            return;
        }

        if (Input.GetMouseButtonUp(this.Inputer.MouseButtonID))
        {
            this.Inputer.ReportDragEnd();
        }
    }

    private void OnMouseEnter()
    {
        if (this.content == null)
        {
            return;
        }

        if (Input.GetMouseButton(this.Inputer.MouseButtonID))
        {
            this.Inputer.ReportDragHover(this);
        }
    }

    private void OnMouseExit()
    {
        if (this.content == null)
        {
            return;
        }

        if (Input.GetMouseButton(this.Inputer.MouseButtonID))
        {
            this.Inputer.ReportDragHover(null);
        }
    }

    public override string ToString()
    {
        string original = base.ToString();
        return $"<{original} {this.BoardPosition}>";
    }
}