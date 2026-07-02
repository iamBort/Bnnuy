using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.25f;

    private void Start()
    {
        //Sledov·nÌ objektu hr·Ëe
        target = GameObject.Find("Player1").GetComponent<KeyboardControl>().selectedCharacter.transform;
    }

    void LateUpdate ()
    {
        //P¯i updatu se kamera pohybuje za hr·Ëem
        Vector3 desiredPosition = target.position + offset;
        //smoothSpeed zajiöùuje plynul˝ pohyb kamery - kamera se "t·hne"
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
