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
        PlayerPrefs.SetString("GameData", json);
        Debug.Log(json);
        Debug.Log("Saving Game Data Completed");
    }

    private void LoadGameFlags()
    {
        var json = PlayerPrefs.GetString("GameData");
        _gameData = JsonUtility.FromJson<GameData>(json); //new GameData();
        if (_gameData == null)
            _gameData = new GameData();
        
        FlagManager.Instance.Bind(_gameData.GameFlagDatas);
    }
}