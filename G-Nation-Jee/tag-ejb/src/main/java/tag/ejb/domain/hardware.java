package tag.ejb.domain;

import java.io.Serializable;
import java.lang.Integer;
import java.lang.String;

import javax.persistence.*;

/**
 * Entity implementation class for Entity: hardware
 *
 */
@Entity

public class hardware implements Serializable {

	
	private Integer id_hardware;
	private String name;
	private String reference;
	private String type;
	private Administrator admin;
	
	@ManyToOne
	public Administrator getAdmin() {
		return admin;
	}
	public void setAdmin(Administrator admin) {
		this.admin = admin;
	}

	private static final long serialVersionUID = 1L;

	public hardware() {
		super();
	}   
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)   
	public Integer getId_hardware() {
		return this.id_hardware;
	}

	public void setId_hardware(Integer id_hardware) {
		this.id_hardware = id_hardware;
	}   
	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}   
	public String getReference() {
		return this.reference;
	}

	public void setReference(String reference) {
		this.reference = reference;
	}   
	public String getType() {
		return this.type;
	}

	public void setType(String type) {
		this.type = type;
	}
   
}
