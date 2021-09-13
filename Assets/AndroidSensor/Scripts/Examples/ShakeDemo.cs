using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

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

	
	// Use this for initialization
	void Start (){
		// don't allow the device to sleep
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
            GameObject.Find("Conexiones").GetComponent<Conexiones>().Pasos();
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
}