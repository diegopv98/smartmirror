using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class Configuracion : MonoBehaviour {

    public static Configuracion Ins;

    void Awake()
    {
        Ins = this;
        //GuardarObjeto();
        print(Application.persistentDataPath);
        print(Application.dataPath);
        CargarObjeto();
    }
    
    public BaseDeDatos BDatos;

    public void GuardarObjeto() {

      //var folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
      //  folder = folder + "/Screenshots/editor_config.xml";
        XmlSerializer serializer = new XmlSerializer(typeof(BaseDeDatos));
        FileStream stream = new FileStream(Application.persistentDataPath + "/StreamingAssets/editor_config.xml", FileMode.Create);
        serializer.Serialize(stream, BDatos);
        stream.Close();
    }

    public void SobrePonerDatos(bool PantallaPrincipal)
    {

        if (PantallaPrincipal == true)
        {
            int i = -1;
            foreach (EntradaItems item in Configuracion.Ins.BDatos.list)
            {
                i++;
                Debug.Log("Items");

                switch (i)
                {
                    case 0:
                        Interfaz.Rota =item.valorNumerico ;
                        break;
                    case 1:
                        if (item.valorNumerico == 1) { Interfaz.Invertir = true; } else { Interfaz.Invertir = false; }
                        break;
                    case 2:
                        Interfaz.camName = item.valorString;
                        break;
                    case 3:
                        Interfaz.FPS = item.valorNumerico;
                        break;
                    case 4:
                        Interfaz.rojo = float.Parse(item.valorString);
                        break;
                    case 5:
                        Interfaz.verde = float.Parse(item.valorString);
                        break;
                    case 6:
                        Interfaz.azul = float.Parse(item.valorString);
                        break;
                    case 7:
                        Interfaz.alto = item.valorNumerico;
                        break;
                    case 8:
                        Interfaz.ancho = item.valorNumerico;
                        break;
                }
            }
        }
    }

        public void ActualizarDatos() {
            int i = -1;
            foreach (EntradaItems item in Configuracion.Ins.BDatos.list) {
                i++;
                Debug.Log("Items");

                switch (i)
                {
                    case 0:
                        item.valorNumerico = Opciones.valoresFinales[0];
                        break;
                    case 1:
                        item.valorNumerico = Opciones.valoresFinales[1];
                        break;
                    case 2:
                        item.valorString = Opciones.nombreCamara;
                        break;
                    case 3:
                        item.valorNumerico = Opciones.valoresFinales[2];
                        break;
                    case 4:
                        item.valorString = Opciones.red.ToString();
                        break;
                    case 5:
                        item.valorString = Opciones.green.ToString();
                        break;
                    case 6:
                        item.valorString = Opciones.blue.ToString();
                        break;
                    case 7:
                        item.valorNumerico = Opciones.valoresFinales[3];
                        break;
                    case 8:
                        item.valorNumerico = Opciones.valoresFinales[4];
                        break;
                }

                GuardarObjeto();
            }
        }

       

        public void CargarObjeto() {
            
            XmlSerializer serializer = new XmlSerializer(typeof(BaseDeDatos));
            FileStream stream = new FileStream(Application.persistentDataPath + "/StreamingAssets/editor_config.xml", FileMode.Open);
        if (stream != null)
        {
            Debug.Log("No hay que verga");
        }
        else {
            Debug.Log("Si hay archivo");
        }
            BDatos = serializer.Deserialize(stream) as BaseDeDatos;
            stream.Close();
        SobrePonerDatos(true);
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