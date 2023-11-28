using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPickup : MonoBehaviour
{
    [SerializeField] private LayerMask PickUpMask;
    [SerializeField] private LayerMask KeyMask;
    [SerializeField] private LayerMask Sign1Mask;
    [SerializeField] private LayerMask Sign2Mask;
    [SerializeField] private LayerMask Sign3Mask;
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private Transform PickupTarget;
    [SerializeField] private float PickupRange;
    [SerializeField] private CanvasGroup PuzzleSignGroup1;
    [SerializeField] private CanvasGroup PuzzleSignGroup2;
    [SerializeField] private CanvasGroup PuzzleSignGroup3;
    private Rigidbody CurrentObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(CurrentObject)
            {
                CurrentObject.useGravity = true;
                CurrentObject = null;
                return;
            }

            Ray CameraRay = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(CameraRay, out RaycastHit HitInfo2, PickupRange, KeyMask))
            {
                CurrentObject = HitInfo2.rigidbody;
                CurrentObject.useGravity = false;
            }
            if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickupRange, PickUpMask))
            {
                CurrentObject = HitInfo.rigidbody;
                CurrentObject.useGravity = false;
            }
            if (Physics.Raycast(CameraRay, out RaycastHit HitInfo3, PickupRange, Sign1Mask))
            {
                PuzzleSignGroup1.interactable = true;
                PuzzleSignGroup1.blocksRaycasts = true;
                PuzzleSignGroup1.alpha = 1f;
            }
            if (Physics.Raycast(CameraRay, out RaycastHit HitInfo4, PickupRange, Sign2Mask))
            {
                PuzzleSignGroup2.interactable = true;
                PuzzleSignGroup2.blocksRaycasts = true;
                PuzzleSignGroup2.alpha = 1f;
            }
            if (Physics.Raycast(CameraRay, out RaycastHit HitInfo5, PickupRange, Sign3Mask))
            {
                PuzzleSignGroup3.interactable = true;
                PuzzleSignGroup3.blocksRaycasts = true;
                PuzzleSignGroup3.alpha = 1f;
            }
        }
    }

    void FixedUpdate()
    {
        if(CurrentObject)
        {
            Vector3 DirectionToPoint = PickupTarget.position - CurrentObject.position;
            float DistanceToPoint = DirectionToPoint.magnitude;

            CurrentObject.velocity = DirectionToPoint * 12f * DistanceToPoint;
        }
    }

}
