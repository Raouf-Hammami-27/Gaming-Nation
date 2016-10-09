package tag.ejb.sessionBean.comment;

import java.util.List;

import javax.ejb.Local;

import tag.ejb.domain.*;

@Local
public interface IForumThreadLocal {

	public String AddForumThread(ForumThread f);

	public List<ForumThread> getAllForumThread();

	public List<ForumThread> searchForumThread(String m);

	public ForumThread getForumThread(Integer id);

	public void updateForumThread(ForumThread f);

	public void deleteForumThread(Integer idForumThread, String idUser);

	public User FindUser(String id);

	public List<Commentaire> getCommentaire(Long id);
}
