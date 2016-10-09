package tag.ejb.domain;

import java.io.Serializable;
import java.lang.String;

import javax.persistence.*;

/**
 * Entity implementation class for Entity: Broadcast
 *
 */
@Entity

public class Broadcast implements Serializable {

	
	private Integer id;
	private String title;
	private String link;
	private String description;
	private static final long serialVersionUID = 1L;

	public Broadcast() {
		super();
	}   
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY) //auto-increment
	public Integer getId() {
		return this.id;
	}

	public void setId(Integer id) {
		this.id = id;
	}   
	public String getLink() {
		return this.link;
	}

	public void setLink(String link) {
		this.link = link;
	}   
	public String getDescription() {
		return this.description;
	}

	public void setDescription(String description) {
		this.description = description;
	}
	public String getTitle() {
		return title;
	}
	public void setTitle(String title) {
		this.title = title;
	}
   
}
