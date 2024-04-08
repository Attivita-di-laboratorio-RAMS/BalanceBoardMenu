using UnityEngine;
using UnityEngine.UI;

namespace Tab{
  /******************************************************/
  // CLASS Leaf IS A CONCRETE IMPLEMENTATION OF IContext
  /******************************************************/
  [System.Serializable]
  public class Leaf : IContext{
    /***************************************/
    //SerializedFields
    /***************************************/
    [SerializeField] private Button button;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject lineHider;
    /***************************************/
    //Attributes
    /***************************************/
    private State _state=null;  //Instance of the current state the leaf is in
    /***************************************/
    //Constructor
    /***************************************/
    public Leaf(Button button, GameObject panel, GameObject lineHider){
      this.button=button;
      this.panel=panel;
      this.lineHider=lineHider;
      TransitionTo(new ClosedState());
    }
    /***************************************/
    //Getter/Setter
    /***************************************/
    public Button GetButton(){
      return button;
    }

    public GameObject GetPanel(){
      return panel;
    }

    public GameObject GetLineHider(){
      return lineHider;
    }
    /***************************************/
    //Methods
    /***************************************/
    //Method for transitioning to another state
    public void TransitionTo(State state){
      _state=state;
      _state.SetContext(this);
    }
    
    public void OpenTab(IContext context){
      _state.Open();
    }

    public void CloseTab(){
      _state.Close();
    }
    /***************************************/
  }
}