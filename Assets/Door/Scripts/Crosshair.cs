using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private Sprite _interactSprite; //Спрайт когда игрок навёлся на активный объект
    [SerializeField] private Sprite _nonInteractSprite;//Спрайт когда игрок навёлся на не активный объект
    private Image _image; // Компонент для отрисовки изображения
    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void ChangeInteract(bool isInteract)
    {
        // Если isInteract - true, то устанавливаем спрайт _interactSprite, иначе _nonInteractSprite
        _image.sprite = isInteract == true ? _interactSprite : _nonInteractSprite; 
    }
}
