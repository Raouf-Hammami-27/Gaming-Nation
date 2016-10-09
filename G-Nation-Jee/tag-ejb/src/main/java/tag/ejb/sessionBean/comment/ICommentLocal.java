package tag.ejb.sessionBean.comment;

import java.util.Date;
import java.util.List;

import javax.ejb.Local;

import tag.ejb.domain.*;

@Local
public interface ICommentLocal {
	
	public void CommentOnForum(String description,Date date,Member user,Integer idArticle);
	public List<Commentaire> getAllComment();
	public List<Commentaire> getAllCommentByArticle(Integer articleId);
	public void updateComment(Commentaire c);
	public void deleteComment(Long idCommentaire,String idUser);
	public User FindUser(String id);
	public Commentaire getCommentaire(Long id);
	public Article getArticle(Integer id);

}
