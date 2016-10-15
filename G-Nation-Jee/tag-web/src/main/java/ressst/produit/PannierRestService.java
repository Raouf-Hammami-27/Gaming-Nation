package ressst.produit;



import java.util.Date;

import javax.inject.Inject;
import javax.ws.rs.Consumes;
import javax.ws.rs.DELETE;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.PUT;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;


import javax.ws.rs.core.Response.Status;

import tag.ejb.sessionBean.produit.*;
import tag.ejb.domain.*;


@Path("/pannier")
public class PannierRestService {
	@Inject
	private IPannierLocal metier;

	@GET
	@Path("user")
	@Produces(MediaType.APPLICATION_JSON)
	public Response getCompte(@QueryParam("id") String id) {
		return Response
				.status(200)
		        .header("Access-Control-Allow-Origin", "*")
		        .header("Access-Control-Allow-Headers", "origin, content-type, accept, authorization")
		        .header("Access-Control-Allow-Credentials", "true")
		        .header("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS, HEAD")
		        .header("Access-Control-Max-Age", "1209600")
		        .entity(metier.FindUser(id))
		        .build();
	}

	@POST
	@Path("add")
	@Consumes("application/JSON")
    public Response addPannier(@QueryParam("idUser") String idUser ,@QueryParam("idProduit") long idProduit){
		
		User users=  metier.FindUser(idUser);
		
		metier.AddPannier(users, idProduit, new Date());		
		return Response.status(Status.OK).build();	
		
	}
	

	@GET
	@Path("list")
	@Produces(MediaType.APPLICATION_JSON)
	public Response listPannier() {
		return Response.status(Status.OK)
		        .entity(metier.getAllPannier())
		        .build();
	}

	@GET
	@Path("")
	@Produces(MediaType.APPLICATION_JSON)
	public Response getPannier(@QueryParam(value = "id") Long id) {
		return Response
				.status(200)
		        .header("Access-Control-Allow-Origin", "*")
		        .header("Access-Control-Allow-Headers", "origin, content-type, accept, authorization")
		        .header("Access-Control-Allow-Credentials", "true")
		        .header("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS, HEAD")
		        .header("Access-Control-Max-Age", "1209600")
		        .entity(metier.getPannier(id))
		        .build();
	}


	@PUT
	@Path("update")
	@Consumes(MediaType.APPLICATION_JSON)
	public void UpdatePannel(Pannier p) {

		
		User u = p.getUser();
		
		if (u instanceof Member) {
			metier.updatePannier(p);
		}
	}

	@GET
	@Path("search")
	@Produces(MediaType.APPLICATION_JSON)
	public Response chercherPannier(@QueryParam("id") String id) {
		return  
				Response.status(Status.OK)
		        .entity(metier.chercherPannier(id))
		        .build();
	}

	@DELETE
	@Path("delete")
	public Response deletePannier(@QueryParam("idPannier") Long idPannier,@QueryParam("idUser")String idUser) {
		 metier.supprimerPannier(idPannier, idUser);
		 return Response.status(Status.OK).build();
	}

}
