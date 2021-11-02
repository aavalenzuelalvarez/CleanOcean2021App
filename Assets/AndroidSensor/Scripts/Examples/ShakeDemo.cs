using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.Networking;

public class ShakeDemo : MonoBehaviour {
	
	private ShakePlugin shakePlugin;
    //public Text shakeCountText;
    public Button Contador;
	public Text shakeSpeedText;

	public Text sensitivityText;
	public Slider sensitivitySlider;

	public Text delayUpdateText;
	public Slider delayUpdateSlider;
    public static int pasos = 0;
	public static int pasosTotales = 0;
	private int periodito = 202102;

	
	// Use this for initialization
	void Start (){
		// don't allow the device to sleep
		pasosTotales = 0;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		
		shakePlugin = ShakePlugin.GetInstance();
		shakePlugin.SetDebug(0);
		shakePlugin.Init();
		SetSensitivitySlider();
		SetDelayUpdateSlider();

		shakePlugin.SetCallbackListener(OnShake);
		shakePlugin.RegisterSensorListener(SensorDelay.SENSOR_DELAY_NORMAL);
	}

	private void SetSensitivitySlider(){
        //int sensitivity = (int)sensitivitySlider.value;
        int sensitivity = 1000;
		UpdateSensitivity(sensitivity);
		Debug.Log("CheckSensitivitySlider value: " + sensitivity);
	}

	private void SetDelayUpdateSlider(){
        //int delayUpdate = (int)delayUpdateSlider.value;
        int delayUpdate = 150;
		UpdateDelayUpdate(delayUpdate);
		Debug.Log("CheckDelayUpdateSlider value: " + delayUpdate);
	}

	public void OnSensitivitySliderChange(){
		SetSensitivitySlider();
	}

	public void OnDelayUpdateSliderChange(){
		SetDelayUpdateSlider();
	}

	private void OnApplicationPause(bool val){
		if(val){
			if(shakePlugin!=null){
				shakePlugin.RemoveSensorListener();
			}
		}else{
			if(shakePlugin!=null){
				shakePlugin.RegisterSensorListener(SensorDelay.SENSOR_DELAY_NORMAL);
			}
		}
	}

	private void OnShake(int count, float speed){
		pasosTotales = pasosTotales + 1;
		RegistraSaltosTotales(pasosTotales);
		UpdateShakeCount(count);
		//UpdateShakeSpeed(speed);
	}

	private void UpdateSensitivity(int sensitivity){
		if(shakePlugin!=null){
			shakePlugin.SetSensitivity(sensitivity);
           // sensitivity = 10000;
			//if(sensitivityText!=null){
			//	sensitivityText.text = String.Format("Sensitivity: {0}",sensitivity);
			//}
		}
	}

	private void UpdateDelayUpdate(int delayUpdate){
		if(shakePlugin!=null){
			shakePlugin.SetDelayUpdate(delayUpdate);
            //delayUpdate = 150;
			//if(delayUpdateText!=null){
			//	delayUpdateText.text = String.Format("Delay Update: {0}",delayUpdate);
			//}
		}
	}

	public void UpdateShakeCount(int count){
		if(Contador.GetComponentInChildren<Text>().text != null){
            //shakeCountText.text = String.Format("Shake Count: {0}",count);
            pasos ++;
            // GameObject.Find("Conexiones").GetComponent<Conexiones>().Pasos();
            Contador.GetComponentInChildren<Text>().text = String.Format("Saltos realizados: {0}", pasos);            
		}
	}

/*	private void UpdateShakeSpeed(float speed){
		if(shakeCountText!=null){
			shakeSpeedText.text = String.Format("Shake Speed: {0}",speed);
		}
	}*/

	public void ResetShakeCount(){
		if(shakePlugin!=null){
			shakePlugin.ResetShakeCount();
			UpdateShakeCount(0);
            pasos = 0;
            Contador.GetComponentInChildren<Text>().text = String.Format("Saltos realizados: 0");
        }
	}

	private IEnumerator PostAdd(Respuesta respueston)
    {
        string urlAPI = cambiarApiServidor.URL + "/alumno_respuesta/add"; //"http://localhost:3002/api/alumno_respuesta/add";
        var jsonData = JsonUtility.ToJson(respueston);
        //Debug.Log(jsonData);

        using (UnityWebRequest www = UnityWebRequest.Post(urlAPI, jsonData))
        {
            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
                Debug.Log("Error");
            }
            else
            {
                if (www.isDone)
                {
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    if (result != null)
                    {
                        //var id_txa = JsonUtility.FromJson<String>(result);
                        //Debug.Log(id_txa);
                    }
                }
            }
        }
    }

	private void RegistraSaltosTotales(int pasosTotales){
        Respuesta RespuestaBasura;
        RespuestaBasura = new Respuesta();
        RespuestaBasura.id_per = periodito;
        RespuestaBasura.id_user = int.Parse(Conexiones.id_user);
        RespuestaBasura.id_reim = 500;
        RespuestaBasura.id_actividad = 3004;
        RespuestaBasura.id_elemento = 3096;
        DateTime ahora = DateTime.Now;
        RespuestaBasura.datetime_touch = ahora.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        RespuestaBasura.Eje_X = 0;
        RespuestaBasura.Eje_Y = 0;
        RespuestaBasura.Eje_Z = 0;
        RespuestaBasura.correcta = 2;
        RespuestaBasura.resultado = "Salto nro : " + pasosTotales;
        RespuestaBasura.Tipo_Registro = 0;
        StartCoroutine(PostAdd(RespuestaBasura));
    }
}