using UnityEngine;

public class InteractionCamera : MonoBehaviour
{
    [SerializeField] private float _interactionDistance = 20; // Дальность взаимодействия с объектами
    [SerializeField] private Crosshair _crosshair; //Ссылка на прицел
    private Camera _camera;
    

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }
    private void Update()
    {
        Ray ray = new Ray(_camera.transform.position, _camera.transform.forward); //Создаём луч в цетре камеры, который смотрит вперёд
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _interactionDistance)) //Пускаем луч
        {
            // Если объект, в который попал луч, содержит IInteraction, то
            if (hit.collider.TryGetComponent(out IInteraction interactedObject)) 
            {
                _crosshair.ChangeInteract(true); // Меняем крусор на активный
                if (Input.GetMouseButtonDown(0)) // Проверяем нажатие на левую кнопку мыши
                    interactedObject.Interact(); // При нажатии у объекта вызываем метод Interact
            }
            else
            {
                _crosshair.ChangeInteract(false); // Меняем крусор на не активный
            }
        }
        else
        {
            _crosshair.ChangeInteract(false); // Меняем крусор на не активный
        }
    }
}
