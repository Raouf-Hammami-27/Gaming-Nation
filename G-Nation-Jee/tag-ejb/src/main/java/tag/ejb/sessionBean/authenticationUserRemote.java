package tag.ejb.sessionBean;

import javax.ejb.Remote;

import tag.ejb.domain.User;

@Remote
public interface authenticationUserRemote {
	
	public User authenticateUser(String username, String password);
	public String getSessionId(User user);
	public User findUserById(int id);
	public User getUserByUserName(String username);
	public String encryptPassword(String passwd);
	public void RecoverPassword(String username);
	public User RecoverAccount(String password);

}
