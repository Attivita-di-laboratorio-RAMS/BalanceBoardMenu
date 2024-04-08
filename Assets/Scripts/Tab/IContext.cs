namespace Tab{
  /******************************************************/
  // INTERFACE IContext FROM COMPOSITE AND STATE PATTERN
  // DICTATES THE GENERAL STRUCTURE OF EVERY LEAF
  /******************************************************/
  public interface IContext{
    /***************************************/
    //Methods to implement
    /***************************************/
    public void TransitionTo(State state);
    public void OpenTab(IContext context);
    public void CloseTab();
    /***************************************/
  }
}