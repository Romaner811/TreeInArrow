using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemExplosionBehaviour : LongBehaviour
{
    public SpriteRenderer Renderer;

    public float ExplosionSpeed;

    private Color transparentColor;

    public void Explode()
    {
        this.transparentColor = this.Renderer.color;
        this.transparentColor.a = 0;

        this.Begin();
    }

    void Update()
    {
        // make more transparent
        this.Renderer.color = Color.LerpUnclamped(this.Renderer.color, this.transparentColor, this.Progress / 2f);

        // scale up
        this.transform.localScale *= 1f + this.ExplosionSpeed * Time.deltaTime;

        this.Step(this.ExplosionSpeed);
        if (this.IsFinished)
        {
            GameObject.Destroy(this.gameObject);
            print("destroyed!");
        }
    }
}
