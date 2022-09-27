using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStateData", menuName = "ScriptableObjects/PlayerForm", order = 1)]
public class PlayerForm : ScriptableObject
{
    public Sprite LeftHand;
    public Sprite RightHand;
    public Sprite LeftEye;
    public Sprite RightEye;
    public Sprite FaceBg;
    public Sprite Body;
    
}
