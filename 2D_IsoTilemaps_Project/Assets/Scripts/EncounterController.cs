using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterController : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] Vector3 PlayerEncounterPosition;
    
    private IsometricCharacterRenderer isoRenderer;

    private void Start()
    {
        isoRenderer = Player.GetComponentInChildren<IsometricCharacterRenderer>();

        SetPlayerToEncounterPosition();
    }

    private void SetPlayerToEncounterPosition()
    {
        Player.transform.position = PlayerEncounterPosition;
        isoRenderer.SetDirection(new Vector2(0f, -1f));
    }

    public void StartEncounter()
    {
        SetPlayerToEncounterPosition();
        
    }
}
