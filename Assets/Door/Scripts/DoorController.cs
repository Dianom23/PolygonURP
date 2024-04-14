using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour, IInteraction
{
    [SerializeField] private float _openAngle = 90; // ���� �������� �����
    [SerializeField] private float _closeAngle = 0; // ���� �������� �����
    [SerializeField] private float _duration = 1; // ���� �������� �����
    [SerializeField] private bool _isInteractable = true; //����� �� ����������������� � ������

    private bool _isOpen = false; // ���� ��� ������������ ��������� �����
    private bool _isOpening = false; // ���� ��� ������������ ����������� �� �����

    private void Start()
    {
        if (_isInteractable == false) //���� ������ ����������������� � ������ 
        {
            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast"); //�������� ���� �������, �� ������������ ����
        }

        Cursor.lockState = CursorLockMode.Locked; // ��������� � �������� ������
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
        if (_isOpening == true) // ���� ����� �����������, �� ������ �� ������
        {
            return;
        }

        if (_isOpen == true) // ���� �������, �� ���������
        {
            Close();
        }
        else //����� ���������
        {
            Open();
        }
    }


    // �������� ������� ��������� ����, �� ������� ����� ��������� � ������� ��� ������ ������ �������
    public IEnumerator OpenDoor(float targetRotation, float duration) 
    {
        if (_isOpening)
        {
            yield break; // ���� ����� ��� �����������, ������� �� ��������
        }

        _isOpening = true; // ������ ��������� �����

        float startRotation = transform.eulerAngles.y; // ��������� ��������� �������� ��������� �����
        float timer = 0; // ������ ������

        while (timer < duration)
        {
            float rotation = Mathf.LerpAngle(startRotation, targetRotation, timer / duration);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotation, transform.eulerAngles.z);
            timer += Time.deltaTime;
            yield return null;
        }

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, targetRotation, transform.eulerAngles.z);
        _isOpening = false; // ��������� ��������� �����
    }
}