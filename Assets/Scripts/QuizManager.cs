using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class QuizManager : MonoBehaviour
{
    [SerializeField]private Color m_correctColor = Color.black;
    [SerializeField]private Color m_incorrectColor = Color.black;
    [SerializeField]private float m_waitTimeWin = 0.0f;
    [SerializeField]private float m_waitTimeLose = 0.0f;
    private QuizDB m_quizDB = null;
    private QuizUI m_quizUI = null;
    [SerializeField]private GameObject PanelCorrecto;
    [SerializeField]private GameObject PanelIncorrecto;
    public int periodito = 202102;
    private float ejesitox;
    private float ejesitoz;
    private float ejesitoy;

    // Start is called before the first frame update
    private void Start()
    {
        m_quizDB = GameObject.FindObjectOfType<QuizDB>();
        m_quizUI = GameObject.FindObjectOfType<QuizUI>();
        NextQuestion();
    }

    private void NextQuestion(){
        PanelCorrecto.SetActive(false);
        PanelIncorrecto.SetActive(false);
        m_quizUI.Construct(m_quizDB.GetRandom(), GiveAnswer);
    }

    private void GiveAnswer(QuizOptionButton optionButton){
        StartCoroutine (GiveAnswerRoutine(optionButton));
    }

    public void RegistrarRespuestaCorrecta(){
        Respuesta BotonRespuesta;
        BotonRespuesta = new Respuesta();
        BotonRespuesta.id_per = periodito;
        BotonRespuesta.id_user = int.Parse(Conexiones.id_user);
        BotonRespuesta.id_reim = 500;
        BotonRespuesta.id_actividad = 3008;
        BotonRespuesta.id_elemento = 3092;
        DateTime ahora = DateTime.Now;
        BotonRespuesta.datetime_touch = ahora.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        BotonRespuesta.Eje_X = ejesitox;
        BotonRespuesta.Eje_Y = ejesitoy;
        BotonRespuesta.Eje_Z = ejesitoz;
        BotonRespuesta.correcta = 1;
        BotonRespuesta.resultado = "Respuesta Correcta";
        BotonRespuesta.Tipo_Registro = 1;
        StartCoroutine(PostAdd(BotonRespuesta));
    }

    public void RegistrarRespuestaIncorrecta(){
        Respuesta BotonRespuestaIncorrecta;
        BotonRespuestaIncorrecta = new Respuesta();
        BotonRespuestaIncorrecta.id_per = periodito;
        BotonRespuestaIncorrecta.id_user = int.Parse(Conexiones.id_user);
        BotonRespuestaIncorrecta.id_reim = 500;
        BotonRespuestaIncorrecta.id_actividad = 3008;
        BotonRespuestaIncorrecta.id_elemento = 3092;
        DateTime ahora = DateTime.Now;
        BotonRespuestaIncorrecta.datetime_touch = ahora.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        BotonRespuestaIncorrecta.Eje_X = ejesitox;
        BotonRespuestaIncorrecta.Eje_Y = ejesitoy;
        BotonRespuestaIncorrecta.Eje_Z = ejesitoz;
        BotonRespuestaIncorrecta.correcta = 0;
        BotonRespuestaIncorrecta.resultado = "Respuesta Incorrecta";
        BotonRespuestaIncorrecta.Tipo_Registro = 1;
        StartCoroutine(PostAdd(BotonRespuestaIncorrecta));
    }

    public IEnumerator PostAdd(Respuesta respueston)
    {
        string urlAPI = "http://localhost:3002/api/alumno_respuesta/add";
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

    private IEnumerator GiveAnswerRoutine(QuizOptionButton optionButton){
        if (optionButton.Option.correct){
            Debug.Log("Ta wena");
            RegistrarRespuestaCorrecta();
            PanelCorrecto.SetActive(true);
        }else{
            Debug.Log("Ta mala");
            RegistrarRespuestaIncorrecta();
            PanelIncorrecto.SetActive(true);
        }
        optionButton.SetColor( optionButton.Option.correct ? m_correctColor : m_incorrectColor );

        if (optionButton.Option.correct){
            yield return new WaitForSeconds( m_waitTimeWin);
        }else{
            yield return new WaitForSeconds( m_waitTimeLose );
        }
        NextQuestion();
    }
}
