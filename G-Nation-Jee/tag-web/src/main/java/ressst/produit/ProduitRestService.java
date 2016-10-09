package ressst.produit;



import java.util.List;

import javax.inject.Inject;
import javax.ws.rs.Consumes;
import javax.ws.rs.DELETE;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.PUT;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import javax.ws.rs.core.Response.Status;

import tag.ejb.sessionBean.produit.*;
import tag.ejb.domain.*;


@Path("/produit")
public class ProduitRestService {

	@Inject
	private IProduitLocal metier;
	
	@GET
	@Path("user/{id}")
	@Produces(MediaType.APPLICATION_JSON)
	public User getCompte(@PathParam(value = "id") String id) {
		return metier.FindUser(id);
	}
	
	@POST
	@Path("add")
	@Consumes("application/JSON")
	public Response addProduit(Produit p) {

		


		
			return Response.status(Status.OK).entity(metier.AddProduit(p)).build();
			
	
		
	}
	
	@GET
	@Path("list")
	@Produces(MediaType.APPLICATION_JSON)
	public Response listProduit() {
		return Response.status(Status.OK).entity(metier.getAllProduit()).build();
		
	}
	
	@GET
	@Path("get/{id}")
	@Produces(MediaType.APPLICATION_JSON)
	public Response getProduit(@PathParam(value = "id") Long id) {
		return Response.status(Status.OK).entity(metier.getProduit(id)).build();
	}
	
	@PUT
	@Path("update")
	@Consumes(MediaType.APPLICATION_JSON)
	public void UpdateProduct(Produit p) {

		
		User u = p.getUser();
		
		if (u instanceof Vip) {
			metier.updateProduit(p);
		}
	}
	
	@GET
	@Path("chearch/{key}")
	@Produces(MediaType.APPLICATION_JSON)
	public Response chercherProduit(@PathParam(value = "key") String m) {
		return Response.status(Status.OK).entity(metier.chercherProduit(m)).build();
		
	}

	@DELETE
	@Path("delete/{idProduct}/{idUser}")
	public void deleteProduct(@PathParam(value = "idProduct") Long idProduit,@PathParam(value = "idUser")String idUser) {
		 metier.supprimerProduit(idProduit, idUser);
	}
}
