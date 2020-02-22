using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StreakTracker {
    public int LastStreakSize { get; private set; }
    public Item LastTrackedValue { get { return this.streak[0]; } }

    private readonly Item[] streak;

    public StreakTracker(int maxStreakSize)
    {
        this.streak = new Item[maxStreakSize];
    }

    public bool Check(Item value)
    {
        return value != null && value.Equals(this.LastTrackedValue);
    }

    public Item[] GetStreak()
    {
        Item[] streak = new Item[this.LastStreakSize];
        System.Array.Copy(this.streak, streak, this.LastStreakSize);
        return streak;
    }

    public Item[] Feed(Item nextValue)
    {
        Item[] ret = null;

        if (this.Check(nextValue))
        {
            this.LastStreakSize++;
        }
        else
        {
            if (this.LastTrackedValue != null)
            {
                ret = this.GetStreak();
            }

            this.LastStreakSize = 1;
        }

        this.streak[this.LastStreakSize - 1] = nextValue;

        return ret;
    }
}

public class ItemStreakRule : MonoBehaviour
{
    public int StreakLength;
    public Board SlotBoard;
    public ScoreCounter Scorer;

    private Item GetItemAt(int x, int y)
    {
        Slot slot = this.SlotBoard.GetSlot(x, y);

        if (slot == null || slot.IsEmpty)
        {
            return null;
        }

        return slot.GetItem();
    }

    private void HandleStreak(Item[] streak)
    {
        if (streak == null || streak.Length < this.StreakLength)
        {
            return;
        }
        print($"streak: {streak.Length}");

        foreach (Item item in streak)
        {
            item.Explode();
            this.Scorer.AddScore(item.Score);
        }
    }

    private void TryStreak(StreakTracker tracker, int x, int y)
    {
        Item item = this.GetItemAt(x, y);
        Item[] streak = tracker.Feed(item);
        this.HandleStreak(streak);
    }

    void Update()
    {
        if (LongBehaviour.RunningBehaviors > 0)
        {
            return;
        }

        int maxSize = Mathf.Max(this.SlotBoard.Width, this.SlotBoard.Heigth) + 1;

        for (int i = 0; i < maxSize; i++)
        {
            StreakTracker horizontalTracker = new StreakTracker(this.SlotBoard.Width);
            StreakTracker verticalTracker = new StreakTracker(this.SlotBoard.Heigth);

            for (int j = 0; j < maxSize; j++)
            {
                int x, y;

                // horizontal
                x = j;
                y = i;
                this.TryStreak(horizontalTracker, x, y);

                // vertical
                x = i;
                y = j;
                this.TryStreak(verticalTracker, x, y);
            }
        }
    }
}
