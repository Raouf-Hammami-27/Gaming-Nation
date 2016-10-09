package tag.ejb.sessionBean;

import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;


import javax.ejb.LocalBean;
import javax.ejb.Stateless;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.TypedQuery;

import tag.ejb.domain.User;

/**
 * Session Bean implementation class authenticationUser
 */
@Stateless
@LocalBean
public class authenticationUser implements authenticationUserRemote, authenticationUserLocal {

    /**
     * Default constructor. 
     */
	/*private String urlConfirmation = "http://localhost:18080/edu.esprit.tag/confirmation.?id=";*/

	@PersistenceContext
	EntityManager em;

	@Override
	public User authenticateUser(String username, String password) {
        // TODO Auto-generated constructor stub	
		TypedQuery<User> query = em.createQuery("SELECT u FROM User u WHERE u.username=:username AND u.password=:password",User.class);
    	query.setParameter("username", username)
    		 .setParameter("password", encryptPassword(password));
		try {
			System.out.println("authenticated");
			User user = query.getSingleResult();	
			return user;
			
		} catch (Exception e) {
			return null;
		}
		}
	@Override
	public String getSessionId(User user) {

		authenticateUser(user.getUsername(),user.getPassword());
		return user.getId();		
	}
	
	@Override
	public User findUserById(int id) {
		User user = em.find(User.class,id);
		if(user!=null)
		{return user;
			
		}
		return null;
	}

	@Override
	public User getUserByUserName(String username) {
		Query query=em.createQuery("select u from User u where u.username=:username");
				query.setParameter("username", username).getSingleResult();
				return (User) query.getSingleResult();
	}


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
	public void RecoverPassword(String username) {
				
		User member =getUserByUserName(username);
		String password = member.getPassword();
		
	}
	@Override
	public User RecoverAccount(String password) {
        // TODO Auto-generated constructor stub	
		TypedQuery<User> query = em.createQuery("SELECT u FROM User u WHERE u.password=:password",User.class);
    					query.setParameter("password", password);
		try {
			
			System.out.println("Aucount recovered");
			User user = query.getSingleResult();	
			return user;
									
		} catch (Exception e) {
			return null;
		}
		}

}

	
	

	
	
	




