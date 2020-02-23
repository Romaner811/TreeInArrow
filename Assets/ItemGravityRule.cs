using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGravityRule : MonoBehaviour
{
    public Board SlotBoard;
    public ItemStreakRule StreakRuleScript;

    void Update()
    {
        if (LongBehaviour.RunningBehaviors > 0)
        {
            return;
        }

        bool wasIdle = true;

        for (int y = 0; y < this.SlotBoard.Heigth; y++)
        {
            for (int x = 0; x < this.SlotBoard.Width; x++)
            {
                Slot slot = this.SlotBoard.GetSlot(x, y);
                if (slot == null || slot.IsEmpty)
                {
                    continue;
                }

                Slot below = this.SlotBoard.GetSlot(x, y - 1);
                if (below == null)
                {
                    continue;
                }

                if (below.IsEmpty)
                {
                    Item item = slot.GetItem();
                    item.PlaceInto(below);
                    wasIdle = false;
                }
            }
        }

        // if nothing to gravitate - we can match streaks.
        this.StreakRuleScript.enabled = wasIdle;
    }
}
