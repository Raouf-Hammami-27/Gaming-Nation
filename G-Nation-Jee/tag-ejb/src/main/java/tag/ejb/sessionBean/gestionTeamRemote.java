package tag.ejb.sessionBean;

import javax.ejb.Remote;

import tag.ejb.domain.Team;



@Remote
public interface gestionTeamRemote {
	
	
	public void createTeam(Team team);

}
