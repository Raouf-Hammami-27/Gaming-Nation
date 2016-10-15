package tag.ejb.domain;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.*;

import com.fasterxml.jackson.annotation.JsonIgnore;

/**
 * Entity implementation class for Entity: ParticipantTournament
 *
 */
@Entity

public class ParticipantTournament implements Serializable {

	
	private Date date_limite;
	private User participants;
	private Tournament tournament;
	private ParticipantTournamentPK participantTournamentPK;
	private static final long serialVersionUID = 1L;

	public ParticipantTournament() {
		super();
	}   
	public ParticipantTournament(Date date_Limite, User participants, Tournament tournament) {
		super();
		this.date_limite = date_Limite;
		this.participants = participants;
		this.tournament = tournament;
		this.participantTournamentPK= new ParticipantTournamentPK(participants.getId(),tournament.getId_tournament());
	}
	public Date getDate_limite() {
		return this.date_limite;
	}

	public void setDate_limite(Date date_limite) {
		this.date_limite = date_limite;
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
	@JoinColumn(name="idTournament",referencedColumnName="id_tournament",insertable=false,updatable=false)
	@JsonIgnore
	public Tournament getTournament() {
		return tournament;
	}
	public void setTournament(Tournament tournament) {
		this.tournament = tournament;
	}
	
	@JsonIgnore
	@EmbeddedId
	public ParticipantTournamentPK getParticipantTournamentPK() {
		return participantTournamentPK;
	}
	public void setParticipantTournamentPK(ParticipantTournamentPK participantTournamentPK) {
		this.participantTournamentPK = participantTournamentPK;
	}
   
}
