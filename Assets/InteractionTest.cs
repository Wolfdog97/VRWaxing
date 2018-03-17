using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
    //-------------------------------------------------------------------------
    [RequireComponent(typeof(Interactable))]
    public class InteractionTest : MonoBehaviour
    {
        private TextMesh textMesh;
        private Vector3 oldPosition;
        private Quaternion oldRotation;

        private BoxCollider stripCol;

        private float attachTime;

        private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers);

        public bool canBeDetached = true;
        public GameObject hair;

        Hand _hand;

        //-------------------------------------------------
        void Awake()
        {
            textMesh = GetComponentInChildren<TextMesh>();
            //textMesh.text = "No Hand Hovering";

            
        }

        private void Start()
        {
            _hand = GameObject.Find("FallbackHand").GetComponent<Hand>();
            print(_hand);

            stripCol = GetComponent<BoxCollider>();
        }


        //-------------------------------------------------
        // Called when a Hand starts hovering over this object
        //-------------------------------------------------
        private void OnHandHoverBegin(Hand hand)
        {
            //textMesh.text = "Hovering hand: " + hand.name;
        }


        //-------------------------------------------------
        // Called when a Hand stops hovering over this object
        //-------------------------------------------------
        private void OnHandHoverEnd(Hand hand)
        {
            //textMesh.text = "No Hand Hovering";
        }


        //-------------------------------------------------
        // Called every Update() while a Hand is hovering over this object
        //-------------------------------------------------
        private void HandHoverUpdate(Hand hand)
        {
            if (hand.GetStandardInteractionButtonDown() || ((hand.controller != null) && hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip)))
            {
                if (hand.currentAttachedObject != gameObject)
                {
                    // Save our position/rotation so that we can restore it when we detach
                     //oldPosition = transform.position;
                     //oldRotation = transform.rotation;

                    // Call this to continue receiving HandHoverUpdate messages,
                    // and prevent the hand from hovering over anything else
                    hand.HoverLock(GetComponent<Interactable>());

                    // Attach this object to the hand
                    hand.AttachObject(gameObject, attachmentFlags);
                }
                else
                {
                    // Detach this object from the hand
                    hand.DetachObject(gameObject);

                    // Call this to undo HoverLock
                    hand.HoverUnlock(GetComponent<Interactable>());

                    // Restore position/rotation
                    //transform.position = oldPosition;
                    //transform.rotation = oldRotation;
                }
            }
        }


        //-------------------------------------------------
        // Called when this GameObject becomes attached to the hand
        //-------------------------------------------------
        private void OnAttachedToHand(Hand hand)
        {
            //textMesh.text = "Attached to hand: " + hand.name;
            attachTime = Time.time;
        }


        //-------------------------------------------------
        // Called when this GameObject is detached from the hand
        //-------------------------------------------------
        private void OnDetachedFromHand(Hand hand)
        {
           // textMesh.text = "Detached from hand: " + hand.name;
        }


        //-------------------------------------------------
        // Called every Update() while this GameObject is attached to the hand
        //-------------------------------------------------
        private void HandAttachedUpdate(Hand hand)
        {
            //textMesh.text = "Attached to hand: " + hand.name + "\nAttached time: " + (Time.time - attachTime).ToString("F2");
        }


        //-------------------------------------------------
        // Called when this attached GameObject becomes the primary attached object
        //-------------------------------------------------
        private void OnHandFocusAcquired(Hand hand)
        {
        }


        //-------------------------------------------------
        // Called when another attached GameObject becomes the primary attached object
        //-------------------------------------------------
        private void OnHandFocusLost(Hand hand)
        {
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("OnTriggerEnter is working");
           

            if (other.gameObject.GetComponent<Body>() != null)
            {
                Debug.Log("GetComponent<Body> is working");
                if (other.gameObject.GetComponent<Body>().isWaxable != false && canBeDetached != false)
                {
                    _hand.DetachObject(gameObject);
                    canBeDetached = false;
                    stripCol.enabled = !enabled;
                    Debug.Log("this is working");
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(canBeDetached != true)
            {
                //stripCol.enabled = enabled;
                canBeDetached = true;
                hair.SetActive(false);

            }
        }
    }
}
