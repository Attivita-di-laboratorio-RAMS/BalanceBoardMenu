using System;
using UnityEngine;

public class UpdatePosition : MonoBehaviour{
    [SerializeField] private Animator _avatarAnimator;
  
    
    // Start is called before the first frame update
    void Start(){
      foreach (HumanBodyBones bone in (HumanBodyBones[]) Enum.GetValues(typeof(HumanBodyBones))){
        print(_avatarAnimator.GetBoneTransform(bone));
      }
    }

    // Update is called once per frame
    void Update(){
      //Transform t=_avatarAnimator.GetBoneTransform(HumanBodyBones.Head);
      //print(t);
    }
}
