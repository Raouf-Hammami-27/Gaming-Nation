package tag.ejb.domain;

import java.io.Serializable;
import java.lang.Integer;
import java.lang.String;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.persistence.*;

import com.fasterxml.jackson.annotation.JsonIgnore;


/**
 * Entity implementation class for Entity: Evenement
 *
 */
@Entity

public class Evenement implements Serializable {

	
	private Integer id_Evenement;
	private String name;
	private String type;
	private String description;
	private Date date;
	private EvenementOrganizer organizer;	
	private String image_link;

	private String longitude;
	private String latitude;
	private String adresse;
	private List<Tournament> tournament;
	private List<Participants> participants;
	
	private int nbrPlaces;
	
	private static final long serialVersionUID = 1L;

	public Evenement() {
		super();
	}   
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)   
	public Integer getId_Evenement() {
		return this.id_Evenement;
	}

	public void setId_Evenement(Integer id_Evenement) {
		this.id_Evenement = id_Evenement;
	}   
	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}   
	public String getType() {
		return this.type;
	}

	public void setType(String type) {
		this.type = type;
	}   
	public String getDescription() {
		return this.description;
	}

	public void setDescription(String description) {
		this.description = description;
	}   
	@Temporal(TemporalType.DATE)
	public Date getDate() {
		return this.date;
	}

	public void setDate(Date date) {
		this.date = date;
	}
	@ManyToOne
	public EvenementOrganizer getOrganizer() {
		return organizer;
	}
	public void setOrganizer(EvenementOrganizer organizer) {
		this.organizer = organizer;
	}
	@OneToMany(fetch=FetchType.EAGER,mappedBy="evenement")
	
	public List<Tournament> getTournament() {
		return tournament;
	}
	public void setTournament(List<Tournament> tournament) {
		this.tournament = tournament;
	}
	
	public int getNbrPlaces() {
		return nbrPlaces;
	}
	public void setNbrPlaces(int nbrPlaces) {
		this.nbrPlaces = nbrPlaces;
	}
	
	@OneToMany(fetch=FetchType.EAGER,mappedBy="evenement",cascade=CascadeType.REFRESH)
	@JsonIgnore
	public List<Participants> getParticipants() {
		return participants;
	}
	public void setParticipants(List<Participants> participants) {
		this.participants = participants;
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
	
   
}
