using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.InputSystem;

public class PlayerFormChange : MonoBehaviour
{
    //--------------------References---------------------------//
    
    #region Childern_Gameobject_Reference

    [SerializeField] private GameObject leftHand; 
    [SerializeField] private GameObject rightHand;
    [SerializeField] private GameObject leftEye;
    [SerializeField] private GameObject rightEye;
    [SerializeField] private GameObject faceBg;
    [SerializeField] private GameObject Body;

    #endregion
    
    #region SpriteRenderer_References

    private SpriteRenderer _leftHandSpriteRenderer;
    private SpriteRenderer _rightHandSpriteRenderer;
    private SpriteRenderer _leftEyeSpriteRenderer;
    private SpriteRenderer _rightEyeSpriteRenderer;
    private SpriteRenderer _faceBgSpriteRenderer;
    private SpriteRenderer _bodySpriteRenderer;

    #endregion
    
    #region Scriptable_Objects_References------Player_Forms
    
    [SerializeField] private PlayerForm defaultPlayerForm;
    [FormerlySerializedAs("bluePlayerForm")] [SerializeField] private PlayerForm xPlayerForm;
    [FormerlySerializedAs("redPlayerForm")] [SerializeField] private PlayerForm yPlayerForm;

    #endregion

    #region TagState_Objects_Reference

    [SerializeField] private GameObject _stateOneCollider;
    [SerializeField] private GameObject _stateSecondCollider;

    #endregion
    
    // Main scriptable objects that is responsible for changing player sprites.
    private PlayerForm _playerForm;
    
    private Vector3 _origionalPos;
    private Quaternion _origionalRotation;

    private void Start()
    {
        _playerForm = defaultPlayerForm;
        _stateOneCollider.SetActive(false);
        _stateSecondCollider.SetActive(false); // Call this once at start.
        
        // default reference of player scriptable object
        _playerForm = defaultPlayerForm; 
        
        #region CachedElemets

        _leftHandSpriteRenderer = leftHand.GetComponent<SpriteRenderer>();
        _rightHandSpriteRenderer = rightHand.GetComponent<SpriteRenderer>();
        _rightEyeSpriteRenderer = rightEye.GetComponent<SpriteRenderer>();
        _leftEyeSpriteRenderer = leftEye.GetComponent<SpriteRenderer>();
        _faceBgSpriteRenderer = faceBg.GetComponent<SpriteRenderer>();
        _bodySpriteRenderer = Body.GetComponent<SpriteRenderer>();

        #endregion

        // setting the values on Start
        _origionalPos = transform.position;
        _origionalRotation = Quaternion.identity;

    }

    private void Update()
    {
        ChangingSpritesWithScriptableGameObjects();
        DefaultState();
    }

    private void ChangingSpritesWithScriptableGameObjects()
    {
        _leftHandSpriteRenderer.sprite = _playerForm.LeftHand;
        _rightHandSpriteRenderer.sprite = _playerForm.RightHand;
        _rightEyeSpriteRenderer.sprite = _playerForm.RightEye;
        _leftEyeSpriteRenderer.sprite = _playerForm.LeftEye;
        _faceBgSpriteRenderer.sprite = _playerForm.FaceBg;
        _bodySpriteRenderer.sprite = _playerForm.Body;
    }

    private bool _buttonXPressed;
    private bool _buttonYPressed;
    
    public void SetYState(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _playerForm = yPlayerForm;
            _stateOneCollider.SetActive(false);
            _stateSecondCollider.SetActive(true);
            _buttonYPressed = true;
        }
        else if (context.canceled)
        {
            _buttonYPressed = false;
        }
        

    }

    public void SetXState(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _playerForm = xPlayerForm;
            _stateOneCollider.SetActive(true);
            _stateSecondCollider.SetActive(false);
            _buttonXPressed = true;    
        }
        else if (context.canceled)
        {
            _buttonXPressed = false;
        }
    }

    private void DefaultState()
    {
        if (!_buttonXPressed && !_buttonYPressed)
        {
            _playerForm = defaultPlayerForm;
            _stateOneCollider.SetActive(false);
            _stateSecondCollider.SetActive(false);    
        }
        
    }

    public void SetPlayerPos()
    {
        transform.position = _origionalPos;
        transform.rotation = _origionalRotation;
    }
}
