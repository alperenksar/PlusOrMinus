using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BaloonController : MonoBehaviour
{

    [SerializeField] private GameObject Baloon;

    [SerializeField] private float Speed = 1f;

   



    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        VerticalBallMovement();
        if (transform.position.z < -3)
        {
            transform.position = new Vector3(-17.8f, 57.1f, 160.7f);
        }
        
        
    }

    private void VerticalBallMovement()
    {
        transform.Translate(-Vector3.forward * Speed * Time.deltaTime);

        transform.Translate(Vector3.up * Speed *3* Time.deltaTime);

    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
