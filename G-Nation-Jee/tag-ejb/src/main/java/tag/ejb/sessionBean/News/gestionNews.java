package tag.ejb.sessionBean.News;

import java.util.Date;
import java.util.List;

import javax.ejb.LocalBean;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import tag.ejb.domain.Member;
import tag.ejb.domain.User;
import tag.ejb.domain.commentt;
import tag.ejb.domain.game;
import tag.ejb.domain.news;

/**
 * Session Bean implementation class gestionNews
 */
@Stateless
@LocalBean
public class gestionNews implements gestionNewsRemote, gestionNewsLocal {

   
	@PersistenceContext
	EntityManager em;
	
	
	
	
    public gestionNews() {
        // TODO Auto-generated constructor stub
    }

	@Override
	public news findNewsById(int idArticle) {
		news	newFound = em.find(news.class, idArticle);
		if(newFound!=null)
		{return newFound;
		}
		return null;
	}
	
	
	
	
	@Override
	public commentt findCommNewsByMemberNews(String Id, int idArticle,Date date) {
		String text= "select c from commentt c where c.user.Id = :Id and c.article.idArticle = :idArticle and c.commentPk.date= :date ";
		Query query= em.createQuery(text).setParameter("Id", Id).setParameter("idArticle", idArticle).setParameter("date", date);
		commentt	ComnewFound = (commentt) query.getSingleResult();
		
		return ComnewFound;
		
	}
	

	

	@Override
	public void CommentOnNews(Member user,int idArticle,  String description) {
	   news news= findNewsById(idArticle);
		commentt cmt= new commentt(em.merge(user),em.merge(news), description);
		
		em.persist(cmt);
		
		
	}

	@Override
	public List<news> getAllNews() {
	
		Query query = em.createQuery("from news n");
		List<news> listNews = query.getResultList();
		return listNews;
		
		
	}


	@Override
	public void updateCommentOnNews(commentt comm) {
		
			em.merge(comm);		
		}

	@Override
	public void removeCommentOnNews(commentt comm) {
		em.remove(em.merge(comm));
		
	}

	@Override
	public List<news> getMostCommented() {
		String text= "SELECT c.article FROM commentt c GROUP BY c.article.idArticle ORDER BY COUNT(*) DESC";
		Query query= em.createQuery(text);
		  List<news> list = query.getResultList();
		  return list;
	}

	@Override
	public void CommentOnNews(commentt cm) {
		Member user = null;
		news news=null;
	
		String  description=" ";
		commentt cmt= new commentt(em.merge(user),em.merge(news),  description);

		
		em.persist(cm);
		
		
	}

	@Override
	public List<commentt> getCommentByArticle(int idArticle) {
		String text= "SELECT c FROM commentt c where  c.article.idArticle = :idArticle  ORDER BY c.commentPk.date DESC";
		Query query= em.createQuery(text).setParameter("idArticle", idArticle);
		 List<commentt> list = query.getResultList();
		  return list;
	}

	
		
	

	
}
