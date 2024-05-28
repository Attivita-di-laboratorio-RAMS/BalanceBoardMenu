namespace AccountSettings{
  /******************************************************/
  // CLASS ConcreteMemento IS A CONCRETE IMPLEMENTATION
  // OF IMemento
  /******************************************************/
  public class ConcreteMemento : IMemento{
    /***************************************/
    //Attributes
    /***************************************/
    private AccountSettingsSerializable _accountSettingsSerializable;

    /***************************************/
    //Constructor
    /***************************************/
    public ConcreteMemento(AccountSettings accountSettings){
      _accountSettingsSerializable=new AccountSettingsSerializable(accountSettings);
    }

    /***************************************/
    //Methods
    /***************************************/
    public AccountSettingsSerializable GetAccountSettings(){
      return _accountSettingsSerializable;
    }
    /***************************************/
  }
}