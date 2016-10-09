package tag.ejb.sessionBean.user;

import javax.ejb.Local;

import tag.ejb.domain.Member;

@Local
public interface gestionUserBeansLocal {

	public Member findUserById(String idUser);
	
}
