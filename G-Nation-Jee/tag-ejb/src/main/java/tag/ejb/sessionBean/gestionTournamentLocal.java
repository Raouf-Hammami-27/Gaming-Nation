package tag.ejb.sessionBean;

import java.util.List;

import javax.ejb.Local;

import tag.ejb.domain.Tournament;
import tag.ejb.domain.User;

@Local
public interface gestionTournamentLocal {
	public void createTournament(Tournament tournament);
	public void updateTournament(Tournament tournament);
	public void deleteTournament(Tournament tournament);
	
	//public Event getAllEvents();
	public Tournament getTournamentById(int id);
	public String addTournament(Tournament tournament);

	
	public List<Tournament> getAllTournaments();

	public void reserveForTournament(int tournamentId, User user);
}
