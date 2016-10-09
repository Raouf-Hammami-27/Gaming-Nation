package tag.ejb.sessionBean;

import java.util.List;

import javax.ejb.Remote;

import tag.ejb.domain.Evenement;
import tag.ejb.domain.Tournament;
import tag.ejb.domain.User;


@Remote
public interface gestionEvenementRemote {
	
	public void createEvenement(Evenement Evenement);
	public void updateEvenement(Evenement Evenement);
	public void deleteEvenement(Evenement Evenement);
	
	//public Evenement getAllEvenements();
	public Evenement getEvenementById(int id);
	public String addEvenement(Evenement Evenement);

	
	public List<Evenement> getAllEvenements();

	public void reserveForEvenement(int EvenementId, User user);
	public List<Tournament> getEvenementTournaments(int EvenementId);
	

}
