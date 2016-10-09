package tag.ejb.sessionBean;

import java.util.List;

import javax.ejb.Local;

import tag.ejb.domain.Member;
import tag.ejb.domain.User;

@Local
public interface registrationUserLocal {
	public String Registrate(Member user) ;
	public String UpgradeMember(Member user) ;
	public String encryptPassword(String passwd);
	public void sendConfirmationMail(User user) ;
	public void updateUserCredentials(User user);
	public void removeUser(User user); 
	public User findUserById(String id);
	public List<User> getAllUsers();
	public String RegistrateSocialMedia(Member user);
	public void sendConfirmationMailSocialMedia(User user);

}
