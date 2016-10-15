package tag.ejb.domain;

import java.io.Serializable;
import java.lang.Integer;
import java.lang.String;

import javax.persistence.*;

import com.fasterxml.jackson.annotation.JsonIgnore;

/**
 * Entity implementation class for Entity: tournament
 *
 */
@Entity

public class Tournament implements Serializable {

	
	private Integer id_tournament;
	private String name;
	private String description;
	private Evenement evenement;
	private int nbrPlaces;
	private String image_link;
	private String Broadcast_link;
	
	private String longitude;
	private String latitude;
	private String adresse;
	private static final long serialVersionUID = 1L;

	public Tournament() {
		super();
	}  
	
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)   
	public Integer getId_tournament() {
		return this.id_tournament;
	}

	public void setId_tournament(Integer id_tournament) {
		this.id_tournament = id_tournament;
	}   
	
	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}   
	
	public String getDescription() {
		return this.description;
	}

	public void setDescription(String description) {
		this.description = description;
	}
	
	@ManyToOne
	@JsonIgnore
	public Evenement getEvenement() {
		return evenement;
	}
	
	public void setEvenement(Evenement Evenement) {
		this.evenement = Evenement;
	}
	
	public int getNbrPlaces() {
		return nbrPlaces;
	}
	
	public void setNbrPlaces(int nbrPlaces) {
		this.nbrPlaces = nbrPlaces;
	}

	public String getImage_link() {
		return image_link;
	}

	public void setImage_link(String image_link) {
		this.image_link = image_link;
	}

	public String getLongitude() {
		return longitude;
	}

	public void setLongitude(String longitude) {
		this.longitude = longitude;
	}

	public String getLatitude() {
		return latitude;
	}

	public void setLatitude(String latitude) {
		this.latitude = latitude;
	}

	public String getAdresse() {
		return adresse;
	}

	public void setAdresse(String adresse) {
		this.adresse = adresse;
	}

	public String getBroadcast_link() {
		return Broadcast_link;
	}

	public void setBroadcast_link(String broadcast_link) {
		Broadcast_link = broadcast_link;
	}
   
}
