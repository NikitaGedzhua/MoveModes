using ObjectMovement;
using UnityEngine;

public class CirclingPoint : GameModeBase
{
    [SerializeField] private CircleMovement circleMovement;
    [SerializeField] private GameObject player;
    [SerializeField] private float movementDuration = 2f;
    
    private Vector3 _newPosition;
    private Vector3 _startPosition;
    private Camera _camera;
    
    private bool _isMoving;
    private bool _setPoint;
    private float _startMovingTime;
    
   private void Start ()
    {
        _camera = Camera.main;
    }
   private void Update()
    {
        if (modeIsActive == false) return;
        if (_setPoint)
        {
            MoveAndCircling(); 
        }
    }
   
   public override void ActivateGameMode(bool active)
   {
       base.ActivateGameMode(active);
       _setPoint = active;
       circleMovement.ResetAngles();
   }

   private void MoveAndCircling()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                _newPosition = new Vector3(hit.point.x,0,hit.point.z);
                _startPosition = player.transform.position;
                _startMovingTime = Time.time;
                _isMoving = true;
            }
        }
        
        float t = (Time.time - _startMovingTime) / movementDuration;
        
        if (t >= 1 && _isMoving)
        {
            t = 1;
            _isMoving = false;
            circleMovement.startCircleMovement = true;
            _setPoint = false;
        }
        
        if (_isMoving)
        {
            player.transform.position = Vector3.Lerp(_startPosition, _newPosition, t);
        }
    }
}

