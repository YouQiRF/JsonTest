using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class JsonData : MonoBehaviour
{
    public int A;
    public string B;
    public double C;


    class MyClass
    {
        public int A;
        public string B;
        public double C;
    }
    MyClass myObject = new MyClass();

    public void SaveData()
    {
        ChangData();
        string savetojson = JsonUtility.ToJson(myObject);
        StreamWriter streamWriter = new StreamWriter(Path.Combine("Assets/PlayerData", "Data1"));
        streamWriter.Write(savetojson);
        streamWriter.Close();
    }
    public void LoadFata()
    {
        StreamReader streamReader = new StreamReader(new FileStream(Path.Combine("Assets/PlayerData/Data1"), FileMode.Open));
        myObject = JsonUtility.FromJson<MyClass>(streamReader.ReadToEnd());
        A = myObject.A;
        B = myObject.B;
        C = myObject.C;
        streamReader.Close();

    }
    public void LogData()
    {
        Debug.Log(A);
        Debug.Log(B);
        Debug.Log(C);
    }

    void ChangData()
    {
        myObject.A = A;
        myObject.B = B;
        myObject.C = C;
    }
}
