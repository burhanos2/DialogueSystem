using System.Collections.Generic;
using UnityEngine;

public class JsonData : MonoBehaviour
{
    //make it save when there is no file. maybe add customizability in editor
    [SerializeField]
    private string fileName;
    
    private string filePath;
    
    private JsonWrapper _wrapper = new JsonWrapper();

    [SerializeField]
    public NPCData npcData = new NPCData();

    //Application.persistentDataPath can be used to store to and read from appdata
    private void Awake()
    {
        if (fileName != null)
        {
            filePath = Application.dataPath + "/Json/" + fileName;
            Debug.Log("successfully loaded in: " + filePath);
        }
        else
        {
            filePath = Application.dataPath + "/Json/" + "default.json";
            Debug.Log("no file set, loaded in: " + filePath);
        }
        npcData = _wrapper.ReadData(filePath);
    }
        /* 
         this bit is for saving, which I wont use for now, im keeping it in here for later.

        if (Input.GetKeyDown(KeyCode.S))
        {
            npcData.name = name;
            npcData.textSpeed = textSpeed;
            npcData.dialogueLines = dialogueLines;

            _wrapper.SaveData(filePath, this.npcData);
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            npcData = _wrapper.ReadData(filePath);
        }
        */
    
}
   