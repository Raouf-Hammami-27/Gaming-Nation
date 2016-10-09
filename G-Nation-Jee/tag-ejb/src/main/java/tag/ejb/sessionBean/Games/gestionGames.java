package tag.ejb.sessionBean.Games;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.ejb.LocalBean;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import tag.ejb.domain.Article;
import tag.ejb.domain.Member;
import tag.ejb.domain.commentt;
import tag.ejb.domain.game;
import tag.ejb.domain.news;
import tag.ejb.domain.raiting;

/**
 * Session Bean implementation class gestionGames
 */
@Stateless
@LocalBean
public class gestionGames implements gestionGamesRemote, gestionGamesLocal {

	
	@PersistenceContext
	EntityManager em;
	
	
	
    /**
     * Default constructor. 
     */
    public gestionGames() {
        
    	
    }
   

	@Override
	public game findGamesById(int idArticle) {
	
		game  gameFound =  em.find(game.class, idArticle);
		if(gameFound!=null)
		{return gameFound;
		}
		return null;
		
	}

	@Override
	public void cancelRate(Member member, game gaame) {

		raiting rate = new raiting(em.merge(member), em.merge(gaame), null);
		em.remove(em.merge(rate));
		
		
	}

	


	@Override
	public void CommentOnGames(Member member, int idArticle, String description) {
		 game game=findGamesById( idArticle);
		 commentt cmt = new commentt(em.merge(member),em.merge(game), description);
		  
		   em.persist(cmt);
		
	}
	
	
	@Override
	public void RateGames(Member member, int idArticle, int rate) {
		 game game=findGamesById( idArticle);
		raiting rat = new raiting (em.merge(member) ,em.merge(game),rate );
		em.persist(rat);
		int numb =  getAverageRatingOfGame(em.merge(game).getIdArticle());
		em.merge(game).setRating(numb);
		
	}
	
	


	@Override
	public List<game> getAllGames() {
		
		Query query = em.createQuery("from game g");
		List<game>listGames = query.getResultList();
		return listGames;
		
		
	}


	@Override
	public game getGame(String name) {
		String text= "select g from game g where g.name= :name ";
		Query query= em.createQuery(text).setParameter("name", name);
		game game=(game) query.getSingleResult();
		return game;
	}


	@Override
	public game getGameByCategory(String category) {
		String text= "select g from game g where g.category= :category ";
		Query query= em.createQuery(text).setParameter("category", category);
		game game=(game) query.getSingleResult();
		
		return game;
	}


	@Override
	public int getAverageRatingOfGame(int idArticle) {
		Query namedQuery = em.createNamedQuery("Rating.avgRating");
		namedQuery.setParameter("idArticle", idArticle);
		if (namedQuery.getResultList().size() > 0) {
			return ((Double)namedQuery.getSingleResult()).intValue();	
		} else {
			return 0;
		}
	}


	


	@Override
	public raiting findByGameAndUsername(int idArticle, String username) {
		Query q = em.createNamedQuery("Rating.findByGameAndUsername")
		            .setParameter("idArticle", idArticle)
		            .setParameter("username", username);
		            
		          
		    			raiting rating = (raiting) q.getSingleResult();
		    			return rating;
		    		
	}


	@Override
	public List<game> getBestRanked() {
		String text= "select a from game a GROUP BY a.idArticle ORDER BY AVG(a.rating) DESC";
		Query query= em.createQuery(text);
	  List<game> list = query.getResultList();
     return list;
	

	}


	@Override
	public List<game> getMostCommented() {
		String text= "SELECT c.article FROM commentt c GROUP BY c.article.idArticle ORDER BY COUNT(*) DESC";
		Query query= em.createQuery(text);
		  List<game> list = query.getResultList();
		  return list;


		
	}


	@Override
	public void updateComment(commentt comm) {
		em.merge(comm);	
		
	}


	@Override
	public void removeCommentOnGames(commentt comm) {
		em.remove(em.merge(comm));
		
	}


	


	@Override
	public commentt findCommGamesByMemberNews(String Id, int idArticle) {
		String text= "select c from commentt c where c.user.Id = :Id and c.article.idArticle= :idArticle";
		Query query= em.createQuery(text).setParameter("Id", Id).setParameter("idArticle", idArticle);
		 commentt ComgmeFound = (commentt) query.getSingleResult();
		return ComgmeFound;
	}



	
	
	

}
