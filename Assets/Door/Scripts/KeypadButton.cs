using UnityEngine;
using UnityEngine.Events;

public class KeypadButton : MonoBehaviour, IInteraction
{
    public UnityEvent<string> ClickToButtonEvent = new(); //События нажатия на кнопку, которое передаёт текст

    [SerializeField] private string _keyValue; //Символ на кнопке

    public void Interact()
    {
        ClickToButtonEvent?.Invoke(_keyValue); // Вызвать у всех подписчиков метод подписанный событие и передать текст
    }
}
