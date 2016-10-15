package tag.ejb.sessionBean.Games;

import java.util.List;

import javax.ejb.Local;

import tag.ejb.domain.Article;
import tag.ejb.domain.Member;
import tag.ejb.domain.commentt;
import tag.ejb.domain.game;
import tag.ejb.domain.raiting;

@Local
public interface gestionGamesLocal {

	public game findGamesById(int idArticle);
	public void CommentOnGames(Member member , int  idArticle , String description);
	public void RateGames(Member member, int idArticle, int rate);

	public void cancelRate(Member member,game gaame);
	public List<game>getAllGames();
	public game getGame(String name);
	public game getGameByCategory(String category);
	public int getAverageRatingOfGame(int idArticle);
	public raiting findByGameAndUsername(int idArticle, String username );
	public List<game>getMostCommented();
	public List<game> getBestRanked();
	public commentt findCommGamesByMemberNews(String idUser, int idArticle) ;

	public void updateComment(commentt comm) ;
	public void removeCommentOnGames(commentt comm);
	
	
	
	
}
