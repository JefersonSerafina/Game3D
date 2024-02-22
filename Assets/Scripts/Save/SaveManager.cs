using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class SaveManager : Singleton<SaveManager>
{
    [SerializeField]private SaveSetup _saveSetup;
    private string _path = Application.streamingAssetsPath + "/save.txt";

    public int lastLevel;

    public Action<SaveSetup> FileLoaded;

    public SaveSetup Setup
    {
        get { return _saveSetup; }
    }

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void CreateNewSave()
    {
        _saveSetup = new SaveSetup();
        _saveSetup.lastLevel = 0;
        _saveSetup.playerName = "Rafael";
    }

    private void Start()
    {
        Invoke(nameof(Load), .1f);
    }

    #region SAVE
    [NaughtyAttributes.Button]
    private void Save()
    {
        string setupToJason = JsonUtility.ToJson(_saveSetup);
        SaveFile(setupToJason);
    }

    public void SaveItens()
    {
        _saveSetup.coins = Itens.ItemManager.Instance.GetItemByType(Itens.ItemType.COIN).soInt.value;
        _saveSetup.coins = Itens.ItemManager.Instance.GetItemByType(Itens.ItemType.LIFE_PACK).soInt.value;
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
        File.WriteAllText(_path, json);
    }

    [NaughtyAttributes.Button]
    private void Load()
    {
        string fileLoaded = "";

        if (File.Exists(_path)) 
        {
            fileLoaded = File.ReadAllText(_path);

            _saveSetup = JsonUtility.FromJson<SaveSetup>(fileLoaded);

            lastLevel = _saveSetup.lastLevel;
        }
        else
        {
            CreateNewSave();
            Save();
        }


        FileLoaded.Invoke(_saveSetup);
    }

    private void SaveLevelOne()
    {
        SaveLastLevel(1);
    }
}

[System.Serializable]
public class SaveSetup
{
    public float coins;
    public float health;
    public int lastLevel;
    public string playerName;
}
