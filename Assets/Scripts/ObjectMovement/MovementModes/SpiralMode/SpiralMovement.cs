using ObjectMovement;
using UnityEngine;

public class SpiralMovement : GameModeBase
{
    [SerializeField] private float angularSpeed = 60; 
    [SerializeField] private float spiralPitch = 0.3f; 
    [SerializeField] private float turns = 5;
    [SerializeField] private bool inverseMovement; 
    private bool _startSpiralMovement;
    
    [SerializeField] private float _angles;
    [SerializeField] private float _radius;
    
    private void FixedUpdate()
    {
        if (modeIsActive == false) return;
        if (!_startSpiralMovement) return;
        
        if (Mathf.Abs(_angles / 360) > turns) return;
        
        ObjectSpiraling();
    }
    
    public override void ActivateGameMode(bool active)
    {
        base.ActivateGameMode(active);
        _startSpiralMovement = active;
        transform.parent.position = transform.position;
        transform.localPosition = Vector3.zero;
        if (inverseMovement)
        {
            _angles = turns * 360;
            _radius = turns * spiralPitch / 0.28f;
            angularSpeed = -angularSpeed;
            spiralPitch = -spiralPitch;
        }
        else
        {
            _angles = 0;
            _radius = 0;
        }
    }

    public void SwitchDirection()
    {
        angularSpeed = -angularSpeed;
        spiralPitch = -spiralPitch;
        _angles *= 0.99f;
        inverseMovement = !inverseMovement;
    }
    
    private void ObjectSpiraling()
    {
        _angles += Time.fixedDeltaTime * angularSpeed;
        _radius += Time.fixedDeltaTime * spiralPitch ;
        
        float x = _radius * Mathf.Cos(Mathf.Deg2Rad * _angles);
        float z = _radius * Mathf.Sin(Mathf.Deg2Rad * _angles);
        float y = 0;

        transform.position = transform.parent.position + new Vector3(x, y, z);
    }
    
}



