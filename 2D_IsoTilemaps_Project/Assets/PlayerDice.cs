using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDice : MonoBehaviour
{
    private Sprite[] diceSides;
    private SpriteRenderer rend;
    
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
