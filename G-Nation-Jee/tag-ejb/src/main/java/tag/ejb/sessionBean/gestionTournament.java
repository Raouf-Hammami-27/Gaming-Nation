package tag.ejb.sessionBean;

import java.util.ArrayList;
import java.util.List;
import java.util.Properties;

import javax.ejb.LocalBean;
import javax.ejb.Stateless;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import tag.ejb.domain.Evenement;
import tag.ejb.domain.ParticipantTournament;
import tag.ejb.domain.Participants;
import tag.ejb.domain.Tournament;
import tag.ejb.domain.User;

/**
 * Session Bean implementation class gestionTournament
 */
@Stateless
@LocalBean
public class gestionTournament implements gestionTournamentRemote, gestionTournamentLocal {

	@PersistenceContext
	EntityManager em;
    public gestionTournament() {
        // TODO Auto-generated constructor stub
    }

	@Override
	public void createTournament(Tournament tournament) {
		em.persist(tournament);
	}

	@Override
	public void updateTournament(Tournament tournament) {
		em.merge(tournament);
	}

	@Override
	public void deleteTournament(Tournament tournament) {
		em.merge(tournament);
		
	}

	@Override
	public Tournament getTournamentById(int id) {
		Tournament tournament = em.find(Tournament.class, id);
		if(tournament!=null)
			return tournament;
		else
			return null;
	}

	@Override
	public String addTournament(Tournament tournament) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<Tournament> getAllTournaments() {
		Query query = em.createQuery("SELECT t FROM Tournament t");
		List<Tournament> tournament = new ArrayList<Tournament>();
		tournament= query.getResultList();
	    return tournament;
	}

	@Override
	public void reserveForTournament(int tournamentId, User user) {
		Tournament Evenement= getTournamentById(tournamentId);
		ParticipantTournament p = new ParticipantTournament(null, em.merge(user), em.merge(Evenement));
		em.persist(p);
		
		
		
	}

}
