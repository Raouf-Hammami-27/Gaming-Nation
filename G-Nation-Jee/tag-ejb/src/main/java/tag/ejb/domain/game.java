package tag.ejb.domain;


import java.io.Serializable;
import java.lang.Integer;
import java.lang.String;
import java.util.List;

import javax.persistence.*;


/**
 * Entity implementation class for Entity: game
 *
 */
@Entity
@Inheritance(strategy=InheritanceType.SINGLE_TABLE)
public class game extends Article implements Serializable {

	
	private Integer rating;
	private static final long serialVersionUID = 1L;
	private String category;
	

	
	
	
	public game() {
		super();
	}   
	
	
	public Integer getRating() {
		return this.rating;
	}

	public void setRating(Integer rating) {
		this.rating = rating;
	}
	
	public String getCategory() {
		return category;
	}
	public void setCategory(String category) {
		this.category = category;
	}


	public game(Integer rating, String category) {
		super();
		this.rating = rating;
		this.category = category;
	}


	@Override
	public String toString() {
		return "game [rating=" + rating + ", category=" + category + "]";
	}
	
	
   
}
