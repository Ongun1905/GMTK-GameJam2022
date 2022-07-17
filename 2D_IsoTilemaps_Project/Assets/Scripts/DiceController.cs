using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour
{
    private Sprite[] diceSides;
    private SpriteRenderer rend;

    private bool diceRolled = false;

    // Start is called before the first frame update
    void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("Dice/");

        rend.sprite = diceSides[5];
    }

    private void OnMouseDown()
    {
        StartCoroutine(RollTheDice());
    }

    public IEnumerator RollTheDice()
    {
        int randomDiceSide = 1;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(1, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }

        GameManager.diceSideThrown = randomDiceSide + 1;

        if (!GameManager.inEncounter)
        {
            GameManager.gm.StartCoroutine(GameManager.gm.MovePlayer());
        }
        diceRolled = true;
    }

    public void ResetDiceRolled()
    {
        diceRolled = false;
    }

    public bool GetDiceRolledSinceLastReset()
    {
        return diceRolled;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

