package tag.ejb.domain;

import java.io.Serializable;
import java.lang.Integer;
import java.lang.String;
import java.util.List;

import javax.persistence.*;


/**
 * Entity implementation class for Entity: news
 *
 */
@Entity
@Inheritance(strategy=InheritanceType.SINGLE_TABLE)
public class news extends Article implements Serializable {

	
	

	private static final long serialVersionUID = 1L;

	public news() {
		super();
	}

	@Override
	public String toString() {
		return "news []";
	}
	
	
   
}
