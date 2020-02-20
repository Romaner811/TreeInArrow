using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ThreeInARow.Unity;

public class ThreeInARowGame : MonoBehaviour
{
    public int Width, Heigth;

    public GameObject SlotPrefab;
    public GameObject BoardGameObject;
    
    public GameObject RedCirclePrefab;
    public GameObject GreenCirclePrefab;
    public GameObject YellowCirclePrefab;
    public GameObject BlueCirclePrefab;

    private MyUnityGame game;

    // Start is called before the first frame update
    void Start()
    {
        this.game = new MyUnityGame(
            this.Width, this.Heigth,
            this.SlotPrefab,
            this.BoardGameObject,
            new GameObject[]
            {
                this.RedCirclePrefab,
                this.GreenCirclePrefab,
                this.YellowCirclePrefab,
                this.BlueCirclePrefab,
            }
        );
    }

    // Update is called once per frame
    void Update()
    {
        this.game.Update();
    }
}
