package tag.ejb.sessionBean;

import javax.ejb.Local;

import tag.ejb.domain.Member;
import tag.ejb.domain.User;

@Local
public interface gestionUserLocal {

	public void createMember(Member member);

	public Member findMemberById(String id);
	public User getUserById(String id);
	public void createUser(User user);
}
