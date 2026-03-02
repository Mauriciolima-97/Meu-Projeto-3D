using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [NaughtyAttributes.Button]
    private void Save()
    {
        SaveSetup setup = new SaveSetup();
        setup.lastLevel = 2;
        setup.playerName = "Mauricio";

        string setupToJson = JsonUtility.ToJson(setup, true);
        Debug.Log(setupToJson);
    }
    private void SaveFile(string json)
    {
        string path = Application.dataPath + "/save.txt";

        File.WriteAllText(path, json);
}

}


[System.Serializable]
public class SaveSetup
{
    public int lastLevel;
    public string playerName;
    public string saveGame;
}
