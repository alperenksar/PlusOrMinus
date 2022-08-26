using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallController : MonoBehaviour
{
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private TMP_Text _ballCountText = null;
    [SerializeField] private List<GameObject> _balls=new List<GameObject>();

    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _verticalSpeed;
    [SerializeField] private float _horizontalLimit;

    private float _horizontal;

    private int GateNumber;

    private int _targetCount;

    void Update()
    {
        HorizontalBallMovement();
        VerticalBallMovement();
        UpdateBallCount();

        
    }

    private void HorizontalBallMovement()
    {
        float _newX;

        if (Input.GetMouseButton(0))
        {
            _horizontal = Input.GetAxisRaw("Mouse X");
        }
        else
        {
            _horizontal=0;
        }

        _newX = transform.position.x + _horizontal * _horizontalSpeed * Time.deltaTime;

        _newX = Mathf.Clamp(_newX, -_horizontalLimit, _horizontalLimit);

        transform.position = new Vector3(_newX,transform.position.y,transform.position.z);
    }

    private void VerticalBallMovement()
    {
        transform.Translate(Vector3.forward * _verticalSpeed * Time.deltaTime);
                                       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BallStack"))
        {
            other.gameObject.transform.SetParent(transform);
            other.gameObject.GetComponent<SphereCollider>().enabled = false;
            other.gameObject.transform.localPosition = new Vector3(0f, 0f, _balls[_balls.Count - 1].transform.localPosition.z-1f);
            _balls.Add(other.gameObject);
        }

        if (other.gameObject.CompareTag("Gate"))
        {
            GateNumber = other.gameObject.GetComponent<GateController>().GetGateNumber();
            _targetCount = _balls.Count + GateNumber;


            if (GateNumber > 0)
            {
                Debug.Log("Gate number içine girdi.ýNCREASE BAKACAÐIZ");
                IncreaseBallCount();
            }
            else if (GateNumber < 0)
            {
                DecreaseBallCount();
            }
        }
    }

   

    private void IncreaseBallCount()
    {

        for (int i = 0; i < GateNumber; i++)
        {
            Debug.Log("FOR DÖNGÜSÜ baþý: " + _balls.Count);
            GameObject _newBall = Instantiate(_ballPrefab);
            _newBall.transform.SetParent(transform);
            _newBall.gameObject.GetComponent<SphereCollider>().enabled=false;
            _newBall.gameObject.transform.localPosition = new Vector3(0f, 0f, _balls[_balls.Count - 1].transform.localPosition.z - 1f);
            _balls.Add(_newBall);
            Debug.Log("FOR DÖNGÜSÜ SONU: " + _balls.Count);


        }
    }

    private void DecreaseBallCount()
    {
        for (int i = _balls.Count - 1; i >=_targetCount; i--)
        {
            _balls.RemoveAt(i);
        }



    }


    private void UpdateBallCount()
    {
        _ballCountText.text = _balls.Count.ToString();
    }








}
