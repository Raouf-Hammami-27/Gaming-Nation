package tag.ejb.domain;

import java.io.Serializable;

import javax.persistence.Embeddable;

@Embeddable
public class ParticipantsPK implements Serializable {
	
	private String idParticipant;
	private int idEvent;
	
	
	public ParticipantsPK() {
		super();
	}
	public ParticipantsPK(String idParticipant, int idEvent) {
		super();
		this.idParticipant = idParticipant;
		this.idEvent = idEvent;
	}
	public String getIdParticipant() {
		return idParticipant;
	}
	public void setIdParticipant(String idParticipant) {
		this.idParticipant = idParticipant;
	}
	public int getIdEvent() {
		return idEvent;
	}
	public void setIdEvent(int idEvent) {
		this.idEvent = idEvent;
	}
	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + idEvent;
		result = prime * result
				+ ((idParticipant == null) ? 0 : idParticipant.hashCode());
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
		ParticipantsPK other = (ParticipantsPK) obj;
		if (idEvent != other.idEvent)
			return false;
		if (idParticipant == null) {
			if (other.idParticipant != null)
				return false;
		} else if (!idParticipant.equals(other.idParticipant))
			return false;
		return true;
	}
	

}
