package tag.ejb.sessionBean.comment;

import java.util.List;

import javax.ejb.Remote;

import tag.ejb.domain.*;
@Remote
public interface ICommentRemote {
	
	public void AddComment(Commentaire c);
	public List<Commentaire> getAllComment();
	public List<Commentaire> getAllCommentByArticle(Integer articleId);
	public void updateComment(Commentaire c);
	public void deleteComment(Long idCommentaire,String idUser);
	public User FindUser(String id);
	public Commentaire getCommentaire(Long id);
	public Article getArticle(Integer id);

}
