using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMoveControls : MonoBehaviour
{
    [SerializeField] private float _speed; // Скорость движения, а в дальнейшем ускорение
    [SerializeField] private Vector3 _direction; // Направление движения

    [SerializeField] private GameObject _mine; // Наша мина
    [SerializeField] private Transform _mineSpawnPlace; // точка, где создается 


    void Start()
    {
        
    }

    private void Update()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");

        // Если нажата кнопка  
        if (Input.GetKeyDown( KeyCode.Space))
        {
            Instantiate(_mine, _mineSpawnPlace.position, _mineSpawnPlace.rotation);
            // Создаем _mine в точке _mineSpawnPlace
        }

    }

    private void FixedUpdate()
    {
        var speed = _direction * _speed * Time.deltaTime;
        transform.Translate(speed);
    }

}
