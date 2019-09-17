using System.Collections.Generic;
using UnityEngine;

public class JsonData : MonoBehaviour
{
    [SerializeField]
    private string fileName;
    
    private string filePath;
    
    private JsonWrapper _wrapper = new JsonWrapper();

    [SerializeField]
    public NPCData npcData = new NPCData();

    /*
    [SerializeField]
    private string name;
    [SerializeField]
    public float textSpeed = 0;
    [SerializeField]
    public List<string> dialogueLines = new List<string>();
    */

    private void Awake()
    {
        if (fileName != null)
        {
            filePath = Application.persistentDataPath + "/" + fileName;
            Debug.Log(filePath);
        }
        else
        {
            filePath = Application.persistentDataPath + "/" + "default.json";
            Debug.Log(filePath);
        }
        npcData = _wrapper.ReadData(filePath);
    }
        /* 
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
   