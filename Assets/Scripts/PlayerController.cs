using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject; 
    public GameObject gameOverTextObject; 

    public float limitX = 10.0f;  
    public float limitZ = 10.0f;  
    public float menuLoadDelay = 2.0f; 

    private Rigidbody rb; 
    private int count;
    private float movementX;
    private float movementY;
    private Timer timerScript;

    // Start é chamado antes do primeiro frame update
    void Start()
    {
        count = 0; 
        rb = GetComponent<Rigidbody>(); 
        SetCountText();
        winTextObject.SetActive(false);
        gameOverTextObject.SetActive(false);

        // Busca o script do Timer
        timerScript = FindObjectOfType<Timer>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>(); 
        movementX = movementVector.x; 
        movementY = movementVector.y;
    }

    void SetCountText() 
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true);
            timerScript.ChangeColor();  // Muda a cor quando ganha
            StopGame();  // Para o jogo quando ganha
        }
    }

    private void FixedUpdate() 
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed); 
        if (Mathf.Abs(rb.position.x) > limitX || Mathf.Abs(rb.position.z) > limitZ)
        {
            GameOver();  // Para o jogo quando perde
        }
    }

    void GameOver()
    {
        gameOverTextObject.SetActive(true);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.constraints = RigidbodyConstraints.FreezeAll;

        timerScript.ChangeColor();  // Muda a cor quando perde
        StopGame();
    }

    void StopGame()
    {
        // Para o timer
        timerScript.StopTimer();

        // Aguarda o tempo antes de carregar o menu
        Invoke("LoadMenu", menuLoadDelay);
    }

    void LoadMenu()
    {
        SceneManager.LoadScene("MenuInicial");
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);  
            count = count + 1;
            SetCountText();
        }
    }
}
