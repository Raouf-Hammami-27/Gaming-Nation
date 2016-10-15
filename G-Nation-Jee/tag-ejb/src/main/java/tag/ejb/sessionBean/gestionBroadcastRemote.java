package tag.ejb.sessionBean;

import java.util.List;

import javax.ejb.Remote;

import tag.ejb.domain.Broadcast;

@Remote
public interface gestionBroadcastRemote {

	public List<Broadcast> getAllBroadcast();

}
