using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public Board SlotBoard;

    private void Awake()
    {
        this.topRowIndex = this.SlotBoard.Heigth - 1;
        this.spawnOffset = Vector3.up * this.ItemPrefab.transform.lossyScale.y;
    }

    public GameObject ItemPrefab;
    public int ItemTypesAmount;
    public Color[] ItemColors;
    public Sprite[] ItemSprites;

    private int topRowIndex;
    private Vector3 spawnOffset;

    public void SpawnItem(int typeID, Slot target)
    {
        GameObject obj = GameObject.Instantiate<GameObject>(
            this.ItemPrefab, target.transform.position + spawnOffset,
            Quaternion.identity
            );
        Item item = obj.GetComponent<Item>();

        SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
        item.TypeID = typeID;
        renderer.color = this.ItemColors[typeID];
        renderer.sprite = this.ItemSprites[typeID];

        item.PlaceInto(target);
    }

    public int ChoseTypeID()
    {
        return Random.Range(0, this.ItemTypesAmount);
    }

    void Update()
    {
        if (LongBehaviour.RunningBehaviors > 0)
        {
            return;
        }

        int y = this.topRowIndex;

        for (int x = 0; x < this.SlotBoard.Width; x++)
        {
            Slot slot = this.SlotBoard.GetSlot(x, y);
            if (slot == null)
            {
                continue;
            }

            if (slot.IsEmpty)
            {
                int itemTypeID = this.ChoseTypeID();
                this.SpawnItem(itemTypeID, slot);
            }
        }
    }
}
