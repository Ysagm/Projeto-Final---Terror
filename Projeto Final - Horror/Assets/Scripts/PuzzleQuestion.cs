using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuzzleQuestion : MonoBehaviour
{   

    public TextMeshProUGUI riddle;
    public TextMeshProUGUI respostaD;
    public TextMeshProUGUI respostaE;

    public string[] riddles; //Armazena pergunta
    public string[] answerD; //Armazena resposta
    public string[] answerE;
    public string[] certas; //Armazena resposta certa

    private int idRiddle;

    //ideia: decisão de vitoria ou derrota (ending diferente dependendo da quantidade de acertos)
    private float acertos;
    private float quantRiddles;
    private float media;

    void Start()
    {
        idRiddle = 0;
        quantRiddles = riddles.Length;
        riddle.text = riddles[idRiddle];

        riddle.text = riddles[idRiddle];
        respostaE.text = answerE[idRiddle];
        respostaD.text = answerD[idRiddle];
    }

    public void Resposta(string answer)
    {
       if(answer == "E"){
            if(answerE[idRiddle] == certas[idRiddle])
            {
                acertos++;
                Debug.Log("Acertou D");
            }
        }
        else if (answer == "D"){
            if(answerD[idRiddle] == certas[idRiddle])
            {
                acertos++;
                Debug.Log("Acertou D");
            }
                
        }
        NextQuestion();
    }

    void NextQuestion()
    {
        idRiddle += 1;

        riddle.text = riddles[idRiddle];
        respostaE.text = answerE[idRiddle];
        respostaD.text = answerD[idRiddle];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}