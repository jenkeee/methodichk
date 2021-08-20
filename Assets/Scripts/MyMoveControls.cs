using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMoveControls : MonoBehaviour
{
    [SerializeField] private float _speed; // �������� ��������, � � ���������� ���������
    [SerializeField] private Vector3 _direction; // ����������� ��������

    [SerializeField] private GameObject _mine; // ���� ����
    [SerializeField] private Transform _mineSpawnPlace; // �����, ��� ��������� 


    void Start()
    {
        
    }

    private void Update()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");

        // ���� ������ ������  
        if (Input.GetKeyDown( KeyCode.Space))
        {
            Instantiate(_mine, _mineSpawnPlace.position, _mineSpawnPlace.rotation);
            // ������� _mine � ����� _mineSpawnPlace
        }

    }

    private void FixedUpdate()
    {
        var speed = _direction * _speed * Time.deltaTime;
        transform.Translate(speed);
    }

}
