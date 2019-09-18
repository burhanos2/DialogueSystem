using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JsonWrapper
{
    public NPCData npcData;

    /*
     this bit is for saving, which I wont use for now, I am keeping it in here for later

    public void SaveData(string filePath, NPCData npc)
    {
        JsonWrapper wrapper = new JsonWrapper();
        wrapper.npcData = npc;

        string contents = JsonUtility.ToJson(wrapper, true);
        System.IO.File.WriteAllText(filePath, contents);
    }
    */

    public NPCData ReadData(string filePath)
    {
        try
        {
            if (System.IO.File.Exists(filePath))
            {
                string contents = System.IO.File.ReadAllText(filePath);
                JsonWrapper wrapper = JsonUtility.FromJson<JsonWrapper>(contents);
                return wrapper.npcData;
            }
            else
            {
                Debug.Log("Unable to read the dialoguedata, file does not exist");
                return new NPCData(); 
            }
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
            return null;
        }
    }
}


