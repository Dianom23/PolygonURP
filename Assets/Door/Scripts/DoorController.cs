using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour, IInteraction
{
    [SerializeField] private float _openAngle = 90; // Угол открытой двери
    [SerializeField] private float _closeAngle = 0; // Угол закрытой двери
    [SerializeField] private float _duration = 1; // Угол закрытой двери
    [SerializeField] private bool _isInteractable = true; //Можно ли взаимодействовать с дверью

    private bool _isOpen = false; // Флаг для отслеживания состояния двери
    private bool _isOpening = false; // Флаг для отслеживания открывается ли дверь

    private void Start()
    {
        if (_isInteractable == false) //Если нельзя взаимодействовать с дверью 
        {
            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast"); //Изменить слой объекта, на игнорирующий лучи
        }

        Cursor.lockState = CursorLockMode.Locked; // Блокируем и скрываем курсор
    }

    public void Open()
    {
        //transform.localRotation = Quaternion.Euler(0, _openAngle, 0); 
        StartCoroutine(OpenDoor(_openAngle, _duration));
        _isOpen = true;
    }

    private void Close()
    {
        //transform.localRotation = Quaternion.Euler(0, _closeAngle, 0);
        StartCoroutine(OpenDoor(_closeAngle, _duration));
        _isOpen = false;
    }


    public void Interact()
    {
        if (_isOpening == true) // Если дверь открывается, то ничего не делаем
        {
            return;
        }

        if (_isOpen == true) // Если открыта, то закрываем
        {
            Close();
        }
        else //иначе открываем
        {
            Open();
        }
    }


    // Корутина которая принимает угол, на который нужно повернуть и сколько это должно занять времени
    public IEnumerator OpenDoor(float targetRotation, float duration) 
    {
        if (_isOpening)
        {
            yield break; // Если дверь уже открывается, выходим из корутины
        }

        _isOpening = true; // Начали открывать дверь

        float startRotation = transform.eulerAngles.y; // Сохраняем начальное врашение открывать дверь
        float timer = 0; // Создаём таймер

        while (timer < duration)
        {
            float rotation = Mathf.LerpAngle(startRotation, targetRotation, timer / duration);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotation, transform.eulerAngles.z);
            timer += Time.deltaTime;
            yield return null;
        }

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, targetRotation, transform.eulerAngles.z);
        _isOpening = false; // Закончили открывать дверь
    }
}