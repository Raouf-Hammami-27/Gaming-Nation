package tag.ejb.domain;

import java.io.Serializable;
import java.lang.Integer;
import java.lang.String;
import java.util.List;

import javax.persistence.*;
import com.fasterxml.jackson.annotation.JsonIgnore;

/**
 * Entity implementation class for Entity: User
 *
 */
@Entity
@Inheritance(strategy=InheritanceType.SINGLE_TABLE)
public class User implements Serializable {

	
	
	private String Id;
	private String firstName;
	private String LastName;
	private String username;
	private String password;
	private String mail;
	private String role;
	private int socialAuth;
	private List<commentt> cmtt;
	private List<Participants> event;
	private String image_link;
	
	private List<Produit> listProduit;
	
	private List<Commentaire> listCommentaire;

	private static final long serialVersionUID = 1L;

	public User() {
		super();
	}   
	@Id    
	public String getId() {
		return this.Id;
	}

	public void setId(String idUser) {
		this.Id = idUser;
	}   
	
	@Column(unique=true)
	public String getUsername() {
		return this.username;
	}

	public void setUsername(String username) {
		this.username = username;
	}   
	public String getPassword() {
		return this.password;
	}

	public void setPassword(String password) {
		this.password = password;
	}
	@Column(unique=true)
	public String getMail() {
		return mail;
	}
	public void setMail(String mail) {
		this.mail = mail;
	}
	public String getFirstName() {
		return firstName;
	}
	public void setFirstName(String firstName) {
		this.firstName = firstName;
	}
	public String getLastName() {
		return LastName;
	}
	public void setLastName(String lastName) {
		LastName = lastName;
	}
	public String getRole() {
		return role;
	}
	public void setRole(String role) {
		this.role = role;
	}
	
	public User(String firstName, String lastName, Integer cinUser,
			String username, String password, String mail) {
		super();
		this.firstName = firstName;
		LastName = lastName;
		this.username = username;
		this.password = password;
		this.mail = mail;
	}
	public User(String idUser, String firstName, String lastName, String username, String password, String mail,
			String role) {
		super();
		this.Id = idUser;
		this.firstName = firstName;
		LastName = lastName;
		this.username = username;
		this.password = password;
		this.mail = mail;
		this.role = role;
	}
	
	public User(String firstName, String lastName, String username, String password, String mail, String role,
			int socialAuth, String image_link) {
		super();
		this.firstName = firstName;
		LastName = lastName;
		this.username = username;
		this.password = password;
		this.mail = mail;
		this.role = role;
		this.socialAuth = socialAuth;
		this.image_link = image_link;
	}
	 
	public User(String id, String firstName, String lastName, String username, String password, String mail,
			String role, int socialAuth, String image_link) {
		super();
		Id = id;
		this.firstName = firstName;
		LastName = lastName;
		this.username = username;
		this.password = password;
		this.mail = mail;
		this.role = role;
		this.socialAuth = socialAuth;
		this.image_link = image_link;
	}
	@OneToMany(fetch=FetchType.EAGER,mappedBy="participants",cascade=CascadeType.PERSIST)
	@JsonIgnore
	public List<Participants> getEvent() {
		return event;
	}
	public void setEvent(List<Participants> listAffectation) {
		this.event = listAffectation;
	}
	
	public String getImage_link() {
		return image_link;
	}
	public void setImage_link(String image_link) {
		this.image_link = image_link;
	}
	@OneToMany(mappedBy="user", fetch=FetchType.EAGER)
	public List<commentt> getCmtt() {
		return cmtt;
	}
	public void setCmtt(List<commentt> cmtt) {
		this.cmtt = cmtt;
	}

	@OneToMany(mappedBy="user", fetch=FetchType.EAGER)
	@JsonIgnore
	public List<Commentaire> getListCommentaire() {
		return listCommentaire;
	}
	public void setListCommentaire(List<Commentaire> listCommentaire) {
		this.listCommentaire = listCommentaire;
	}	
	
	@OneToMany(mappedBy="user")
	@JsonIgnore
	public List<Produit> getListProduit() {
		return listProduit;
	}
	public void setListProduit(List<Produit> listProduit) {
		this.listProduit = listProduit;
	}
	@Override
	public String toString() {
		return "User [Id=" + Id + ", firstName=" + firstName + ", LastName="
				+ LastName + ", username=" + username + ", password="
				+ password + ", mail=" + mail + ", role=" + role + ", cmtt="
				+ cmtt + ", event=" + event + ", image_link=" + image_link
				+ ", listProduit=" + listProduit + ", listCommentaire="
				+ listCommentaire + "]";
	}
	public int getSocialAuth() {
		return socialAuth;
	}
	public void setSocialAuth(int socialAuth) {
		this.socialAuth = socialAuth;
	}
	
	
	
	
}
