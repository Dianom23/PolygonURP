using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private Sprite _interactSprite; //������ ����� ����� ������ �� �������� ������
    [SerializeField] private Sprite _nonInteractSprite;//������ ����� ����� ������ �� �� �������� ������
    private Image _image; // ��������� ��� ��������� �����������
    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void ChangeInteract(bool isInteract)
    {
        // ���� isInteract - true, �� ������������� ������ _interactSprite, ����� _nonInteractSprite
        _image.sprite = isInteract == true ? _interactSprite : _nonInteractSprite; 
    }
}
