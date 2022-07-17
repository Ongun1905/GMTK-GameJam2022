using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour
{

    private bool rollButtonClicked = false;

    private void Update()
    {
    }

    private void InitiativeRoll()
    {
        while (!rollButtonClicked) { } // We wait until player rolls for initiative
    }
}
