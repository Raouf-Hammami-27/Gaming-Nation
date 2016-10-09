package tag.ejb.sessionBean.user;

import javax.ejb.Remote;

import tag.ejb.domain.Member;

@Remote
public interface gestionUserBeansRemote {

	public Member findUserById(String idUser);
	
	
}
