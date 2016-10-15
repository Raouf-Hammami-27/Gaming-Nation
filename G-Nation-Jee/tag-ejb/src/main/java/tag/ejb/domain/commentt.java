package tag.ejb.domain;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.*;

import com.fasterxml.jackson.annotation.JsonIgnore;

import tag.ejb.domain.Article;
import tag.ejb.domain.User;

/**
 * Entity implementation class for Entity: commentt
 *
 */
@Entity
public class commentt implements Serializable {

	private String description;
	private User user;
	private Article article;
	private CommentPk commentPk;
	private static final long serialVersionUID = 1L;

	public commentt() {
		super();
	}
	@ManyToOne
	@JoinColumn(name="IdUser",referencedColumnName="Id",insertable=false,updatable=false)
	public User getUser() {
		return this.user;
	}

	public void setUser(User user) {
		this.user = user;
	}
	@ManyToOne
	@JoinColumn(name="idArticle",referencedColumnName="idArticle",insertable=false,updatable=false)
	public Article getArticle() {
		return this.article;
	}

	public void setArticle(Article article) {
		this.article = article;
	}
	
	
	public String getDescription() {
		return description;
	}
	public void setDescription(String description) {
		this.description = description;
	}
	@EmbeddedId
	public CommentPk getCommentPk() {
		return commentPk;
	}
	public void setCommentPk(CommentPk commentPk) {
		this.commentPk = commentPk;
	}
	public commentt(User user, Article article,String description) {
		super();
		this.description = description;
		this.user = user;
		this.article = article;
		this.commentPk= new CommentPk(user.getId(),article.getIdArticle());

	}
	@Override
	public String toString() {
		return "commentt [description=" + description + ", user=" + user + ", article=" + article ;
	}
	
	
	
	
   
}
