package tag.ejb.sessionBean;

import javax.ejb.LocalBean;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

import tag.ejb.domain.Team;

/**
 * Session Bean implementation class gestionTeam
 */
@Stateless
@LocalBean
public class gestionTeam implements gestionTeamRemote, gestionTeamLocal {
	
	
	@PersistenceContext
	EntityManager em;

    /**
     * Default constructor. 
     */
    public gestionTeam() {
        // TODO Auto-generated constructor stub
    }

	@Override
	public void createTeam(Team team) {
	 em.persist(team);
		
	}

}
