using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizDB : MonoBehaviour
{
    [SerializeField] private List<QuizQuestion> m_questionList = null;
    [SerializeField] private GameObject PanelTermino;
    [SerializeField] private GameObject[] OcultarTermino;
    private int i;
    
    private List<QuizQuestion> m_backup = null;

    private void Awake(){
        m_backup = m_questionList.ToList();
        PanelTermino.SetActive(false);
        MostrarBotones();
    }
    
    public QuizQuestion GetRandom(bool remove = true){
        if(m_questionList.Count == 5){
            Debug.Log("Ganates");
            PanelTermino.SetActive(true);
            OcultarBotones();
            RestoreBackup();
        }
            
        int index = Random.Range(0, m_questionList.Count);
        QuizQuestion q = m_questionList[index];
        m_questionList.RemoveAt(index);
        return q;
    }

    public void MostrarBotones()
    {
        for (i = 0; i <= OcultarTermino.Length - 1; i++)
        {
            OcultarTermino[i].SetActive(true);
        }
    }
    
    public void OcultarBotones()
    {
        for (i = 0; i <= OcultarTermino.Length - 1; i++)
        {
            OcultarTermino[i].SetActive(false);
        }
    }

    private void RestoreBackup(){
        m_questionList = m_backup.ToList();
    }
}
