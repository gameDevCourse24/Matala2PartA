using UnityEngine;

public class rotator : MonoBehaviour
{
    public float speedX = 30f;
    public float speedY = 30f;
    public float speedZ = 30f;
    
    [Header("Rotation Axes")]
    public bool rotateX = true;
    public bool rotateY = true;
    public bool rotateZ = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          transform.Rotate(
             rotateX ? speedX * Time.deltaTime : 0f,
            rotateY ? speedY * Time.deltaTime : 0f,
            rotateZ ? speedZ * Time.deltaTime : 0f
        );
    }
}
