using System.Collections.Generic;

public class GameData
{
    public List<GameFlagData> GameFlagDatas;

    public GameData()
    {
        GameFlagDatas = new List<GameFlagData>();
        GameFlagDatas.Add(new GameFlagData() {Value = "jason 1", Name = "flagname"});
    }
}