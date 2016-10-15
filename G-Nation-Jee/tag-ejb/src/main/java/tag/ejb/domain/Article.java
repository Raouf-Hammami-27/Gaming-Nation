package tag.ejb.domain;

import java.io.Serializable;
import java.lang.Integer;
import java.lang.String;
import java.util.Date;
import java.util.List;

import javax.persistence.*;

import com.fasterxml.jackson.annotation.JsonIgnore;

/**
 * Entity implementation class for Entity: Article
 *
 */
@Entity
public class Article implements Serializable {

	
	private Integer idArticle;
	private String name;
	private String description;
	private static final long serialVersionUID = 1L;
	private Administrator adminn;
	private List<commentt> cmtt;
	private Date date;
	private String Link_img;
	private String Link_imgg;



	public Article() {
		super();
	}   
	
	
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY) 
	public Integer getIdArticle() {
		return idArticle;
	}

	public void setIdArticle(Integer idArticle) {
		this.idArticle = idArticle;
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
	public Administrator getAdminn() {
		return adminn;
	}
	public void setAdminn(Administrator adminn) {
		this.adminn = adminn;
	}
	
	
	
	@OneToMany(mappedBy="article")
	@JsonIgnore
	public List<commentt> getCmtt() {
		return cmtt;
	}

	public void setCmtt(List<commentt> cmtt) {
		this.cmtt = cmtt;
	}


	@Override
	public String toString() {
		return "Article [idArticle=" + idArticle + ", name=" + name
				+ ", description=" + description + ", adminn=" + adminn
				+ ", cmtt=" + cmtt + "]";
	}


	@Temporal(TemporalType.DATE)
	public Date getDate() {
		return date;
	}


	public void setDate(Date date) {
		this.date = date;
	}


	public String getLink_img() {
		return Link_img;
	}


	public void setLink_img(String link_img) {
		Link_img = link_img;
	}


	public String getLink_imgg() {
		return Link_imgg;
	}


	public void setLink_imgg(String link_imgg) {
		Link_imgg = link_imgg;
	}


	



	
	
   
}
