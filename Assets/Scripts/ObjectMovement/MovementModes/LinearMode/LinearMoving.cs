using System.Collections.Generic;
using ObjectMovement;
using UnityEngine;

public class LinearMoving : GameModeBase
{
    [SerializeField] private GameObject pointPrefab;
    [SerializeField]private float speed = 5f;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private Vector3 direction;
    private bool isListeningInput;
    private bool objectIsMoving;
    
    private bool startPointSet;
    private bool targetPointSet;
    
    private Camera _camera;

    private List<GameObject> CreatedControlPoins = new List<GameObject>();
    
    private void Start()
    {
        _camera = Camera.main;
    }
    
    private void Update()
    {
        if (modeIsActive == false) return;
            
        if (isListeningInput)
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit))
                {
                    if (startPointSet == false)
                    {
                        startPosition = new Vector3(hit.point.x, 0, hit.point.z);
                        SpawnControlPoint(startPosition);
                        startPointSet = true;
                    }
                    else if (targetPointSet == false)
                    {
                        targetPosition = new Vector3(hit.point.x, 0, hit.point.z);
                        SpawnControlPoint(targetPosition);
                        objectIsMoving = true;
                        transform.position = startPosition;
                        direction = (targetPosition - startPosition).normalized;
                    
                        startPointSet = targetPointSet = false;
                    }
                }
            }
        }
        if (objectIsMoving)
        {
            if (Vector3.Distance(transform.position, targetPosition) <= 0.1f)
            {
                objectIsMoving = false;
                ClearControlPoints();
            }
            transform.position += direction * (speed * Time.deltaTime);
        }
    }
    
    public override void ActivateGameMode(bool active)
    {
        base.ActivateGameMode(active);
        isListeningInput = active;
        ClearControlPoints();
        startPointSet = targetPointSet = false;
        startPosition = targetPosition = direction = Vector3.zero;
    }

    private void ClearControlPoints()
    {
        for (int i = 0; i < CreatedControlPoins.Count; i++)
        {
            Destroy(CreatedControlPoins[i]);
        }
        CreatedControlPoins.Clear();
    }

    private void SpawnControlPoint(Vector3 point)
    {
       var pointObject =  Instantiate(pointPrefab, point, Quaternion.identity);
       CreatedControlPoins.Add(pointObject);
    }
}
