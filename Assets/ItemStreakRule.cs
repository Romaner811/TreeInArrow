using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStreakRule : MonoBehaviour
{
    public int StreakLength;
    public Board SlotBoard;
    public ScoreCounter Scorer;

    private readonly IEnumerable<IEnumerable<Vector2Int>> MatchDirections = new Vector2Int[][]
    {
        new Vector2Int[] {Vector2Int.up, Vector2Int.down },
        new Vector2Int[] {Vector2Int.right, Vector2Int.left }
    };


    public List<Item> PredictStreak(Vector2Int pos, Item subject)
    {
        if (subject == null)
        {
            print($"how could you?!");
            return null;
        }
        print($"looking for #${subject.TypeID} from {pos}");

        int requiredStreakLength = this.StreakLength - 1;  // exclude subject itself
        List<Item> streak = new List<Item>(this.StreakLength * 3);

        foreach (IEnumerable<Vector2Int> axis in this.MatchDirections)
        {
            List<Item> axisStreak = new List<Item>(this.StreakLength * 2);

            foreach (Vector2Int direction in axis)
            {
                Vector2Int curPos = pos;
                Item curItem = subject;

                while (true)
                {
                    curPos += direction;
                    curItem = this.GetItemAt(curPos.x, curPos.y);

                    if ((curItem == null) || (subject.TypeID != curItem.TypeID))
                    {
                        break;
                    }

                    axisStreak.Add(curItem);
                    print($"considering item: {curItem}");
                }
            }

            if (axisStreak.Count >= requiredStreakLength)
            {
                streak.AddRange(axisStreak);
            }
            else
            {
                print($"insufficient: {axisStreak.Count}/{requiredStreakLength}");
            }
        }

        if (streak.Count >= requiredStreakLength)
        {
            streak.Add(subject);
            return streak;
        }

        print($"insufficient: {streak.Count}/{requiredStreakLength}");
        return null;
    }

    public ICollection<Item> FindStreak(Item subject)
    {
        if (subject == null)
        {
            return null;
        }

        int requiredStreakLength = this.StreakLength - 1;  // exclude subject itself
        ISet<Item> streak = new HashSet<Item>();
        List<Item> axisStreak = new List<Item>(this.StreakLength * 2);

        foreach (IEnumerable<Vector2Int> axis in this.MatchDirections)
        {
            axisStreak.Clear();

            foreach (Vector2Int direction in axis)
            {
                Vector2Int curPos = subject.Container.BoardPosition;
                Item curItem = subject;

                while (true)
                {
                    curPos += direction;
                    curItem = this.GetItemAt(curPos.x, curPos.y);

                    if ((curItem == null) || (subject.TypeID != curItem.TypeID))
                    {
                        break;
                    }

                    axisStreak.Add(curItem);
                }
            }

            if (axisStreak.Count >= requiredStreakLength)
            {
                streak.UnionWith(axisStreak);
            }
        }

        if (streak.Count >= requiredStreakLength)
        {
            streak.Add(subject);
            return streak;
        }

        return null;
    }


    private Item GetItemAt(int x, int y)
    {
        Slot slot = this.SlotBoard.GetSlot(x, y);

        if (slot == null || slot.IsEmpty)
        {
            return null;
        }

        return slot.GetItem();
    }

    void Update()
    {
        if (LongBehaviour.RunningBehaviors > 0)
        {
            return;
        }

        ISet<Item> allStreaks = new HashSet<Item>();

        for (int y = 0; y < this.SlotBoard.Heigth; y++)
        {
            for (int x = 0; x < this.SlotBoard.Width; x++)
            {
                Item subject = this.GetItemAt(x, y);
                ICollection<Item> streak = this.FindStreak(subject);
                if (streak != null)
                {
                    print($"streak: {streak.Count}");
                    allStreaks.UnionWith(streak);
                }
            }
        }

        foreach (Item item in allStreaks)
        {
            item.Explode();
            this.Scorer.AddScore(item.Score);
        }
    }
}
