package tag.ejb.domain;

import java.io.Serializable;
import java.util.List;
import javax.persistence.DiscriminatorValue;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.OneToMany;

import com.fasterxml.jackson.annotation.JsonIgnore;
@Entity
public class Vip extends Member implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	
	private List<VipArticle> listVipArticle;
	
	
	public Vip(List<VipArticle> listVipArticle) {
		super();
		this.setListVipArticle(listVipArticle);
	}


	public Vip() {
		super();
		// TODO Auto-generated constructor stub
	}

	@OneToMany(mappedBy="vip", fetch=FetchType.EAGER)
	@JsonIgnore
	public List<VipArticle> getListVipArticle() {
		return listVipArticle;
	}


	public void setListVipArticle(List<VipArticle> listVipArticle) {
		this.listVipArticle = listVipArticle;
	}
	
	
}
