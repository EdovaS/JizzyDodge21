using DG.Tweening; 
using UnityEngine;  
public class DieTweenPlayer : MonoBehaviour 
{
    [SerializeField] private Transform[] _flyTransform;
    public void PlayerDieEffect()
    {
        Vector3 rotation = new Vector3(transform.rotation.x, transform.rotation.y, 1000);    
        
<<<<<<< HEAD
        transform.DORotate(rotation, 1f, RotateMode.FastBeyond360);         
        int randomMovePos = Random.Range(0, 4);         
        transform.DOMove(_flyTransform[randomMovePos].position, 1f);
=======
        transform.DORotate(rotation, 0.5f, RotateMode.FastBeyond360);         
        int randomMovePos = Random.Range(0, 4);         
        transform.DOMove(_flyTransform[randomMovePos].position, 0.5f);
>>>>>>> YodoBuild+Revie
    }      
}