using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public class ItemTransfer
    {
        public Item Subject { get; private set; }
        public Slot Target { get; private set; }

        public ItemTransfer(Item subject, Slot target)
        {
            this.Subject = subject;
            this.Target = target;
        }

        public void Perform()
        {
            if (this.Subject.Container != null)
            {
                this.Subject.Container.PutItem(null);
            }
            this.Subject.Container = this.Target;

            if (this.Target != null)
            {
                this.Target.PutItem(this.Subject);
            }
        }
    }

    private ItemExplosionBehaviour explosionScript;
    private MotionBehaviour motionScript;

    void Awake()
    {
        this.explosionScript = this.GetComponent<ItemExplosionBehaviour>();
        this.motionScript = this.GetComponent<MotionBehaviour>();
    }

    public Slot Container { get; private set; }
    public int TypeID;
    public int Score;

    public void PlaceInto(Slot slot)
    {
        if (this.Container != null)
        {
            this.Container.PutItem(null);
        }
        this.Container = slot;

        if (slot != null)
        {
            slot.PutItem(this);
            this.motionScript.Target(slot.transform.position);
        }
    }

    public void Explode()
    {
        print($"exploding {this}!");  //debug!
        this.explosionScript.Explode();
        this.PlaceInto(null);
    }

    public bool Equals(Object other)
    {
        if (other is null)
        {
            return false;
        }

        if (other is Item otherItem)
        {
            return this.TypeID == otherItem.TypeID;
        }
        else
        {
            return base.Equals(other);
        }
    }

    public override string ToString()
    {
        string original = base.ToString();
        return $"<{original} #{this.TypeID} @{this.Container}>";
    }
}
