using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeInARowGame : MonoBehaviour
{
    public int Width, Heigth;

    public GameObject SlotPrefab;
    public GameObject BoardGameObject;
    
    public GameObject[] ItemPrefabs;

    private Board board;

    // Start is called before the first frame update
    void Start()
    {
        this.board = this.BoardGameObject.GetComponent<Board>();
        this.board.Width = this.Width;
        this.board.Heigth = this.Heigth;
        this.board.SlotPrefab = this.SlotPrefab;
        this.BoardGameObject.SetActive(true);
    }

    private void NextRule()
    {
        if (this.noIncidents < STATES_AMOUNT)
        {
            this.state = (this.state + 1) % STATES_AMOUNT;
        }
        else
        {
            this.inputEnabled = true;
            this.state = 0;
        }
    }

    private void CollectIdenticals(Vector2Int pos, GameObject item)
    {

    }

    private const int STREAK_LENGTH = 3;
    private void FindStreakGroups(Vector2Int pos, GameObject item)
    {
        LinkedList<Vector2Int> horizontal = new LinkedList<Vector2Int>();
        horizontal.AddFirst(pos);
        
        Vector2Int left = new Vector2Int(pos.x, pos.y);
        while (true)
        {
            left += Vector2Int.left;

            if (this.board.GetItem(left).name != item.name)
            {
                break;
            }

            horizontal.AddFirst(left);
        }
        
    }

    private void ApplyRules()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        // do you have a behavior to execute?
        if (true)
        {
            // step it
            // did it finish?
            if (true)
            {
                // clean behavior
            }
            return;
        }

        // any rules should run?
        if (true)
        {
            // get next rule -> rule
            // execute rule -> behavior
            // is the behavior empty?
            if (true)
            {
                // mark the rule as idle
            }
            else
            {
                // put behavior to execution
            }
            return;
        }
    }
}
