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

        Ray _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(transform.position, _ray.direction, out RaycastHit hitInfo))
        {
            if (hitInfo.collider.TryGetComponent<Cube>(out Cube cube))
            {
                cube.Explode();
            }
        }
    }
}