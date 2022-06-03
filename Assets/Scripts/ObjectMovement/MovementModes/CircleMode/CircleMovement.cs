using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    [SerializeField] private float objectSpeed = 60;
    [SerializeField] private float circleRadius = 3f;
    [SerializeField] private float turns = 3;
    [SerializeField] private bool inverseMovement;
   
    public bool startCircleMovement;
    private float _angles; 
    
    private  void Update ()
    {
        if (!startCircleMovement) return;
        
        if (Mathf.Abs(_angles / 360) >= turns) return;
        
        if (inverseMovement)
        {
            objectSpeed = -objectSpeed;
            inverseMovement = false;
        }
        ObjectCircling();
    }
    
    public void ResetAngles()
    {
        _angles = 0f;
        startCircleMovement = false;
    }
    
    private void ObjectCircling()
    {
        _angles += Time.deltaTime * objectSpeed;

        float x = circleRadius * Mathf.Cos(Mathf.Deg2Rad * _angles);
        float z = circleRadius * Mathf.Sin(Mathf.Deg2Rad * _angles);
        float y = 0;

        var circlePosition = transform.parent.position + new Vector3(x, y, z);
        transform.position = Vector3.Lerp(transform.position, circlePosition, 5f* Time.deltaTime);
    }
}
