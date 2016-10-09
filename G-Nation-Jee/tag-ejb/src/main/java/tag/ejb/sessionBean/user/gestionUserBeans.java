package tag.ejb.sessionBean.user;

import javax.ejb.LocalBean;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

import tag.ejb.domain.Member;

/**
 * Session Bean implementation class gestionUserBeans
 */
@Stateless
@LocalBean
public class gestionUserBeans implements gestionUserBeansRemote, gestionUserBeansLocal {

	
	@PersistenceContext
	EntityManager em;
	
	
    /**
     * Default constructor. 
     */
    public gestionUserBeans() {
        // TODO Auto-generated constructor stub
    }

	@Override
	public Member findUserById(String idUser) {
		
		Member	userFound = em.find(Member.class, idUser);
		if(userFound!=null)
		{return userFound;
		}
		return null;
	}
    
    
    
    
    

}
