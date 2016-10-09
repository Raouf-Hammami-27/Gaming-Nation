package tag.ejb.domain;

import java.io.Serializable;

import javax.persistence.Embeddable;

@Embeddable
public class RaitingPk  implements Serializable{
	
	
	private static final long serialVersionUID = 1L;
	private String Id;
	private int idArticle;
	
	
	
	
	
	
	
	
 
	
	
	
	
	
	public RaitingPk() {
		super();
		// TODO Auto-generated constructor stub
	}
	public RaitingPk(String Id, int idArticle) {
		super();
		this.Id = Id;
		this.idArticle = idArticle;
	}
	
	
	
	
	
	
	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
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
		RaitingPk other = (RaitingPk) obj;
		if (idArticle != other.idArticle)
			return false;
		if (Id == null) {
			if (other.Id != null)
				return false;
		} else if (!Id.equals(other.Id))
			return false;
		return true;
	}
	public String getIdUser() {
		return Id;
	}
	public void setIdUser(String idUser) {
		this.Id = idUser;
	}
	public int getIdArticle() {
		return idArticle;
	}
	public void setIdArticle(int idArticle) {
		this.idArticle = idArticle;
	}
	
	
	
	
	
	


	
	
	
	

}
