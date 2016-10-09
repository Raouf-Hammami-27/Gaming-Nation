package tag.ejb.sessionBean;

import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.security.SecureRandom;
import java.util.ArrayList;
import java.util.List;
import java.util.Properties;

import javax.ejb.LocalBean;
import javax.ejb.Stateless;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import tag.ejb.domain.Member;
import tag.ejb.domain.User;
import tag.ejb.domain.Vip;

/**
 * Session Bean implementation class registrationUser
 */
@Stateless
@LocalBean
public class registrationUser implements registrationUserRemote, registrationUserLocal {

	/**
     * Default constructor. 
     */
    public registrationUser() {
    }
Member member = new Member();
String urlConfirmation;
authenticationUserRemote auth;
@PersistenceContext
EntityManager em;

	@Override
	public String Registrate(Member user) {
				
		em.persist(user);
		user.setPassword(encryptPassword(user.getPassword()));
		user.setRole("Member");
		//sendConfirmationMail(user);	
		return("success");
	}
	
	
	@Override
	public String encryptPassword(String passwd)
    {
		
    	MessageDigest md;
		try {
			md = MessageDigest.getInstance("SHA-256");
			md.update(passwd.getBytes());
			 
	        byte byteData[] = md.digest();
 
	        StringBuffer hexString = new StringBuffer();
	    	for (int i=0;i<byteData.length;i++) {
	    		String hex=Integer.toHexString(0xff & byteData[i]);
	   	     	if(hex.length()==1) hexString.append('0');
	   	     	hexString.append(hex);
	    	}
	    	String result = hexString.toString();
	    	System.out.println("userpassword from database:" + result);
	    	return result;
		} catch (NoSuchAlgorithmException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
			return null;
		}
		

    }
	@Override
	public void sendConfirmationMail(User user) {
		
	}




	@Override
	public void updateUserCredentials(User user) {
			em.merge(user);
		//user.setPassword(encryptPassword(user.getPassword()));
	}
	@Override
	public void removeUser(User user) {
		
			em.remove(em.merge(user));
		System.out.println("user removed");
		
	}

	@Override
	public User findUserById(String id) {
		User user = em.find(User.class,id);
		
		return user;	
		
	}


	@Override
	public List<User> getAllUsers() {
		Query req= em.createQuery("SELECT u FROM User u");
		return req.getResultList();
	}


	@Override
	public String UpgradeMember(Member user) {
	 		Vip vip = new Vip();
	 		vip.setId(user.getId());
	 		vip.setFirstName(user.getFirstName());
	 		vip.setLastName(user.getLastName());
	 		vip.setUsername(user.getUsername());
	 		vip.setMail(user.getMail());
	 		vip.setPassword(user.getPassword());
	 		vip.setRole("VIP");
	 		 		
	removeUser(user);
	em.persist(vip);	
	return("success");
	}


	@Override
	public String RegistrateSocialMedia(Member user) {
				
		em.persist(user);
		user.setRole("Member");
		//sendConfirmationMailSocialMedia(user);	
		return("success");
	}
	
	
	@Override
	public void sendConfirmationMailSocialMedia(User user) {
		
				
	}



	
}
