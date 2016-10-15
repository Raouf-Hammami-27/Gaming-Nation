package tag.ejb.sessionBean;

import javax.ejb.LocalBean;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

import tag.ejb.domain.Member;
import tag.ejb.domain.User;

/**
 * Session Bean implementation class GestionUser
 */
@Stateless
@LocalBean
public class gestionUser implements gestionUserRemote, gestionUserLocal {

    /**
     * Default constructor. 
     */
	@PersistenceContext
	private EntityManager em;

    public gestionUser() {
    }
    @Override
	public void createMember(Member member) {
		em.persist(member);		
	}


    @Override
	public Member findMemberById(String id) {
	return (Member) em.find(User.class,id);
		}
    
    @Override
	public User getUserById(String id) {

		User user = em.find(User.class, id);
		if(user!=null)
			return user;
		else
			return null;
		}

	@Override
	public void createUser(User user) {

		em.persist(user);
	}

	
}
