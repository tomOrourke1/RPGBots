using System;
using System.Collections;
using UnityEngine;

public class GamePersistance : MonoBehaviour
{
    private GameData _gameData;

    void Start() => LoadGameFlags();
    private void OnDisable() => SaveGameFlags();

    private void SaveGameFlags()
    {
        Debug.Log("Saving Game Flags");

        var json = JsonUtility.ToJson(_gameData);
        Debug.Log(json);
        Debug.Log("Saving Game Data Completed");
    }

    private void LoadGameFlags()
    {
        _gameData = new GameData();
    }
}