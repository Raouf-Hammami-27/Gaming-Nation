package tag.ejb.domain;

import java.io.Serializable;
import java.lang.String;
import java.util.List;

import javax.persistence.*;

/**
 * Entity implementation class for Entity: Administrator
 *
 */
@Entity

public class Administrator extends User implements Serializable {

	
	private List<hardware> hardware;
	private List<Article> articles;
	
	
	@OneToMany(mappedBy="admin")
	public List<hardware> getHardware() {
		return hardware;
	}
	public void setHardware(List<hardware> hardware) {
		this.hardware = hardware;
	}

	private static final long serialVersionUID = 1L;

	public Administrator() {
		super();
	}
	@OneToMany(mappedBy="adminn",fetch=FetchType.EAGER)
	public List<Article> getArticles() {
		return articles;
	}
	public void setArticles(List<Article> articles) {
		this.articles = articles;
	}   

}
