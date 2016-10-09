package tag.ejb.sessionBean;

import java.util.List;

import javax.ejb.Remote;

import tag.ejb.domain.Evenement;
import tag.ejb.domain.Tournament;
import tag.ejb.domain.User;

@Remote
public interface gestionTournamentRemote {
	public void createTournament(Tournament tournament);
	public void updateTournament(Tournament tournament);
	public void deleteTournament(Tournament tournament);
	
	//public Evenement getAllEvenements();
	public Tournament getTournamentById(int id);
	public String addTournament(Tournament tournament);

	
	public List<Tournament> getAllTournaments();

	public void reserveForTournament(int tournamentId, User user);
}
