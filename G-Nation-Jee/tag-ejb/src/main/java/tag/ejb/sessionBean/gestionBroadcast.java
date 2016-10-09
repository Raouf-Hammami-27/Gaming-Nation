package tag.ejb.sessionBean;

import java.util.ArrayList;
import java.util.List;

import javax.ejb.LocalBean;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.Query;
import tag.ejb.domain.Broadcast;

/**
 * Session Bean implementation class gestionBroadcast
 */
@Stateless
@LocalBean
public class gestionBroadcast implements gestionBroadcastRemote, gestionBroadcastLocal {

    /**
     * Default constructor. 
     */
	EntityManager em;

    public gestionBroadcast() {
        // TODO Auto-generated constructor stub
    }

	@Override
	public List<Broadcast> getAllBroadcast() {
		Query query = em.createQuery("SELECT b FROM Broadcast b");
		List<Broadcast> broadcast = new ArrayList<Broadcast>();
		broadcast= query.getResultList();
	    return broadcast;
	}

	

}
