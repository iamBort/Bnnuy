using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    //metoda pro ukládání; ukládám save někde v systému(adresu získávám z Application.persistentDataPath, proto aby se nestalo, že cesta nebude existovat a hráč jen tak nebude vědět,
    // kde se to nachází); ukládá se v bináru(kvůli horší  editaci souboru)
    public void Save(string name)  {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/save.bnuuy";

        FileStream fileStream = new FileStream(path, FileMode.Create);

        Data data = new Data(PlayerPrefs.GetFloat("time"), name);

        formatter.Serialize(fileStream, data);
        Debug.Log("Saved");

        fileStream.Close();
    }

    /*
    public void Load()  //metoda pro load savu
    {
        string path = Application.persistentDataPath + "/save.bnuuy";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream fileStream = new FileStream(path, FileMode.Open);

            Data data = formatter.Deserialize(fileStream) as Data;

            //ukládání kam potřebujeme
        }
        else
        {
            Debug.Log("Žádný save");
        }
    }*/

    public float GetTimeFromLoad()   //metoda, která získá nejvyšší skóre ze savu 
    {
        string path = Application.persistentDataPath + "/save.bnuuy";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream fileStream = new FileStream(path, FileMode.Open);

            Data data = formatter.Deserialize(fileStream) as Data;
            fileStream.Close();

            return data.time;
        }
        else
        {
            Debug.Log("Žádný save");
            return 1;
        }
    }

    public string GetNameFromLoad()   //metoda, která získá jméno hráče s nejvyšším skóre ze savu 
    {
        string path = Application.persistentDataPath + "/save.bnuuy";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream fileStream = new FileStream(path, FileMode.Open);

            Data data = formatter.Deserialize(fileStream) as Data;
            fileStream.Close();

            return data.name;
        }
        else
        {
            Debug.Log("Žádný save");
            return "";
        }
    }

    public bool FileExists()    // //metoda, která vrací boolean o tom jestli save existuje 
    {
        string path = Application.persistentDataPath + "/save.bnuuy";

        if (File.Exists(path))
        {
            return true;
        }
        else
        {
            Debug.Log("Žádný save");
            return false;
        }
    }
}


[System.Serializable]
public class Data   //třída, díky které snadněji pracuji s daty
{
    public float time;
    public string name;

    public Data(float _time, string _name)
    {
        time = _time;
        name = _name;
    }
}