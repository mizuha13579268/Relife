using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LitJson;
public class ReadData : Singleton<ReadData>
{
    public Dictionary<string, List<Dictionary<string, object>>> ReadSkillData()
    {
        string FileName = "Assets/Resources/Json/SkillMsg.json";
        StreamReader json = File.OpenText(FileName);
        string input = json.ReadToEnd();
       
        Dictionary<string, List<Dictionary<string, object>>> jsonObject = JsonMapper.ToObject<Dictionary<string, List<Dictionary<string, object>>>>(input);
       // Debug.Log(jsonObject["SwordMan"][0]["Sprite"]);
        //foreach (var item in jsonObject.Keys)
        //{
        //    foreach (var items in jsonObject[item])
        //    {
        //        foreach (var itemss in items.Values)
        //        {
        //            Debug.Log(itemss);
        //        }
        //    }
        //}
        return jsonObject;
    }
}
