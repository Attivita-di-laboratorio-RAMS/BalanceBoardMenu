namespace AccountSettings{
  /******************************************************/
  // INTERFACE IMemento FROM MEMENTO PATTERN
  // DICTATES THE GENERAL STRUCTURE OF CONCRETE MEMENTO
  /******************************************************/
  public interface IMemento{
    /***************************************/
    //Methods to implement
    /***************************************/
    AccountSettingsSerializable GetAccountSettings();
    /***************************************/
  }
}