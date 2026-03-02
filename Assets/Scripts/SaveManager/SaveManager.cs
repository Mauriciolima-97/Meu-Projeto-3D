using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class SaveManager : Singleton<SaveManager>
{
    [SerializeField] private SaveSetup _saveSetup;
    private string _path => Application.streamingAssetsPath + "/save.txt";

    public int lastLevel;

    public Action<SaveSetup> FileLoaded;
    public bool IsNewGame { get; private set; }

    public SaveSetup Setup
    {
        get {  return _saveSetup; }
    }

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);

        LoadGame();
    }

    private void CreateNewSave()
    {
        _saveSetup = new SaveSetup();
        _saveSetup.lastLevel = 1;
        _saveSetup.playerName = "Mauricio";
        _saveSetup.currentCloth = Cloth.ClothType.PADRAO;

        _saveSetup.playerPosX = 418f;
        _saveSetup.playerPosY = -8f;
        _saveSetup.playerPosZ = 15f;
    }

    #region SAVE
    [NaughtyAttributes.Button]
    private void Save()
    {
        string setupToJson = JsonUtility.ToJson(_saveSetup, true);
        Debug.Log(setupToJson);
        SaveFile(setupToJson);
    }
    public void SaveItens()
    {
        var itemManager = Itens.ItemManager.Instance;
        if (itemManager != null)
        {
            _saveSetup.coins = itemManager.GetItemByType(Itens.ItemType.COIN).soInt.value;
            _saveSetup.health = itemManager.GetItemByType(Itens.ItemType.LIFE_PACK).soInt.value;
        }

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            _saveSetup.playerPosX = playerObj.transform.position.x;
            _saveSetup.playerPosY = playerObj.transform.position.y;
            _saveSetup.playerPosZ = playerObj.transform.position.z;
        }

        Save();
    }
    public void SaveName(string text)
    {
        _saveSetup.playerName = text;
        Save();
    }
    public void SaveLastLevel(int level)
    {
        _saveSetup.lastLevel = level;
        SaveItens();
        Save();
    }
    #endregion
    private void SaveFile(string json)
    {
        Debug.Log(_path);
        File.WriteAllText(_path, json);
    }
    [NaughtyAttributes.Button]
    public void LoadGame()
    {
        string fileloaded = "";

        if (File.Exists(_path))
        {
            fileloaded = File.ReadAllText(_path);
            _saveSetup = JsonUtility.FromJson<SaveSetup>(fileloaded);
            lastLevel = _saveSetup.lastLevel;
        }
        else
        {
            CreateNewSave();
            Save();
        }

        FileLoaded?.Invoke(_saveSetup);
        IsNewGame = false;
    }
    public void ResetSave()
    {
        CreateNewSave();
        Save();
        IsNewGame = true;
    }
    [NaughtyAttributes.Button]
    public void ResetPosition()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            var characterController = playerObj.GetComponent<CharacterController>();
            if (characterController != null) characterController.enabled = false;

            playerObj.transform.position = Vector3.zero;

            if (characterController != null) characterController.enabled = true;
        }
    }


    /*[NaughtyAttributes.Button]
    private void SaveLevelOne()
    {
        SaveLastLevel(1);
    }
    [NaughtyAttributes.Button]
    private void SaveLevelFive()
    {
        SaveLastLevel(5);
    }*/

}


[System.Serializable]
public class SaveSetup
{
    public int lastLevel;
    public float coins;
    public float health;

    public string playerName;
    public string saveGame;

    public float playerPosX;
    public float playerPosY;
    public float playerPosZ;

    public List<string> collectedItems = new List<string>();
    public List<string> deadEnemies = new List<string>();
    public Cloth.ClothType currentCloth = Cloth.ClothType.SPEED;

}
