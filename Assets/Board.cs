using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void SlotProcessor(Vector2Int pos, GameObject value);


public class Board : MonoBehaviour
{
    public int Width, Heigth;

    public GameObject SlotPrefab;


    private GameObject[,] board;
    private GameObject[,] slotObjects;
    private Vector3 zeroPosition;

    // Start is called before the first frame update
    void Start()
    {
        this.InitializeBoard();
    }

    private void InitializeBoard()
    {
        this.zeroPosition = new Vector3( -this.Width / 2f, -this.Heigth / 2f);
        this.board = new GameObject[this.Width, this.Heigth];
        this.slotObjects = new GameObject[this.Width, this.Heigth];

        for (int x = 0; x < this.Width; x++)
        {
            for (int y = 0; y < this.Heigth; y++)
            {
                this.board[x, y] = null;
                this.slotObjects[x, y] = this.CreateSlot(x, y);
            }
        }
    }

    private Vector3 CalcSlotPosition(int x, int y)
    {
        Vector3 pos = new Vector3(x, y);
        pos += this.zeroPosition;

        Vector3 scale = this.SlotPrefab.transform.localScale;
        pos.Scale(scale);
        pos += scale / 2f;
        return pos;
    }

    private GameObject CreateSlot(int x, int y)
    {
        Vector3 pos = this.CalcSlotPosition(x, y);
        GameObject slot = GameObject.Instantiate(this.SlotPrefab, pos, Quaternion.identity, this.transform);

        slot.SetActive(true);

        print($"Slot Created: {slot} {pos}");
        return slot;
    }


    public GameObject GetItem(Vector2Int pos)
    {
        return this.board[pos.x, pos.y];
    }

    public void ForEach(SlotProcessor func)
    {
        Vector2Int pos = new Vector2Int();

        for (; pos.x < this.Width; pos.x++)
        {
            for (; pos.y < this.Heigth; pos.y++)
            {
                GameObject value = this.GetItem(pos);
                func(pos, value);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
