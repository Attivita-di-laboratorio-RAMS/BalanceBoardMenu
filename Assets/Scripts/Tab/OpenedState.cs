using UnityEngine;
using UnityEngine.UI;

namespace Tab{
  /******************************************************/
  // CLASS OpenedState IS A CONCRETE IMPLEMENTATION OF STATE
  /******************************************************/
  public class OpenedState : State{
    /***************************************/
    //Methods
    /***************************************/
    public override void Close(){ }

    public override void Open(){
      //Changing sprite and button dimensione
      ((Image)Leaf.GetButton().targetGraphic).sprite=Resources.Load<Sprite>("Sprites/Tab/" + Leaf.GetButton().name + "OPENED");
      Leaf.GetButton().GetComponent<RectTransform>().sizeDelta=new Vector2(360, 0);

      //Showing panel
      Leaf.GetPanel().SetActive(true);

      //Hiding menu line
      Leaf.GetLineHider().SetActive(true);
    }
    /***************************************/
  }
}