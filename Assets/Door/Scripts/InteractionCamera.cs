using UnityEngine;

public class InteractionCamera : MonoBehaviour
{
    [SerializeField] private float _interactionDistance = 20; // ��������� �������������� � ���������
    [SerializeField] private Crosshair _crosshair; //������ �� ������
    private Camera _camera;
    

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }
    private void Update()
    {
        Ray ray = new Ray(_camera.transform.position, _camera.transform.forward); //������ ��� � ����� ������, ������� ������� �����
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _interactionDistance)) //������� ���
        {
            // ���� ������, � ������� ����� ���, �������� IInteraction, ��
            if (hit.collider.TryGetComponent(out IInteraction interactedObject)) 
            {
                _crosshair.ChangeInteract(true); // ������ ������ �� ��������
                if (Input.GetMouseButtonDown(0)) // ��������� ������� �� ����� ������ ����
                    interactedObject.Interact(); // ��� ������� � ������� �������� ����� Interact
            }
            else
            {
                _crosshair.ChangeInteract(false); // ������ ������ �� �� ��������
            }
        }
        else
        {
            _crosshair.ChangeInteract(false); // ������ ������ �� �� ��������
        }
    }
}
