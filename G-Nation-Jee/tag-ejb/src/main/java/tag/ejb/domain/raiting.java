package tag.ejb.domain;

import java.io.Serializable;
import java.lang.Integer;

import javax.persistence.*;


import tag.ejb.domain.Member;
import tag.ejb.domain.game;

/**
 * Entity implementation class for Entity: raiting
 *
 */
@Entity
@NamedQueries({
@NamedQuery(name = "Rating.avgRating",query = "SELECT avg(r.rate) FROM raiting r WHERE r.gme.idArticle = :idArticle"),
@NamedQuery(name = "Rating.findByGameAndUsername",
query = "SELECT  r FROM raiting r WHERE r.gme.idArticle = :idArticle AND r.mem.username = :username")

})
public class raiting implements Serializable {

	
	private Member mem;
	private game gme;
	private Integer rate;
	private RaitingPk raitingPk;
	private static final long serialVersionUID = 1L;
	

	public raiting() {
		super();
	}   
	  
   
	public Integer getRate() {
		return this.rate;
	}

	public void setRate(Integer rate) {
		this.rate = rate;
	}
	
	@EmbeddedId
	public RaitingPk getRaitingPk() {
		return raitingPk;
	}
	public void setRaitingPk(RaitingPk raitingPk) {
		this.raitingPk = raitingPk;
	}
	@ManyToOne
	@JoinColumn(name="idUser",referencedColumnName="Id",insertable=false,updatable=false)
	
	public Member getMem() {
		return mem;
	}
	public void setMem(Member mem) {
		this.mem = mem;
	}
	@ManyToOne
	@JoinColumn(name="idArticle",referencedColumnName="idArticle",insertable=false,updatable=false)
	public game getGme() {
		return gme;
	}
	public void setGme(game gme) {
		this.gme = gme;
	}
	public raiting(Member membre, game game, Integer rate) {
		super();
		this.mem=membre;
		this.gme=game;
		this.rate=rate;
		
		this.raitingPk= new RaitingPk(membre.getId(),game.getIdArticle());

	}


	@Override
	public String toString() {
		return "raiting [mem=" + mem + ", gme=" + gme + ", rate=" + rate + "]";
	}
   
	
	
	
	
}
