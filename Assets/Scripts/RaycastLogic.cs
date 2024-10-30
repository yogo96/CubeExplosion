using UnityEngine;

public class RaycastLogic : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) == false)
        {
            return;
        }

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(transform.position, ray.direction, out RaycastHit hitInfo))
        {
            if (hitInfo.collider.TryGetComponent<Cube>(out Cube cube))
            {
                cube.Divide();
            }
        }
    }
}