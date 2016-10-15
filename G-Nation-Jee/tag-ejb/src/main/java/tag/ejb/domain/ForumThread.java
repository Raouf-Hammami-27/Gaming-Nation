package tag.ejb.domain;

import java.io.Serializable;
import javax.persistence.Entity;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;

@Entity
public class ForumThread extends Article implements Serializable {

	private static final long serialVersionUID = 1L;

	
	private User user;

	@ManyToOne
	@JoinColumn(name = "Id")
	public User getUser() {
		return user;
	}

	public void setUser(User user) {
		this.user = user;
	}


	public ForumThread() {
		super();
	}

}
