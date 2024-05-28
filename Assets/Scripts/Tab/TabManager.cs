using UnityEngine;

namespace Tab{
  /******************************************************/
  // CLASS TabManager ACTS AS THE CLIENT.
  // HANDLES ALL THE BUTTONS CLICKING EVENT TRIGGERING
  // STATE CHANGES VIA COMPOSITE
  /******************************************************/
  public class TabManager : MonoBehaviour{
    /***************************************/
    //SerializedFields
    /***************************************/
    [Header("General manager for tab navigation,\n\nEach element MUST contain an instance of:\n1. Button (the actual Tab)\n2. Panel corresponding to the Tab\n3. LineHider")] [SerializeField]
    private Leaf[] contexts;

    /***************************************/
    //Attributes
    /***************************************/
    private static readonly Composite Composite=new();

    /***************************************/
    //Methods
    /***************************************/
    private void Awake(){
      foreach(var leaf in contexts){
        Composite.Add(leaf);

        leaf.GetButton().onClick.AddListener(() => {Composite.OpenTab(leaf);});
      } //end-foreach
    }
    /***************************************/
  }
}