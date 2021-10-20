using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizUI : MonoBehaviour
{
    [SerializeField] private Text m_question = null;
    [SerializeField] private List<QuizOptionButton> m_buttonList = null;
    [SerializeField] private Image m_image = null;
    [SerializeField] private Text m_panelcorrecto = null;
    [SerializeField] private Text m_panelincorrecto = null;
    
    
    

    public void Construct(QuizQuestion q, Action<QuizOptionButton> callback){
        m_question.text = q.text;
        m_image.sprite = q.foto;
        m_panelcorrecto.text = q.panelcorrecto;
        m_panelincorrecto.text = q.panelincorrecto;
        // m_image.sourceimage = q.foto;

        for(int n = 0; n < m_buttonList.Count ; n++){
            m_buttonList[n].Construct(q.options[n], callback);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
