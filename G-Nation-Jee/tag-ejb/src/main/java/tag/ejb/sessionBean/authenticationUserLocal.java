package tag.ejb.sessionBean;

import javax.ejb.Local;

import tag.ejb.domain.User;

@Local
public interface authenticationUserLocal {

	
	public User authenticateUser(String username, String password);
	public String getSessionId(User user);
	public User findUserById(int id);
	public User getUserByUserName(String username);
	public String encryptPassword(String passwd);
	public void RecoverPassword(String username);
	public User RecoverAccount(String password);


}
