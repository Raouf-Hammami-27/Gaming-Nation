package ressst.comment;



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

import tag.ejb.sessionBean.comment.*;
import tag.ejb.domain.*;

@Path("/forum")
public class ForumThreadRestService {
	@Inject
	private IForumThreadLocal metier;

	@GET
	@Path("user")
	@Produces(MediaType.APPLICATION_JSON)
	public Response getCompte(@QueryParam("id") String id) {
		return Response.status(Status.OK).entity(metier.FindUser(id)).build();
		
	}

	@POST
	@Path("add")
	@Consumes(MediaType.APPLICATION_JSON)
	public Response addForum(ForumThread f) {

		User u = f.getUser();
		f.setDate(new Date());
		if (u instanceof User) {
			return Response.status(Status.OK)
	        .entity(metier.AddForumThread(f))
	        .build();
			
		} else
			throw new RuntimeException("don't have permission to add VipArticle ");
		
	}

	@GET
	@Path("list")
	@Produces(MediaType.APPLICATION_JSON)
	public Response listForumThread() {
		return Response.status(Status.OK).entity(metier.getAllForumThread()).build();
		
		
	}

	@GET
	@Path("get/{id}")
	@Produces(MediaType.APPLICATION_JSON)
	public Response getForumThread(@PathParam(value = "id") Integer id) {
		return Response.status(Status.OK).entity(metier.getForumThread(id)).build();
			
	}


	@PUT
	@Path("update")
	@Consumes(MediaType.APPLICATION_JSON)
	public void UpdateForum(ForumThread f) {
		User u = f.getUser();
		if (u instanceof Member) {
			metier.updateForumThread(f);
		}
	}

	@GET
	@Path("search/{key}")
	@Produces(MediaType.APPLICATION_JSON)
	public Response searchForumThread(@PathParam(value = "key") String m) {
		return Response.status(Status.OK).entity(metier.searchForumThread(m)).build();
		
		        
	}


	@DELETE
	@Path("delete/{idForum}/{idUser}")
	public void deleteForum(@PathParam(value = "idForum") Integer idForum,@PathParam(value = "idUser")String idUser) {
		 metier.deleteForumThread(idForum,idUser);
	}
}
