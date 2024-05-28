using System.Collections.Generic;
using System.Linq;

namespace AccountSettings{
  /******************************************************/
  // CLASS AccountSettingsCaretaker IS THE CARETAKER
  // FROM MEMENTO PATTERN
  /******************************************************/
  public class AccountSettingsCaretaker{
    /***************************************/
    //Attributes
    /***************************************/
    private List<IMemento> _mementos=new();

    private AccountSettings _accountSettings=null;

    /***************************************/
    //Constructor
    /***************************************/
    public AccountSettingsCaretaker(AccountSettings accountSettings){
      _accountSettings=accountSettings;
    }

    /***************************************/
    //Methods
    /***************************************/
    public void Backup(){
      _mementos.Add(_accountSettings.Save());
    }

    public IMemento GetLastMemento(){
      return _mementos.Last();
    }
    /***************************************/
  }
}