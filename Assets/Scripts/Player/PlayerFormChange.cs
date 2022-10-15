using System;
using UnityEngine;
using UnityEngine.Serialization;

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

    private void Start()
    {
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
        
    }

    private void Update()
    {
        ChangingSpritesWithScriptableGameObjects();
        // PlayerInput();
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
    /*private void PlayerInput()
    {
        if (!Input.GetKey(KeyCode.A) || !Input.GetKey(KeyCode.D))
        {
            DefaultState();
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            SetXState();
        }

        if (Input.GetKey(KeyCode.D))
        {
            SetYState();
        }
        
    }*/

    public void SetYState()
    {
        _playerForm = yPlayerForm;
        _stateOneCollider.SetActive(false);
        _stateSecondCollider.SetActive(true);
    }

    public void SetXState()
    {
        _playerForm = xPlayerForm;
        _stateOneCollider.SetActive(true);
        _stateSecondCollider.SetActive(false);
    }

    public void DefaultState()
    {
        _playerForm = defaultPlayerForm;
        _stateOneCollider.SetActive(false);
        _stateSecondCollider.SetActive(false);
    }
}
