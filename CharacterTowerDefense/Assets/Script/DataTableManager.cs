using System.Collections.Generic;
using UnityEngine;

public class DataTableManager : Singleton<DataTableManager>
{
    private Dictionary<string, ScriptableObject> AllDataTable = new Dictionary<string, ScriptableObject>();


    public void Load<T>(string _path) where T : ScriptableObject
    {
        string Name = _path.Substring(7);
        ScriptableObject dt = Resources.Load<T>(_path);
        AllDataTable.Add(Name, dt);
    }

    public ScriptableObject GetDataTable(string _Name)
    {
        return AllDataTable[_Name];
    }
}
