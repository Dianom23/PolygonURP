using UnityEngine;

public class Keypad : MonoBehaviour
{
    [SerializeField] private DoorController _door; // ������ �� �����
    [SerializeField] private string _code; //��� �����
    [SerializeField] private string _inputCode; //��� ������� ��� �����

    [SerializeField] private AudioClip _clickToButtonSound; // ���� ������� �� ������
    [SerializeField] private AudioClip _correctPasswordSound; // ���� ����������� ����� ������

    private KeypadButton[] _buttons; // ������ � ��������
    private AudioSource _audioSource; //������ �� �������� �����
    private bool _isAcitveKeypad = true; //����� �� ����������������� � ��������
    void Start()
    {
        // ���� � ���� �������� �������� ��������� KeypadButton � �������� � ������ _buttons
        _buttons = transform.GetComponentsInChildren<KeypadButton>();
        //���� ��������� AudioSource � �������� �  _audioSource
        _audioSource = GetComponent<AudioSource>();

        foreach (KeypadButton button in _buttons) //������� ������ _buttons
        {
            //� ������� ClickToButtonEvent ������ ������ ����������� ����� OnClickToButton
            button.ClickToButtonEvent.AddListener(OnClickToButton);
        }
    }

    private void OnClickToButton(string keyValue) // ����� ��� ������� �� ������
    {
        if (_isAcitveKeypad == false) // ���� ������ �� ��������, �� ������ �� ������
            return;

        PlayClickToButtonSound(); 
        CheckKeyValue(keyValue);
    }

    private void TryOpen()
    {
        if (_inputCode == _code) // ���� ��� ��������� � �������
        {
            _door.Open();
            _isAcitveKeypad = false; // �������������� ������
            Play�orrectPasswordSound();
        }
        else // ���� �� ���������� ���
        {
            _inputCode = ""; //�������� �������� ������
        }
    }

    private void PlayClickToButtonSound() //��������� ���� ������� �� ������
    {
        _audioSource.PlayOneShot(_clickToButtonSound);
    }    
    
    private void Play�orrectPasswordSound() //��������� ���� ����������� �����
    {
        _audioSource.PlayOneShot(_correctPasswordSound);
    }

    private void CheckKeyValue(string keyValue) //��������� �������� ������� ������
    {
        if (keyValue == "C") //���� �� ������ C
            _inputCode = ""; // ������� ������
        else if (keyValue == "O") // ���� �� ������ O
            TryOpen(); //�������� �������
        else
            _inputCode += keyValue; //����� �������� �� ������ ��������� � ����
    }
}
