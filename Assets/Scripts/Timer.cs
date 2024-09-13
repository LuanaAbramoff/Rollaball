using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;
    public bool isGameRunning = true;  // Controla se o timer está rodando

    public Color endGameColor = Color.red;  // Escolha a cor desejada

    // Update é chamado uma vez por frame
    void Update()
    {
        if (isGameRunning)  // Só atualiza o tempo se o jogo estiver rodando
        {
            elapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
    
    public void StopTimer()
    {
        isGameRunning = false;  // Para a contagem do tempo
    }

    // Função para alterar a cor do texto
    public void ChangeColor()
    {
        timerText.color = endGameColor;  // Muda a cor do texto
    }
}
