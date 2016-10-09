package ressst;

import java.util.Collection;
import java.util.List;

import javax.inject.Inject;
import javax.ws.rs.Consumes;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.Response;
import javax.ws.rs.core.Response.Status;

import tag.ejb.domain.Evenement;
import tag.ejb.domain.Tournament;
import tag.ejb.domain.User;
import tag.ejb.sessionBean.gestionEvenementLocal;
import tag.ejb.sessionBean.gestionUserLocal;

@Path("/Evenements")
public class EvenementResources {

	@Inject
	gestionEvenementLocal myEvenement;
	@Inject
	gestionUserLocal myUser;
	
	@GET
	@Produces("application/json")
	@Path("/{id}")
	public Response getEvenementById(@PathParam("id") int id){
		return Response.status(Status.OK).entity(myEvenement.getEvenementById(id)).build();
	}
	
	@GET
	@Produces("application/json")
	@Path("/EvenementTournaments/{id}")
	public Response getEvenementTournaments(@PathParam("id") int id){
		return Response.status(Status.OK).entity(myEvenement.getEvenementTournaments(id)).build();
	}

	@GET
	@Produces("application/json")
	public Response getAll(){

		return Response.status(Status.OK).entity(myEvenement.getAllEvenements()).build();
	}
	
	@POST
	@Produces("application/json")
	@Path("reserve")
	public Response reserveEvenement(@QueryParam("idEvenement") int idEvenement, @QueryParam("idUser") String idUser ){
		User user = myUser.getUserById(idUser);
		myEvenement.reserveForEvenement(idEvenement, user);
		return Response.status(Status.OK).build();
	}
	
	@POST
	@Consumes
	@Produces("application/json")
	public String addEvenement(Evenement e){
		return myEvenement.addEvenement(e);
		
		
	}
	
	
}
