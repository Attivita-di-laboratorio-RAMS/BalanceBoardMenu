using System.Collections.Generic;

namespace Tab{
  /******************************************************/
  // CLASS Composite FROM COMPOSITE PATTERN 
  /******************************************************/
  public class Composite : IContext{
    /***************************************/
    //Attributes
    /***************************************/
    private readonly List<IContext> _children=new ();
    /***************************************/
    //Methods
    /***************************************/
    public void Add(IContext context){
      _children.Add(context);
    }

    public void TransitionTo(State state){ }

    public void OpenTab(IContext context){
      CloseTab();
      context.TransitionTo(new OpenedState());
      context.OpenTab(context);
    }

    public void CloseTab(){
      foreach(var context in _children){
        context.TransitionTo(new ClosedState());
        context.CloseTab();
      }//end-foreach
    }
    /***************************************/
  }
}