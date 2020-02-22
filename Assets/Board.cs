using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private UserInput inputer;

    private void Awake()
    {
        this.inputer = this.GetComponent<UserInput>();
    }

    public int Width, Heigth;

    public GameObject SlotPrefab;

    private Slot[,] board;
    private Vector3 zeroPosition;

    void Start()
    {
        this.InitializeBoard();
    }

    private Vector3 CalcSlotPosition(int x, int y)
    {
        Vector3 pos = new Vector3(x, y);
        pos += this.zeroPosition;

        Vector3 scale = this.SlotPrefab.transform.lossyScale;
        pos.Scale(scale);
        pos += scale / 2f;
        return pos;
    }

    private Slot CreateSlot(int x, int y)
    {
        Vector3 pos = this.CalcSlotPosition(x, y);
        GameObject slotObject = GameObject.Instantiate(this.SlotPrefab, pos, Quaternion.identity, this.transform);

        Slot slot = slotObject.GetComponent<Slot>();
        slot.BoardPosition = new Vector2Int(x, y);
        slot.Inputer = this.inputer;

        slotObject.SetActive(true);

        return slot;
    }

    private void InitializeBoard()
    {
        this.zeroPosition = new Vector3(-this.Width / 2f, -this.Heigth / 2f);
        this.board = new Slot[this.Width, this.Heigth];

        for (int x = 0; x < this.Width; x++)
        {
            for (int y = 0; y < this.Heigth; y++)
            {
                Slot slot = this.CreateSlot(x, y);
                this.board[x, y] = slot;
            }
        }
    }

    public Slot GetSlot(int x, int y)
    {
        if (x < 0 || x >= this.Width || y < 0 || y >= this.Heigth)
        {
            return null;
        }

        return this.board[x, y];
    }
}
