package tag.ejb.domain;

import java.io.Serializable;
import javax.persistence.DiscriminatorValue;
import javax.persistence.Entity;
import javax.persistence.JoinColumn;
import javax.persistence.Lob;
import javax.persistence.ManyToOne;

@Entity
public class VipArticle extends Article implements Serializable {

	private static final long serialVersionUID = 1L;

	private byte[] media;

	
	private Vip vip;
	
	@Lob
	public byte[] getMedia() {
		return media;
	}

	public void setMedia(byte[] media) {
		this.media = media;
	}
	@ManyToOne
	@JoinColumn(name = "idVip")
	public Vip getVip() {
		return vip;
	}

	public void setVip(Vip vip) {
		this.vip = vip;
	}

	public VipArticle() {

	}

}
