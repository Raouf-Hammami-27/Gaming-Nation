package tag.ejb.domain;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.Embeddable;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

@Embeddable
public class CommentPk implements Serializable{

	private static final long serialVersionUID = 1L;
	String Id;
	int idArticle;
	Date date ;
	public String getIdUser() {
		return Id;
	}
	public void setIdUser(String idUser) {
		this.Id = idUser;
	}
	
	
	@Temporal(TemporalType.TIMESTAMP)
	public Date getDate() {
		return date;
	}
	public void setDate(Date date) {
		this.date = date;
	}
	public int getIdArticle() {
		return idArticle;
	}
	public void setIdArticle(int idArticle) {
		this.idArticle = idArticle;
	}
	public CommentPk(String Id, int idArticle) {
		super();
		this.date= new Date();
		this.Id = Id;
		this.idArticle = idArticle;
	}
	public CommentPk() {
		super();
	}

	
	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + ((date == null) ? 0 : date.hashCode());
		result = prime * result + idArticle;
		result = prime * result + ((Id == null) ? 0 : Id.hashCode());
		return result;
	}
	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		CommentPk other = (CommentPk) obj;
		if (date == null) {
			if (other.date != null)
				return false;
		} else if (!date.equals(other.date))
			return false;
		if (idArticle != other.idArticle)
			return false;
		if (Id == null) {
			if (other.Id != null)
				return false;
		} else if (!Id.equals(other.Id))
			return false;
		return true;
	}
	@Override
	public String toString() {
		return "CommentPk [Id=" + Id + ", idArticle=" + idArticle + ", date="
				+ date + "]";
	}
	
	


	
	
	
	
	
}
