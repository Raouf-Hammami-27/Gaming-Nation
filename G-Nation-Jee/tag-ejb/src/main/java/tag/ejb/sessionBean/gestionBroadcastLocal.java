package tag.ejb.sessionBean;

import java.util.List;

import javax.ejb.Local;
import tag.ejb.domain.Broadcast;

@Local
public interface gestionBroadcastLocal {

	public List<Broadcast> getAllBroadcast();
}
