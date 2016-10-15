package tag.ejb.sessionBean;

import javax.ejb.Remote;

import tag.ejb.domain.Member;
import tag.ejb.domain.User;

@Remote
public interface gestionUserRemote {
	public void createMember(Member member);

	public Member findMemberById(String id);
	public User getUserById(String id);
	public void createUser(User user);

}
