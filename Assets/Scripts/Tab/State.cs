namespace Tab{
  /******************************************************/
  // ABSTRACT CLASS State FROM STATE PATTERN
  // DICTATES THE GENERAL STRUCTURE OF EVERY STATE
  // THIS PARTICULAR STATE CAN WORK ONLY WITH LEAFS
  /******************************************************/
  public abstract class State{
    /***************************************/
    //Attributes to implement
    /***************************************/
    protected Leaf Leaf;

    /***************************************/
    //Setter
    /***************************************/
    public void SetContext(Leaf leaf){
      Leaf=leaf;
    }

    /***************************************/
    //Methods to implement
    /***************************************/
    public abstract void Close();

    public abstract void Open();
    /***************************************/
  }
}