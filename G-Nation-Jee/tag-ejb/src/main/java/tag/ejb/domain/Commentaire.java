package tag.ejb.domain;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

@Entity
@Table(name = "COMMENTAIRE")
public class Commentaire implements Serializable {

	private static final long serialVersionUID = 1L;
	
	private Long idCommentaire;
	private String description;
	private Date date;
	
	private User user;
	private Article article;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	public Long getIdCommentaire() {
		return idCommentaire;
	}

	public void setIdCommentaire(Long idCommentaire) {
		this.idCommentaire = idCommentaire;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}
	
	@Temporal(TemporalType.TIMESTAMP)
	public Date getDate() {
		return date;
	}

	public void setDate(Date date) {
		this.date = date;
	}

	@ManyToOne
	@JoinColumn(name = "Id" )
	public User getUser() {
		return user;
	}

	public void setUser(User user) {
		this.user = user;
	}

	@ManyToOne
	@JoinColumn(name = "idArticle",referencedColumnName="idArticle")
	public Article getArticle() {
		return article;
	}

	public void setArticle(Article article) {
		this.article = article;
	}

	public Commentaire(String description, Date date, User user, Article article) {
		super();
		this.description = description;
		this.date = date;
		this.user = user;
		this.article = article;
	}

	public Commentaire() {
		super();
		// TODO Auto-generated constructor stub
	}

}
