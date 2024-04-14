using UnityEngine;
using UnityEngine.Events;

public class KeypadButton : MonoBehaviour, IInteraction
{
    public UnityEvent<string> ClickToButtonEvent = new(); //������� ������� �� ������, ������� ������� �����

    [SerializeField] private string _keyValue; //������ �� ������

    public void Interact()
    {
        ClickToButtonEvent?.Invoke(_keyValue); // ������� � ���� ����������� ����� ����������� ������� � �������� �����
    }
}
