package tag.ejb.domain;

import java.io.Serializable;
import java.lang.String;
import java.util.List;

import javax.persistence.*;

/**
 * Entity implementation class for Entity: EvenementOrganizer
 *
 */
@Entity

public class EvenementOrganizer extends User implements Serializable {

	
	private List<Evenement> Evenements;
	
	@OneToMany(mappedBy="organizer")
	public List<Evenement> getEvenements() {
		return Evenements;
	}
	public void setEvenements(List<Evenement> Evenements) {
		this.Evenements = Evenements;
	}

	private static final long serialVersionUID = 1L;

	public EvenementOrganizer() {
		super();
	}
   
}
