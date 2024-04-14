using UnityEngine;

public class Keypad : MonoBehaviour
{
    [SerializeField] private DoorController _door; // Ссылка на дверь
    [SerializeField] private string _code; //Код замка
    [SerializeField] private string _inputCode; //Код который ввёл игрок

    [SerializeField] private AudioClip _clickToButtonSound; // Звук нажатия на кнопку
    [SerializeField] private AudioClip _correctPasswordSound; // Звук правильного ввода пароля

    private KeypadButton[] _buttons; // Массив с кнопками
    private AudioSource _audioSource; //Ссылка на источник звука
    private bool _isAcitveKeypad = true; //Можно ли взаимодействовать с кейпадом
    void Start()
    {
        // Берём у всех дочерних объектов компонент KeypadButton и помещаем в массив _buttons
        _buttons = transform.GetComponentsInChildren<KeypadButton>();
        //Берём компонент AudioSource и помещаем в  _audioSource
        _audioSource = GetComponent<AudioSource>();

        foreach (KeypadButton button in _buttons) //Обходим массив _buttons
        {
            //К событию ClickToButtonEvent каждой кнопки прикрепляем метод OnClickToButton
            button.ClickToButtonEvent.AddListener(OnClickToButton);
        }
    }

    private void OnClickToButton(string keyValue) // Метод при нажатии на кнопку
    {
        if (_isAcitveKeypad == false) // Если кейпад не активный, то ничего не делать
            return;

        PlayClickToButtonSound(); 
        CheckKeyValue(keyValue);
    }

    private void TryOpen()
    {
        if (_inputCode == _code) // Если код совпадает с ведённым
        {
            _door.Open();
            _isAcitveKeypad = false; // Диактивировать кейпад
            PlayСorrectPasswordSound();
        }
        else // Если не правильный код
        {
            _inputCode = ""; //Очистить вводимый пароль
        }
    }

    private void PlayClickToButtonSound() //Проиграть звук нажатия на кнопку
    {
        _audioSource.PlayOneShot(_clickToButtonSound);
    }    
    
    private void PlayСorrectPasswordSound() //Проиграть звук правильного ввода
    {
        _audioSource.PlayOneShot(_correctPasswordSound);
    }

    private void CheckKeyValue(string keyValue) //Проверить значение нажатой кнопки
    {
        if (keyValue == "C") //Если на кнопке C
            _inputCode = ""; // Очищаем пароль
        else if (keyValue == "O") // Если на кнопке O
            TryOpen(); //Пытаемся открыть
        else
            _inputCode += keyValue; //Иначе значение на кнопке добавляем к коду
    }
}
