package tag.ejb.domain;

import java.io.Serializable;
import java.lang.Integer;
import java.util.List;

import javax.persistence.*;

import com.fasterxml.jackson.annotation.JsonIgnore;

/**
 * Entity implementation class for Entity: Member
 *
 */
@Entity
@Inheritance(strategy=InheritanceType.SINGLE_TABLE)
public class Member extends User implements Serializable {

	
	private Integer ranking;
	private Integer cashRecolted;
	private Integer trophies;
	private List<ForumThread> forumthread;
	private Team team;

	private static final long serialVersionUID = 1L;

	public Member() {
		super();
	}   
	
 
	public Integer getRanking() {
		return this.ranking;
	}

	public void setRanking(Integer ranking) {
		this.ranking = ranking;
	}   
	public Integer getCashRecolted() {
		return this.cashRecolted;
	}

	public void setCashRecolted(Integer cashRecolted) {
		this.cashRecolted = cashRecolted;
	}   
	public Integer getTrophies() {
		return this.trophies;
	}

	public void setTrophies(Integer trophies) {
		this.trophies = trophies;
	}
	@OneToMany(fetch=FetchType.EAGER,mappedBy="user")
	@JsonIgnore
	public List<ForumThread> getForumthread() {
		return forumthread;
	}
	public void setForumthread(List<ForumThread> forumthread) {
		this.forumthread = forumthread;
	}
    @ManyToOne
	public Team getTeam() {
		return team;
	}

	public void setTeam(Team team) {
		this.team = team;
	}


	@Override
	public String toString() {
		return "Member [ranking=" + ranking + ", cashRecolted=" + cashRecolted
				+ ", trophies=" + trophies + ", forumthread=" + forumthread
				+ ", team=" + team + "]";
	}

	
	
}