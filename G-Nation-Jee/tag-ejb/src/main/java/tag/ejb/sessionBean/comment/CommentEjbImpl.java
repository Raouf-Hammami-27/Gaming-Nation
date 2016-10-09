package tag.ejb.sessionBean.comment;

import java.util.Date;
import java.util.List;

import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import tag.ejb.domain.*;


@Stateless
public  class CommentEjbImpl implements ICommentLocal,ICommentRemote {
   
	@PersistenceContext
	private EntityManager em;

	@Override
	public void CommentOnForum(String description,Date date,Member user,Integer idArticle) {
	   ForumThread forum= (ForumThread) getArticle(idArticle);
	   Commentaire cmt= new Commentaire(description,date,em.merge(user),em.merge(forum));
		
		em.persist(cmt);
		}

	@SuppressWarnings("unchecked")
	@Override
	public List<Commentaire> getAllComment() {
		Query req=em.createQuery("select c from Commentaire c");
		return req.getResultList();
	}

	@Override
	public void updateComment(Commentaire c) {
		em.merge(c);
		
	}

	@Override
	public void deleteComment(Long idCommentaire, String idUser) {
		Commentaire c = getCommentaire(idCommentaire);
		User u = FindUser(idUser);
		
		if (c.getUser().equals(u) || u instanceof Administrator) {
			em.remove(c);
		}else {
			throw new RuntimeException("you don't have permission");
		}
		
	}

	@Override
	public User FindUser(String id) {
		User u=em.find(User.class, id);
		if(u==null) throw new RuntimeException("User Not Found");
		return u;
	}

	@Override
	public Commentaire getCommentaire(Long id) {
		Commentaire c=em.find(Commentaire.class, id);
		if(c==null) throw new RuntimeException("Comment Not Found");
		return c;
	}

	@Override
	public Article getArticle(Integer id) {
		Article a= em.find(Article.class, id);
		if(a==null) throw new RuntimeException("Article Not Found");
		return a;
	}

	@Override
	public List<Commentaire> getAllCommentByArticle(Integer idArticle) {
		String text= "SELECT c FROM Commentaire c where  c.article.idArticle = :idArticle  ORDER BY c.date DESC";
		Query query= em.createQuery(text).setParameter("idArticle", idArticle);
		 List<Commentaire> list = query.getResultList();
		  return list;
	}

	@Override
	public void AddComment(Commentaire c) {
		// TODO Auto-generated method stub
		
	}

	



	


	
}
