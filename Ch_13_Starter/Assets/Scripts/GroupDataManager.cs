using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

[Serializable] 
public class GroupMember
{
    public string name;
    public string dateOfBirth;
    public string favoriteColor;
}

[Serializable]
public class GroupData
{
    public List<GroupMember> members = new List<GroupMember>();
}

public class GroupDataManager : MonoBehaviour
{
    private string folderPath;
    private string xmlFilePath;
    private string jsonFilePath;

    void Start()
    {
        // 1. Create Directory
        folderPath = Path.Combine(Application.persistentDataPath, "GroupData");
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            Debug.Log("✅ Directory created at: " + folderPath);
        }

        // Set paths
        xmlFilePath = Path.Combine(folderPath, "group_members.xml");
        jsonFilePath = Path.Combine(folderPath, "group_members.json");

        // 2. Create Group Data
        GroupData group = new GroupData();
        group.members.Add(new GroupMember { name = "Alice", dateOfBirth = "2000-01-01", favoriteColor = "Blue" });
        group.members.Add(new GroupMember { name = "Bob", dateOfBirth = "1999-12-12", favoriteColor = "Red" });
        group.members.Add(new GroupMember { name = "Charlie", dateOfBirth = "2001-05-23", favoriteColor = "Green" });

        // 3. Save to XML
        SaveToXML(group);

        // 4. Read from XML and save as JSON
        GroupData loadedGroup = LoadFromXML();
        SaveToJSON(loadedGroup);
    }

    void SaveToXML(GroupData data)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(GroupData));
        using (FileStream stream = new FileStream(xmlFilePath, FileMode.Create))
        {
            serializer.Serialize(stream, data);
        }
        Debug.Log("📄 XML saved to: " + xmlFilePath);
    }

    GroupData LoadFromXML()
    {
        if (!File.Exists(xmlFilePath))
        {
            Debug.LogError("❌ XML file not found!");
            return null;
        }

        XmlSerializer serializer = new XmlSerializer(typeof(GroupData));
        using (FileStream stream = new FileStream(xmlFilePath, FileMode.Open))
        {
            return (GroupData)serializer.Deserialize(stream);
        }
    }

    void SaveToJSON(GroupData data)
    {
        if (data == null)
        {
            Debug.LogError("❌ Cannot save to JSON. GroupData is null.");
            return;
        }

        string json = JsonUtility.ToJson(data, true); // true = pretty print
        File.WriteAllText(jsonFilePath, json);
        Debug.Log("📄 JSON saved to: " + jsonFilePath);
    }
}
