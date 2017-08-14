using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;
using System.IO;

public class Configuracion : MonoBehaviour {

    public static Configuracion Ins;

    void Awake()
    {
        Ins = this;
        GuardarObjeto();
        print(Application.persistentDataPath);
        print(Application.dataPath);
    }

    public BaseDeDatos BDatos;

    public void GuardarObjeto() {
        
        var folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        folder = folder + "/Screenshots/editor_config.xml";
        XmlSerializer serializer = new XmlSerializer(typeof(BaseDeDatos));
        FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/editor_config.xml", FileMode.Create);
        serializer.Serialize(stream, BDatos);
        stream.Close();
    }

    public void CargarObjeto() {
        var folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        folder = folder + "/Screenshots/editor_config.xml";
        XmlSerializer serializer = new XmlSerializer(typeof(BaseDeDatos));
        FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/editor_config.xml", FileMode.Create);
        serializer.Serialize(stream, BDatos);
        stream.Close();
    }

}


[System.Serializable]
public class EntradaItems {
    public string nombre;
    public int valorNumerico;
    public string valorString;

    }


[System.Serializable]
public class BaseDeDatos {
    [XmlArray("Configuraciones")]
    public List<EntradaItems> list = new List<EntradaItems>();
   }