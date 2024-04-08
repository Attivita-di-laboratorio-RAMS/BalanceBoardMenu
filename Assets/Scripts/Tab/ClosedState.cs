using UnityEngine;
using UnityEngine.UI;

namespace Tab{
  /******************************************************/
  // CLASS ClosedState IS A CONCRETE IMPLEMENTATION OF STATE
  /******************************************************/
  public class ClosedState : State{
    /***************************************/
    //Methods
    /***************************************/
    public override void Close(){
      //Changing sprite and button dimension
      ((Image)Leaf.GetButton().targetGraphic).sprite=Resources.Load<Sprite>("Sprites/Tab/"+Leaf.GetButton().name+"CLOSED");
      Leaf.GetButton().GetComponent<RectTransform>().sizeDelta=new Vector2(144, 0);
      
      //Hiding panel
      Leaf.GetPanel().SetActive(false);
      
      //Showing the menu line
      Leaf.GetLineHider().SetActive(false);
    }

    public override void Open(){ }
    /***************************************/
  }
}