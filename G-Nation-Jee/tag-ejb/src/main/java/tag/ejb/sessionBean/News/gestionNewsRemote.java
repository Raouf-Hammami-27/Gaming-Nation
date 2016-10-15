package tag.ejb.sessionBean.News;

import java.util.Date;
import java.util.List;

import javax.ejb.Remote;

import tag.ejb.domain.Member;
import tag.ejb.domain.commentt;
import tag.ejb.domain.news;

@Remote
public interface gestionNewsRemote {
	
	
	
	
	public news findNewsById(int idArticle);
	public void CommentOnNews( Member user ,int idArticle,  String description);
	public List<news> getAllNews();
	public void updateCommentOnNews(commentt comm);
	public commentt findCommNewsByMemberNews(String idUser, int idArticle,Date date) ;
	public void removeCommentOnNews(commentt comm);
	public List<news>getMostCommented();
	public void CommentOnNews(commentt cm);
	public List<commentt> getCommentByArticle(int idArticle);
	

}
