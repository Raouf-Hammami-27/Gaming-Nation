package tag.ejb.sessionBean.comment;

import java.util.List;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import tag.ejb.domain.*;

@Stateless
public class ForumThreadEjbImpl implements IForumThreadLocal, IForumThreadRemote {

	@PersistenceContext
	private EntityManager em;

	@Override
	public User FindUser(String idUser) {

		User u = em.find(User.class, idUser);
		if (u == null)
			throw new RuntimeException("User Introuvable");
		return u;
	}

	@Override
	public String AddForumThread(ForumThread f) {
		em.persist(f);
		return "success";

	}

	@SuppressWarnings("unchecked")
	@Override
	public List<ForumThread> getAllForumThread() {
		Query req = em.createQuery("select f from ForumThread f");
		return req.getResultList();
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<ForumThread> searchForumThread(String m) {
		try {
			Query req = em.createQuery("select f from ForumThread f where f.title like ?1");
			req.setParameter(1, "%" + m + "%");
			return req.getResultList();
		} catch (Exception e) {
			// TODO Auto-generated catch block
			throw new RuntimeException("ForumThread not Found");
		}
	}

	@SuppressWarnings("null")
	@Override
	public ForumThread getForumThread(Integer id) {
		ForumThread f = em.find(ForumThread.class, id);
		if (f == null && f instanceof ForumThread)
			throw new RuntimeException("ForumThread Introuvable");
		return f;
	}

	@Override
	public void updateForumThread(ForumThread f) {
		em.merge(f);

	}

	@Override
	public void deleteForumThread(Integer idForumThread, String idUser) {
		ForumThread f = getForumThread(idForumThread);
		User u = FindUser(idUser);

		if (f.getUser().equals(u)) {
			em.remove(f);
		} else {
			throw new RuntimeException("you don't have permission");
		}

	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Commentaire> getCommentaire(Long id) {
		Query req = em.createQuery("select c from Commentaire c where c.article = ?1");
		req.setParameter(1, "%" + id + "%");
		return req.getResultList();
	}

}
