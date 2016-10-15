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

import tag.ejb.sessionBean.gestionUserLocal;
import tag.ejb.sessionBean.comment.*;
import tag.ejb.domain.*;


@Path("/comment")
public class CommentRestService {
	@Inject
	ICommentLocal metier;
	@Inject
	gestionUserLocal gestus;

	@GET
	@Path("user")
	@Produces(MediaType.APPLICATION_JSON)
	public Response getUser(@QueryParam("id") String id) {
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
	@Path("/add")
	@Consumes("application/json")
	public Response CommentOnForum (@QueryParam("idUser") String idUser,@QueryParam("Discrip") String description,@QueryParam("idArticle") Integer idArticle)
	{ 
		Member mem= (Member) gestus.getUserById(idUser);
		metier.CommentOnForum(description,new Date(),mem, idArticle);
		return Response.status(Status.OK).build();	
		
		
		
		
	   	
		
		
	}

	@GET
	@Path("list")
	@Produces(MediaType.APPLICATION_JSON)
	public Response listCommentaire() {
		return Response
				.status(200)
		        .header("Access-Control-Allow-Origin", "*")
		        .header("Access-Control-Allow-Headers", "origin, content-type, accept, authorization")
		        .header("Access-Control-Allow-Credentials", "true")
		        .header("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS, HEAD")
		        .header("Access-Control-Max-Age", "1209600")
		        .entity(metier.getAllComment())
		        .build();	
	}

	@GET
	@Path("listById/{articleId}")
	@Produces(MediaType.APPLICATION_JSON)
	public Response listCommentaireByArticle(@PathParam(value = "articleId") Integer idArticle) {
		return Response.status(Status.OK).entity(metier.getAllCommentByArticle(idArticle)).build();
		
	}

	@GET
	@Path("get/{id}")
	@Produces(MediaType.APPLICATION_JSON)
	public Response getComment(@PathParam(value = "id") Long idCommentaire) {
		return Response.status(Status.OK).entity(metier.getCommentaire(idCommentaire)).build();
		
	}


	@PUT
	@Path("update")
	@Consumes(MediaType.APPLICATION_JSON)
	public void UpdateCommentaire(Commentaire c) {

		
		User u = c.getUser();
		
		if (u instanceof Member) {
			metier.updateComment(c);
		}
	}


	@DELETE
	@Path("delete/{idComment}/{idUser}")
	public void deleteForum(@PathParam(value = "idComment") Long idCommentaire,@PathParam(value = "idUser")String idUser) {
		 metier.deleteComment(idCommentaire, idUser);
	}

}
