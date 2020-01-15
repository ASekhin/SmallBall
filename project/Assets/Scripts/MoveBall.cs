using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    public Transform ball;
    // Изменение скорости перемещения героя
    public float playerSpeed = 2.0f;

    // Текущая скорость перемещения
    private float currentSpeed = 0.0f;

    // Создание переменных для кнопок
    public List<KeyCode> leftButton;
    public List<KeyCode> rightButton;
    // Кнопка, которая используется для выстрела
    public List<KeyCode> shootButton;

    // Сохранение последнего перемещения
    private Vector3 lastMovement = new Vector3();


    // Задержка между выстрелами (кулдаун)
    public float timeBetweenFires = 0.3f;

    // Счетчик задержки между выстрелами
    private float timeTilNextFire = 0.0f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        foreach (KeyCode element in shootButton)
        {
            if (Input.GetKey(element) && timeTilNextFire < 0)
            {
                timeTilNextFire = timeBetweenFires;
                ShootLaser();
                break;
            }
        }
        timeTilNextFire -= Time.deltaTime;
    }
    void Movement()
    {
        Vector3 movement = new Vector3();
        movement += MoveIfPressed(leftButton, Vector3.left);
        movement += MoveIfPressed(rightButton, Vector3.right);

        movement.Normalize();

        if (movement.magnitude > 0)
        {
            currentSpeed = playerSpeed;
            this.transform.Translate(movement * Time.deltaTime*currentSpeed, Space.World);
            lastMovement = movement;

        }
        else
        {
            this.transform.Translate(lastMovement * Time.deltaTime * currentSpeed, Space.World);
            currentSpeed *= 0.9f;
        }

    }

    Vector3 MoveIfPressed(List<KeyCode> keyList, Vector3 Movement)
    {
        foreach (KeyCode element in keyList)
        {
            if (Input.GetKey (element))
            {
                return Movement;
            }
        }
        return Vector3.zero;
    }

    // Создание лазера
    void ShootLaser()
    {
        // Высчитываем позицию корабля
        float posX = 0.0f;
        float posY = 4.5f;
        // Создаём лазер на этой позиции
        Instantiate(ball, new Vector3(posX, posY, 0), this.transform.rotation);
    }
}
