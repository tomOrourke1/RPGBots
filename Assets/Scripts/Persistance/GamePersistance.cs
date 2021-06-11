using System;
using System.Collections;
using UnityEngine;

public class GamePersistance : MonoBehaviour
{
    public GameData _gameData;

    void Start() => LoadGameFlags();
    void OnDisable() => SaveGameFlags();

    void SaveGameFlags()
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
        _gameData = JsonUtility.FromJson<GameData>(json);
        if (_gameData == null)
            _gameData = new GameData();
        
        FlagManager.Instance.Bind(_gameData.GameFlagDatas);
        InspectionManager.Bind(_gameData.InspectableDatas);
    }
}