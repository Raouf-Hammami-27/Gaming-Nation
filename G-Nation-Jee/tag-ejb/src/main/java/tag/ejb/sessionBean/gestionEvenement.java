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
import tag.ejb.domain.Participants;
import tag.ejb.domain.ParticipantsPK;
import tag.ejb.domain.Tournament;
import tag.ejb.domain.User;
import tag.ejb.sessionBean.gestionEvenementLocal;


/**
 * Session Bean implementation class gestionEvenement
 */
@Stateless
@LocalBean

public class gestionEvenement implements gestionEvenementRemote, gestionEvenementLocal{


	@PersistenceContext
	EntityManager em;
	
    public gestionEvenement() {
        // TODO Auto-generated constructor stub
    }

	@Override
	public void createEvenement(Evenement Evenement) {

		em.persist(Evenement);
		
	}

	@Override
	public Evenement getEvenementById(int id) {
		Evenement Evenement = em.find(Evenement.class, id);
		if(Evenement!=null)
			return Evenement;
		else
			return null;
	}

	@Override
	public void reserveForEvenement(int EvenementId, User user) {
		
		Evenement Evenement= getEvenementById(EvenementId);
		Participants p = new Participants(null, em.merge(user), em.merge(Evenement));
		em.persist(p);
		
	
		}

	

	@Override
	public List<Evenement> getAllEvenements() {

		Query query = em.createQuery("SELECT e FROM Evenement e");
		List<Evenement> Evenement = new ArrayList<Evenement>();
		Evenement= query.getResultList();
	    return Evenement;
	}

	@Override
	public String addEvenement(Evenement Evenement) {
		em.persist(Evenement);
		return "Objet ajouté";
	}

	@Override
	public void updateEvenement(Evenement Evenement) {

		em.merge(Evenement);
	}

	@Override
	public void deleteEvenement(Evenement Evenement) {
		em.merge(Evenement);
		
	}

	@Override
	public List<Tournament> getEvenementTournaments(int EvenementId) {
		return getEvenementById(EvenementId).getTournament();
	}

}
