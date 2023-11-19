using UnityEngine;

public class RotateAndZoom_3 : MonoBehaviour
{
    public GameObject targetObject;
    public float rotateSpeed = 10.0f; 
    public float zoomSpeed = 5.0f;

    private Vector2 touchStartPosition1;
    private Vector2 touchStartPosition2; 

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPosition1 = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                float touchDelta = touch.position.x - touchStartPosition1.x;

                targetObject.transform.Rotate(Vector3.up, touchDelta * rotateSpeed * Time.deltaTime);

                touchStartPosition1 = touch.position;
            }
        }

        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            Vector2 touchPosition1 = touch1.position;
            Vector2 touchPosition2 = touch2.position;

            float initialDistance = Vector2.Distance(touchPosition1, touchPosition2);

            float currentDistance = Vector2.Distance(touchPosition1, touchPosition2);

            float zoomFactor = Mathf.Abs(currentDistance - initialDistance) * zoomSpeed * Time.deltaTime;

            Camera mainCamera = Camera.main;
            if (mainCamera != null)
            {
                mainCamera.fieldOfView += zoomFactor;

                mainCamera.fieldOfView = Mathf.Clamp(mainCamera.fieldOfView, 10.0f, 90.0f);
            }
        }
    }
}