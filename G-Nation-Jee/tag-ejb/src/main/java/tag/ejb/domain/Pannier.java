package tag.ejb.domain;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;


@Entity

public class Pannier implements Serializable{
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private Long idPannier;
    private Produit produit;
    private User user;
	private Date date;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	public Long getIdPannier() {
		return idPannier;
	}
	public void setIdPannier(Long idPannier) {
		this.idPannier = idPannier;
	}
	@ManyToOne
	@JoinColumn(name = "idProduit")
	public Produit getProduit() {
		return produit;
	}
	public void setProduit(Produit produit) {
		this.produit = produit;
	}
	@ManyToOne
	@JoinColumn(name = "Id")
	public User getUser() {
		return user;
	}
	public void setUser(User user) {
		this.user = user;
	}
	@Temporal(TemporalType.TIMESTAMP)
	public Date getDate() {
		return date;
	}
	public void setDate(Date date) {
		this.date = date;
	}

	public Pannier() {
		super();
	}
	public Pannier(Produit produit, User user, Date date) {
		super();
		this.produit = produit;
		this.user = user;
		this.date = date;
	}
	
	
	
	
}
