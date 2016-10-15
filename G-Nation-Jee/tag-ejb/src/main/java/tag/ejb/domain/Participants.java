package tag.ejb.domain;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.*;

import com.fasterxml.jackson.annotation.JsonIgnore;

/**
 * Entity implementation class for Entity: Participants
 *
 */
@Entity

public class Participants implements Serializable {

	
	private Date date_Limite;
	private User participants;
	private Evenement Evenement;
	private ParticipantsPK participantPK;
	private static final long serialVersionUID = 1L;

	public Participants() {
		super();
	}   
	
	
	public Participants(Date date_Limite, User participants, Evenement Evenement) {
		super();
		this.date_Limite = date_Limite;
		this.participants = participants;
		this.Evenement = Evenement;
		this.participantPK= new ParticipantsPK(participants.getId(),Evenement.getId_Evenement());
	}


	public Date getDate_Limite() {
		return this.date_Limite;
	}

	public void setDate_Limite(Date date_Limite) {
		this.date_Limite = date_Limite;
	}
	@ManyToOne(cascade=CascadeType.ALL)
	@JoinColumn(name="idParticipant",referencedColumnName="Id",insertable=false,updatable=false)
	public User getParticipants() {
		return participants;
	}
	public void setParticipants(User participants) {
		this.participants = participants;
	}
	@ManyToOne
	@JoinColumn(name="idEvenement",referencedColumnName="id_Evenement",insertable=false,updatable=false)
	@JsonIgnore
	public Evenement getEvenement() {
		return Evenement;
	}
	public void setEvenement(Evenement Evenement) {
		this.Evenement = Evenement;
	}
	
	@EmbeddedId
	@JsonIgnore
	public ParticipantsPK getParticipantPK() {
		return participantPK;
	}
	public void setParticipantPK(ParticipantsPK participantPK) {
		this.participantPK = participantPK;
	}
   
}
