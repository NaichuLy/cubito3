using UnityEngine;

public class PlayerSlidingInteraction : MonoBehaviour
{
    public float interactDistance = 2f;
    public LayerMask cubesLayer;  // Asegurate de que esté configurado a "Cubes" en el Inspector

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(transform.position + Vector3.up * 0.5f, transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, cubesLayer))
            {
                IceCube iceCube = hit.collider.GetComponent<IceCube>();
                if (iceCube != null)
                {
                    Vector3 pushDirection = transform.forward;
                    iceCube.Slide(pushDirection);
                }
            }
        }
    }
}


