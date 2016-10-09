package ressst.vip;



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

import tag.ejb.domain.*;
import tag.ejb.sessionBean.vip.*;

@Path("/vipArticle")
public class VipArticleRestService {
	@Inject
	private IVipArticleLocal metier;

	@GET
	@Path("user")
	@Produces(MediaType.APPLICATION_JSON)
	public Response getCompte(@QueryParam("id") String id) {
		return Response.status(Status.OK)
		        .entity(metier.FindUser(id))
		        .build();
	}

	@POST
	@Path("add")
	@Consumes(MediaType.APPLICATION_JSON)
	public Response addVipArticle(VipArticle v) {

		User u = v.getVip();
		if (u instanceof Vip) {
			return Response.status(Status.OK)
	        .entity(metier.AddVipArticle(v))
	        .build();
			
		} else
			throw new RuntimeException("don't have permission to add VipArticle ");
		
	}

	@GET
	@Path("list")
	@Produces(MediaType.APPLICATION_JSON)
	public Response listVipArticle() {
		return Response.status(Status.OK)
		        .entity(metier.getAllVipArticle())
		        .build();
	}

	@GET
	@Path("get/{idArticle}")
	@Produces(MediaType.APPLICATION_JSON)
	public Response getVipArticle(@PathParam(value = "idArticle") Integer idArticle) {
		return Response.status(Status.OK)
		        .entity(metier.getVipArticle(idArticle))
		        .build();
	}

	@PUT
	@Path("update")
	@Consumes(MediaType.APPLICATION_JSON)
	public void updateVipArticle(VipArticle v) {
		User u = v.getVip();
		if (u instanceof Vip) {
			metier.updateVipArticle(v);
		}
	}

	@GET
	@Path("search/{key}")
	@Produces(MediaType.APPLICATION_JSON)
	public Response searchVipArticle(@PathParam(value = "key") String idVip) {
		return  Response.status(Status.OK)
		        .entity(metier.chercherVipArticle(idVip))
		        .build();
	}

	@DELETE
	@Path("delete/{id}/{idVip}")
	public void deleteVipArticle(@PathParam(value = "id") Integer id, @PathParam(value = "idVip") String idVip) {
		metier.supprimerVipArticle(id, idVip);
	}
}
